using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp.src.AddressBookApp.Services
{
    internal class AddressBookMain
    {
        private List<AddressBook> books = new();

        public void AddAddressBook(AddressBook book)
        {
            books.Add(book);
        }
        public int CountAllContacts()
        {
            return books.Sum(b => b.Contacts.Count);

        }
    }
}
