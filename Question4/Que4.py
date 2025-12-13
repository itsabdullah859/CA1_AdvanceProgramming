from bs4 import BeautifulSoup
import csv

# -------------------------
# Function to scrape a hotel page
# -------------------------
def scrape_hotel(filename, hotel_name):  
    rooms_data = []

    # Read the HTML file
    with open(filename, "r", encoding="utf-8") as file: 
        html = file.read()

    soup = BeautifulSoup(html, "html.parser")

    # Find all room sections
    rooms = soup.find_all("div", class_="room")

    for room in rooms:
        room_name = room.find(class_="room-name").text.strip()
        price = room.find(class_="price").text.strip()
        details = room.find(class_="details").text.strip()

        # Extract features (list items inside <li>)
        features_list = room.find("ul").find_all("li")
        features = ", ".join(f.text.strip() for f in features_list)

        # Store everything in a dictionary
        rooms_data.append([
            hotel_name,
            room_name,
            price,
            details,
            features
        ])

    return rooms_data


# ---------------------------------------
# Scrape both hotels
# ---------------------------------------
hotel1 = scrape_hotel("hotel1.html", "Simple Hotel")
hotel2 = scrape_hotel("hotel2.html", "Cozy Hotel")

all_rooms = hotel1 + hotel2

# ---------------------------------------
# Write data to CSV
# ---------------------------------------
csv_filename = "hotel_prices.csv"

with open(csv_filename, "w", newline="", encoding="utf-8") as csvfile:
    writer = csv.writer(csvfile)
    writer.writerow(["Hotel", "Room Name", "Price", "Description", "Features"])
    writer.writerows(all_rooms)

print(f"CSV file '{csv_filename}' created successfully!")

# ---------------------------------------
# Read CSV and display data
# ---------------------------------------
print("\n--- Available Hotel Rooms (from CSV) ---\n")

with open(csv_filename, "r", encoding="utf-8") as csvfile:
    reader = csv.reader(csvfile)
    for row in reader:
        print(row)
