using System;
using System.Collections.Generic;

namespace ContactBookApp
{
    public class ContactBook
    {
        private List<Contact> contacts = new List<Contact>();

        // Add Contact
        public void AddContact()
        {
            Console.Write("Enter First Name: ");
            string first = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string last = Console.ReadLine();

            Console.Write("Enter Company: ");
            string company = Console.ReadLine();

            string mobile;
            do
            {
                Console.Write("Enter Mobile Number (9-digit, non-zero): ");
                mobile = Console.ReadLine();
            }
            while (!ValidateMobile(mobile));

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Birthdate: ");
            string birthdate = Console.ReadLine();

            Contact newContact = new Contact(first, last, company, mobile, email, birthdate);
            contacts.Add(newContact);

            Console.WriteLine("Contact Added Successfully!");
        }

        // Show All Contacts
        public void ShowAllContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts available.");
                return;
            }

            Console.WriteLine("\n--- All Contacts ---");
            foreach (var c in contacts)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName} - {c.MobileNumber}");
            }
        }

        // Show Contact Details
        public void ShowContactDetails()
        {
            Console.Write("Enter Mobile Number to search: ");
            string mobile = Console.ReadLine();

            Contact c = contacts.Find(x => x.MobileNumber == mobile);

            if (c == null)
                Console.WriteLine("Contact not found!");
            else
                c.ShowContact();
        }

        // Update Contact
        public void UpdateContact()
        {
            Console.Write("Enter Mobile Number to Update: ");
            string mobile = Console.ReadLine();

            Contact c = contacts.Find(x => x.MobileNumber == mobile);

            if (c == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            Console.Write("Enter New First Name: ");
            c.FirstName = Console.ReadLine();

            Console.Write("Enter New Last Name: ");
            c.LastName = Console.ReadLine();

            Console.Write("Enter New Company: ");
            c.Company = Console.ReadLine();

            Console.Write("Enter New Email: "); 
            c.Email = Console.ReadLine();

            Console.Write("Enter New Birthdate: ");
            c.Birthdate = Console.ReadLine();

            Console.WriteLine("Contact Updated Successfully!");
        }

        // Delete Contact
        public void DeleteContact()
        {
            Console.Write("Enter Mobile Number to Delete: ");
            string mobile = Console.ReadLine();

            Contact c = contacts.Find(x => x.MobileNumber == mobile);

            if (c == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            contacts.Remove(c);
            Console.WriteLine("Contact Deleted Successfully!");
        }

        // Data Validation
        private bool ValidateMobile(string mobile)
        {
            if (mobile.Length != 9) return false;
            if (!long.TryParse(mobile, out long num)) return false;
            if (num <= 0) return false;
            return true;
        }
    }
}
