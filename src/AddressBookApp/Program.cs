using AddressBookApp.src.AddressBookApp.Exceptions;
using AddressBookApp.src.AddressBookApp.Models;
using AddressBookApp.src.AddressBookApp.Validation;
using System;
using System.ComponentModel.DataAnnotations;
namespace AddressBookApp;

class Program
{
    public static void Main(string[] args)
    {
        Contact contact1 = new Contact("Kashvi", "Chuchra", "#796/11, Gobind Colony, Dhand Road","Kaithal", "Haryana","136027", "09996265606","chuchrakashvi@gmail.com");
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
    }
}