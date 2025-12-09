using System;

namespace ContactBookApp
{
    public class Contact
    {
        // Encapsulated fields with Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }

        // Constructor Overloading
        public Contact() { }

        public Contact(string first, string last, string company,
                       string mobile, string email, string birthdate)
        {
            FirstName = first;
            LastName = last;
            Company = company;
            MobileNumber = mobile;
            Email = email;
            Birthdate = birthdate;
        }

        // Display contact info
        public void ShowContact()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Name       : {FirstName} {LastName}");
            Console.WriteLine($"Company    : {Company}");
            Console.WriteLine($"Mobile     : {MobileNumber}");
            Console.WriteLine($"Email      : {Email}");
            Console.WriteLine($"Birthdate  : {Birthdate}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
