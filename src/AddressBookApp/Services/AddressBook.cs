using AddressBookApp.src.AddressBookApp.Models;
using AddressBookApp.src.AddressBookApp.Validation;
using System;
using System.Collections.Generic;
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
    }
}
