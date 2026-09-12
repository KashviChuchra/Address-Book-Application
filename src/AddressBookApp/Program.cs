using AddressBookApp.src.AddressBookApp.Models;
using System;
namespace AddressBookApp;

class Program
{
    public static void Main(string[] args)
    {
        Contact contact1 = new Contact("Kashvi", "Chuchra", "#796/11, Gobind Colony, Dhand Road","Kaithal", "Haryana","136027", "9996265606","chuchrakashvi@gmail.com");
        Console.WriteLine(contact1.ToString());
    }
}