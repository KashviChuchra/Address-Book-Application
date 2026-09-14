using AddressBookApp.src.AddressBookApp.Exceptions;
using AddressBookApp.src.AddressBookApp.Models;
using AddressBookApp.src.AddressBookApp.Services;
using AddressBookApp.src.AddressBookApp.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
namespace AddressBookApp;

class Program
{
    public static void Main(string[] args)
    {
        Contact contact1 = new Contact("Kashvi", "Chuchra", "#796/11, Gobind Colony, Dhand Road","Kaithal", "Haryana","136027", "9996265606","chuchrakashvi@gmail.com");
        Console.WriteLine(contact1.ToString());
        ContactValidator validator = new ContactValidator();
        try
        {
            validator.Validate(contact1);
       }
        catch (InvalidContactException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        // ---------------UC3 + UC4  +UC5 +UC6-----------------------------------
        AddressBook addressBook1 = new AddressBook();
        addressBook1.AddContact(contact1);
        addressBook1.AddContact(new Contact("Hargun", "Singh", "Dugri", "Ludhiana", "Punjab", "123456", "111111111", "hargun@gmail.com"));
        addressBook1.AddContact(new Contact("Aman", "Deep", "Model Town", "Ludhiana", "Punjab", "141002", "222222222", "aman@gmail.com"));
        addressBook1.AddContact(new Contact("Sukhman", "Preet", "Sarabha Nagar", "Ludhiana", "Punjab", "141001", "333333333", "sukhman@gmail.com"));
        addressBook1.AddContact(new Contact("Navjot", "Kaur", "Sector 34", "Chandigarh", "Punjab", "160022", "444444444", "navjot@gmail.com"));
        addressBook1.AddContact(new Contact("Gurpreet", "Singh", "Phase 3B2", "Mohali", "Punjab", "160059", "555555555", "gurpreet@gmail.com"));
        AddressBook addressBook2 = new AddressBook();
        addressBook2.AddContact(contact1);
        addressBook2.AddContact(contact1);

        AddressBookMain addressBookMain = new AddressBookMain();
        addressBookMain.AddAddressBook(addressBook1);
        addressBookMain.AddAddressBook(addressBook2);


        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1- Add Contact");
            Console.WriteLine("2- Show All Contacts");
            Console.WriteLine("3- Edit Contacts");
            Console.WriteLine("4- Delete Contacts");
            Console.WriteLine("5- Count All Contacts");
            Console.WriteLine("6- Search Person");
            Console.WriteLine("7- View Contact");

            Console.WriteLine("0- Exit");
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

                    Contact contact2 = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);

                    validator.Validate(contact2);
                    bool added=addressBook1.AddContact(contact2);
                    if(added)   Console.WriteLine("Contact Added Successfully!");
                }
                catch (InvalidContactException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

            }
            else if (choice == "2")
            {
                addressBook1.PrintAll();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Enter first name to edit: ");
                string firstName1 = Console.ReadLine();
                Console.WriteLine("Enter last name to edit: ");
                string lastName1 = Console.ReadLine();
                addressBook1.EditContact(firstName1, lastName1,validator);
            }
            else if (choice == "4")
            {
                Console.WriteLine("Enter first name to delete: ");
                string firstName1 = Console.ReadLine();
                Console.WriteLine("Enter last name to delete: ");
                string lastName1 = Console.ReadLine();
                addressBook1.DeleteContact(firstName1, lastName1);
            }
            else if (choice == "5")
            {
                Console.WriteLine($"Total contacts in all address books: {addressBookMain.CountAllContacts()}");
            }
            else if (choice == "6")
            {
                while (true)
                {
                    Console.WriteLine("\nSearch Person by: ");
                    Console.WriteLine("a - City");
                    Console.WriteLine("b - State");
                    Console.WriteLine("exit - Exiting");

                    string choose = Console.ReadLine();
                    if (choose == "a")
                    {
                        Console.WriteLine("Enter city to search: ");
                        string city = Console.ReadLine();
                        addressBookMain.SearchByCity(city);
                    }
                    else if (choose == "b")
                    {
                        Console.WriteLine("Enter state to search: ");
                        string state = Console.ReadLine();
                        addressBookMain.SearchByState(state);
                    }
                    else if (choose == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Operation! Exiting!");
                        break;
                    }
                }
            }
            else if (choice == "7")
            {
                while (true)
                {
                    Console.WriteLine("\nView Person by: ");
                    Console.WriteLine("a - City");
                    Console.WriteLine("b - State");
                    Console.WriteLine("exit - Exiting");

                    string choose = Console.ReadLine();
                    if (choose == "a")
                    {
                        Console.WriteLine("Enter city: ");
                        addressBook1.GroupByCity();
                    }
                    else if (choose == "b")
                    {
                        Console.WriteLine("Enter state: ");
                        addressBook1.GroupByState();

                    }
                    else if (choose == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Operation! Exiting!");
                        break;
                    }
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