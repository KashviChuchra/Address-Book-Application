using AddressBookApp.src.AddressBookApp.Exceptions;
using AddressBookApp.src.AddressBookApp.Models;
using AddressBookApp.src.AddressBookApp.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AddressBookApp.src.AddressBookApp.Services
{
    internal class AddressBook
    {
        private List<Contact> contacts = new();
        public IReadOnlyList<Contact> Contacts
        {
            get
            {
                return contacts;
            }
        }
        public void AddContact(Contact c)
        {
            contacts.Add(c);
       
        }
        public void PrintAll()
        {
            foreach(Contact contact in contacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void EditContact(string firstName, string lastName, ContactValidator validator)
        {
            Contact contact = contacts.FirstOrDefault(c => c.FirstName== firstName && c.LastName==lastName);

            if (contact==null)
            {
                Console.WriteLine("Contact not Found");
                return;
            }
            Console.WriteLine($"Editing: {contact}");

            Console.WriteLine("Enter new first name (or press Enter to keep):");
            string newFirstName = Console.ReadLine();

            Console.WriteLine("Enter new last name (or press Enter to keep):");
            string newLastName = Console.ReadLine();

            Console.WriteLine("Enter new address  (or press Enter to keep):");
            string newAddress = Console.ReadLine();

            Console.WriteLine("Enter new city (or press Enter to keep):");
            string newCity = Console.ReadLine();

            Console.WriteLine("Enter new state (or press Enter to keep):");
            string newState = Console.ReadLine();

            Console.WriteLine("Enter new zip (or press Enter to keep):");
            string newZip = Console.ReadLine();

            Console.WriteLine("Enter new phone number (or press Enter to keep):");
            string newPhoneNumber = Console.ReadLine();

            Console.WriteLine("Enter new email (or press Enter to keep):");
            string newEmail = Console.ReadLine();

            string firstNameValue = string.IsNullOrWhiteSpace(newFirstName) ? contact.FirstName: newFirstName;
            string lastNameValue = string.IsNullOrWhiteSpace(newLastName) ? contact.LastName : newLastName;
            string addressValue = string.IsNullOrWhiteSpace(newAddress) ? contact.Address : newAddress;
            string cityValue = string.IsNullOrWhiteSpace(newCity) ? contact.City : newCity;
            string stateValue = string.IsNullOrWhiteSpace(newState) ? contact.State : newState;
            string zipValue = string.IsNullOrWhiteSpace(newZip) ? contact.Zip : newZip;
            string phoneNumberValue = string.IsNullOrWhiteSpace(newPhoneNumber) ? contact.PhoneNumber : newPhoneNumber;
            string emailValue = string.IsNullOrWhiteSpace(newEmail) ? contact.Email : newEmail;

            Contact newUpdatedContact = new Contact(firstNameValue, lastNameValue, addressValue, cityValue, stateValue, zipValue, phoneNumberValue, emailValue);

            try
            {
                validator.Validate(newUpdatedContact);
                contact.FirstName = newUpdatedContact.FirstName;
                contact.LastName = newUpdatedContact.LastName;
                contact.Address = newUpdatedContact.Address;
                contact.City = newUpdatedContact.City;
                contact.State = newUpdatedContact.State;
                contact.Zip = newUpdatedContact.Zip;
                contact.PhoneNumber = newUpdatedContact.PhoneNumber;
                contact.Email = newUpdatedContact.Email;


                Console.WriteLine("Contact updated");
            }
            catch (InvalidContactException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

    }
}
