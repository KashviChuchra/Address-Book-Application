using AddressBookApp.src.AddressBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp.src.AddressBookApp.Services
{
    public class AddressBookMain
    {
        private List<AddressBook> books = new();

        public void AddAddressBook(AddressBook book)
        {
            books.Add(book);
        }
        public int GetTotalContactCount()
        {
            return books.Sum(b => b.Contacts.Count);

        }

        public void SearchByCity(string city)
        {
            var matches= books.SelectMany(b => b.Contacts).Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
            if (matches.Count == 0)
            {
                Console.WriteLine("No contacts found");
                return;
            }
            Console.WriteLine($"Found {matches.Count} contact(s): ");
            foreach (Contact contact in matches)
            {
                Console.WriteLine(contact);
            }
        }
        public void SearchByState(string state)
        {
            var matches = books.SelectMany(b => b.Contacts).Where(c => c.State.Equals(state, StringComparison.OrdinalIgnoreCase)).ToList();
            if (matches.Count == 0)
            {
                Console.WriteLine("No contacts found");
                return;
            }
            Console.WriteLine($"Found {matches.Count} contact(s): ");
            foreach (Contact contact in matches)
            {
                Console.WriteLine(contact);
            }
        }
        public void SortByName()
        {
            var sortedContacts = books.SelectMany(b => b.Contacts).OrderBy(c => c.FirstName).ThenBy(c => c.LastName);

            foreach (var contact in sortedContacts)
            {
                Console.WriteLine(contact);
            }
        }


    }
}
