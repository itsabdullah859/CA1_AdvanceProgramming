using System;

namespace ContactBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactBook book = new ContactBook();
            int choice;

            do
            {
                Console.WriteLine("\n--- MAIN MENU ---");
                Console.WriteLine("1: Add Contact");
                Console.WriteLine("2: Show All Contacts");
                Console.WriteLine("3: Show Contact Details");
                Console.WriteLine("4: Update Contact");
                Console.WriteLine("5: Delete Contact");
                Console.WriteLine("0: Exit");
                Console.Write("Enter your choice: ");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1: book.AddContact(); break;
                    case 2: book.ShowAllContacts(); break;
                    case 3: book.ShowContactDetails(); break;
                    case 4: book.UpdateContact(); break;
                    case 5: book.DeleteContact(); break;
                    case 0: Console.WriteLine("Exiting..."); break;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
            }
            while (choice != 0);
        }
    }
}
