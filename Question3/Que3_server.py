import socket
import sqlite3
import json
import random
import string

# ---------------------------
# DATABASE INITIAL SETUP
# ---------------------------
def init_database():
    conn = sqlite3.connect("applications.db")
    cursor = conn.cursor()

    # Create table if not exists
    cursor.execute("""
        CREATE TABLE IF NOT EXISTS applications(
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            app_number TEXT,
            name TEXT,
            address TEXT,
            qualification TEXT,
            course TEXT,
            start_year TEXT,
            start_month TEXT
        )
    """)
    conn.commit()
    conn.close()

# ---------------------------
# GENERATE UNIQUE ID
# ---------------------------
def generate_application_number():
    return "DBS" + ''.join(random.choices(string.digits, k=6))

# ---------------------------
# STORE DATA IN DATABASE
# ---------------------------
def save_to_database(data, app_number):
    conn = sqlite3.connect("applications.db")
    cursor = conn.cursor()

    cursor.execute("""
        INSERT INTO applications(app_number, name, address, qualification, course, start_year, start_month)
        VALUES (?, ?, ?, ?, ?, ?, ?)
    """, (app_number, data["name"], data["address"], data["qualification"], 
          data["course"], data["year"], data["month"]))
    
    conn.commit()
    conn.close()

# ---------------------------
# MAIN SERVER PROGRAM
# ---------------------------
def main():
    init_database()

    host = "127.0.0.1"
    port = 5000

    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind((host, port))
    server_socket.listen(1)

    print("DBS SERVER RUNNING... Waiting for connections...")

    while True:
        conn, address = server_socket.accept()
        print("Connected to:", address)

        # receive data from client
        data = conn.recv(1024).decode()
        student_data = json.loads(data) 

        # generate unique number
        app_number = generate_application_number()

        # save in database
        save_to_database(student_data, app_number)

        # send ID back to client
        conn.send(app_number.encode())

        conn.close()
        print("Application Saved. ID Sent.\n")

if __name__ == "__main__":
    main()
