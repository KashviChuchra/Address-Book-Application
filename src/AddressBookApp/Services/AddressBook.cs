using AddressBookApp.src.AddressBookApp.Exceptions;
using AddressBookApp.src.AddressBookApp.Models;
using AddressBookApp.src.AddressBookApp.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AddressBookApp.src.AddressBookApp.Services
{
    public class AddressBook
    {
        private List<Contact> contacts = new();
        public IReadOnlyList<Contact> Contacts
        {
            get
            {
                return contacts;
            }
        }
        public bool AddContact(Contact contact)
        {
            bool exists = contacts.Any(c =>c.FirstName.Equals(contact.FirstName, StringComparison.OrdinalIgnoreCase) && c.LastName.Equals(contact.LastName, StringComparison.OrdinalIgnoreCase));
            if (exists)
            {
                Console.WriteLine($"Contact '{contact.FirstName} {contact.LastName}' already exists. Duplicate not added.");
                return false;
            }
            contacts.Add(contact);
            return true;
       
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
            var contact = contacts.FirstOrDefault(c =>c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

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
                bool duplicate = contacts.Any(c =>c != contact && c.FirstName.Equals(newUpdatedContact.FirstName, StringComparison.OrdinalIgnoreCase) &&c.LastName.Equals(newUpdatedContact.LastName, StringComparison.OrdinalIgnoreCase));

                if (duplicate)
                {
                    Console.WriteLine("Contact Name Already exists");
                    return;
                }
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

        public void DeleteContact(string firstName, string lastName)
        {
            var contact = contacts.FirstOrDefault(c =>c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
            if (contact == null)
            {
                Console.WriteLine("Contact Not Found");
                return;
            }
            contacts.Remove(contact);
            Console.WriteLine("Contact Deleted");
        }

        public void ViewByCityOrState()
        {
            var matches1 = contacts.GroupBy(c => c.City,StringComparer.OrdinalIgnoreCase).ToList();
            if (matches1.Count == 0)
            {
                Console.WriteLine("No person found.");
                return;
            }

            Console.WriteLine($"--- By City ---");
            foreach (var group in matches1)
            {
                Console.WriteLine($"{group.Key}:");
                
                foreach(Contact contact in group)
                {
                    Console.WriteLine(" "+contact.FirstName + " " + contact.LastName);

                }
            }

            var matches = contacts.GroupBy(c => c.State,StringComparer.OrdinalIgnoreCase).ToList();
            if (matches.Count == 0)
            {
                Console.WriteLine("No person found.");
                return;
            }

            Console.WriteLine($"--- By State ---");
            foreach (var group in matches)
            {
                Console.WriteLine($"{group.Key}:");

                foreach (Contact contact in group)
                {
                    Console.WriteLine(" " + contact.FirstName + " " + contact.LastName);
                }
            }

        }

        public void GetCountByCityOrState()
        {
            
            var cityMatches = contacts.GroupBy(c => c.City,StringComparer.OrdinalIgnoreCase).Select(g => (City:g.Key, Count:g.Count())).ToList();
            var stateMatches = contacts.GroupBy(c => c.State, StringComparer.OrdinalIgnoreCase).Select(g => (State: g.Key, Count: g.Count())).ToList();

            if (cityMatches.Count == 0 && stateMatches.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }
            Console.WriteLine("Per City: ");
            foreach (var i in cityMatches)
            {
                Console.WriteLine($"{i.City}={i.Count}");
            }

            Console.WriteLine();

            Console.WriteLine("Per state: ");
            foreach (var i in stateMatches)
            {
                Console.WriteLine($"{i.State}={i.Count}");

            }

        }

    }
}
