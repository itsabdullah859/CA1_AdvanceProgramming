import socket
import json

def main():
    print("\n===== DBS Admission Application =====")

    name = input("Enter Name: ")
    address = input("Enter Address: ")
    qualification = input("Enter Educational Qualification: ")

    print("\nCourses Offered:")
    print("1. MSc in Cyber Security")
    print("2. MSc Information Systems & Computing")
    print("3. MSc Data Analytics")

    course_choice = input("Choose course (1/2/3): ")

    courses = {
        "1": "MSc in Cyber Security",
        "2": "MSc Information Systems & Computing",
        "3": "MSc Data Analytics"
    }

    course = courses.get(course_choice, "Unknown")

    year = input("Enter intended start year (e.g., 2025): ")
    month = input("Enter intended start month (e.g., January): ")

    # Package all data
    data = {
        "name": name,
        "address": address,
        "qualification": qualification,
        "course": course,
        "year": year,
        "month": month
    }

    # Send to server
    host = "127.0.0.1"  
    port = 5000

    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.connect((host, port))

    # send data
    client_socket.send(json.dumps(data).encode())

    # receive application number
    app_number = client_socket.recv(1024).decode()
    print("\nYour application has been submitted!")
    print("Your Assigned Application Number is:", app_number)

    client_socket.close()

if __name__ == "__main__":
    main()
