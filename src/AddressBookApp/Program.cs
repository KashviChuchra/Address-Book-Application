    using AddressBookApp.src.AddressBookApp.Exceptions;
    using AddressBookApp.src.AddressBookApp.Models;
    using AddressBookApp.src.AddressBookApp.Services;
    using AddressBookApp.src.AddressBookApp.Validation;
    using System;
    namespace AddressBookApp;

    class Program
    {
        public static void Main(string[] args)
        {

            ContactValidator validator = new ContactValidator();

            // sample contacts  
            Contact sampleContact1 = new Contact("Hargun", "Singh", "Dugri", "Ludhiana", "Punjab", "123456", "1111111", "hargun@gmail.com");
            Contact sampleContact2 = new Contact("Aman", "Deep", "Model Town", "Ludhiana", "Punjab", "141002", "222222222", "aman@gmail.com");
            Contact sampleContact3 = new Contact("Sukhman", "Preet", "Sarabha Nagar", "Ludhiana", "Punjab", "141001", "333333333", "sukhman@gmail.com");
            Contact sampleContact4 = new Contact("Navjot", "Kaur", "Sector 34", "Chandigarh", "Punjab", "160022", "444444444", "navjot@gmail.com");
            Contact sampleContact5 = new Contact("Gurpreet", "Singh", "Phase 3B2", "Mohali", "Punjab", "160059", "555555555", "gurpreet@gmail.com");
            Contact sampleContact6 = new Contact("Kashvi", "Chuchra", "Gobind Colony, Dhand Road", "Kaithal", "Haryana", "136027", "7777555567", "kashvi@gmail.com");

            
            // validation
            try
            {
                validator.Validate(sampleContact1);
                validator.Validate(sampleContact2);
                validator.Validate(sampleContact3);
                validator.Validate(sampleContact4); 
                validator.Validate(sampleContact5);
                validator.Validate(sampleContact6);
            }
            catch (InvalidContactException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            // address book 1
            AddressBook addressBook1 = new AddressBook();
            addressBook1.AddContact(sampleContact1);
            addressBook1.AddContact(sampleContact2);
            addressBook1.AddContact(sampleContact3);
            addressBook1.AddContact(sampleContact4);
            addressBook1.AddContact(sampleContact5);
            addressBook1.AddContact(sampleContact6);

            // address book 2
            AddressBook addressBook2 = new AddressBook();
            addressBook2.AddContact(sampleContact1);
            addressBook2.AddContact(sampleContact2);
        

            // main adderess book
            AddressBookMain addressBookMain = new AddressBookMain();
            addressBookMain.AddAddressBook(addressBook1);
            addressBookMain.AddAddressBook(addressBook2);
           

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("====ADDRESS BOOK MENU====");
                Console.WriteLine("\n1- Add Contact");
                Console.WriteLine("2- Edit Contact");
                Console.WriteLine("3- Delete Contact");
                Console.WriteLine("4- Show All Contacts");
                Console.WriteLine("5- Total Contact Count");
                Console.WriteLine("6- Search By City");
                Console.WriteLine("7- Search By State");
                Console.WriteLine("8- View By City/State");
                Console.WriteLine("9- Count By City/State");
                Console.WriteLine("10- Sort By Name");
                Console.WriteLine("11- Sort By City/State/Zip");
                Console.WriteLine("0- Exit");
                Console.WriteLine();

                string choice = Console.ReadLine();

            if (choice == "1")
            {
                try
                {
                    Console.Write("Enter first name:");
                    string firstName = Console.ReadLine();

                    Console.Write("Enter last name:");
                    string lastName = Console.ReadLine();

                    Console.Write("Enter address:");
                    string address = Console.ReadLine();

                    Console.Write("Enter city:");
                    string city = Console.ReadLine();

                    Console.Write("Enter state:");
                    string state = Console.ReadLine();

                    Console.Write("Enter zip:");
                    string zip = Console.ReadLine();

                    Console.Write("Enter phone number:");
                    string phoneNumber = Console.ReadLine();

                    Console.Write("Enter email:");
                    string email = Console.ReadLine();

                    Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);

                    validator.Validate(contact);
                    bool added = addressBook1.AddContact(contact);
                    if (added) Console.WriteLine("Contact Added Successfully!");
                }
                catch (InvalidContactException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter first name to edit: ");
                string firstName1 = Console.ReadLine();
                Console.WriteLine("Enter last name to edit: ");
                string lastName1 = Console.ReadLine();
                addressBook1.EditContact(firstName1, lastName1, validator);

            }
            else if (choice == "3")
            {
                Console.WriteLine("Enter first name to delete: ");
                string firstName1 = Console.ReadLine();
                Console.WriteLine("Enter last name to delete: ");
                string lastName1 = Console.ReadLine();
                addressBook1.DeleteContact(firstName1, lastName1);
            }
            else if (choice == "4")
            {
                addressBook1.PrintAll();
            }

            else if (choice == "5")
            {
                Console.WriteLine($"Total contacts in all address books: {addressBookMain.GetTotalContactCount()}");
            }
            else if (choice == "6")
            {
                Console.WriteLine("Enter city to search: ");
                string city = Console.ReadLine();
                addressBookMain.SearchByCity(city);
            }
            else if (choice == "7")
            {
                Console.WriteLine("Enter state to search: ");
                string state = Console.ReadLine();
                addressBookMain.SearchByState(state);
            }

            else if (choice == "8")
            {
                addressBook1.ViewByCityOrState();

            }

            else if (choice == "9")
            {
                addressBook1.GetCountByCityOrState();
            }
            else if (choice == "10")
            {
                addressBookMain.SortByName();
            }
            else if (choice == "11")
            {
                Console.WriteLine("Sort contacts by:");
                Console.WriteLine("1- City");
                Console.WriteLine("2- State");
                Console.WriteLine("3- Zip");

                string sortChoice = Console.ReadLine();

                if (sortChoice == "1")
                {
                    addressBookMain.SortByCity();
                }
                else if (sortChoice == "2")
                {
                    addressBookMain.SortByState();
                }
                else if (sortChoice == "3")
                {
                    addressBookMain.SortByZip();
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
            else if (choice == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Choice!");
            }
        }
    }
    }