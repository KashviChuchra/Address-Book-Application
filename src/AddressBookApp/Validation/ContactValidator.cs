using AddressBookApp.src.AddressBookApp.Exceptions;
using AddressBookApp.src.AddressBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AddressBookApp.src.AddressBookApp.Validation
{
    public class ContactValidator
    {
        public bool IsValidName(string name)
        {
            // Starts with a capital letter, minimum 3 characters → ^[AZ][a-zA-Z]{2,}$
            string pattern = @"^[A-Z][a-zA-Z]{2,}$";
            bool isValid = Regex.IsMatch(name, pattern);
            return isValid;
        }
        public bool IsValidAddressPart(string value)
        {
            string pattern = @"^.{4,}$";
            bool isValid = Regex.IsMatch(value, pattern);
            return isValid;
        }
        public bool IsValidZip(string zip)
        {
            string pattern = @"^[0-9]{6}$";
            bool isValid = Regex.IsMatch(zip, pattern);
            return isValid;
        }
        public bool IsValidPhone(string phone)
        {
            string pattern = @"^[0-9]{10}$";
            bool isValid = Regex.IsMatch(phone, pattern);
            return isValid;
        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            bool isValid = Regex.IsMatch(email, pattern);
            return isValid;
        }

        public void Validate(Contact c)
        {
            if (!IsValidName(c.FirstName)) throw new InvalidContactException("First name must start with a capital letter and be at least 3 characters.");
            if (!IsValidName(c.LastName)) throw new InvalidContactException("Last name must start with a capital letter and be at least 3 characters.");
            if (!IsValidAddressPart(c.Address)) throw new InvalidContactException("Address must contain minimum 4 characters");
            if (!IsValidAddressPart(c.City)) throw new InvalidContactException("City must contain minimum 4 characters");
            if (!IsValidAddressPart(c.State)) throw new InvalidContactException("State must contain minimum 4 characters");
            if (!IsValidZip(c.Zip)) throw new InvalidContactException("Zip must contains  6 digits");
            if (!IsValidPhone(c.PhoneNumber)) throw new InvalidContactException("Phone Number must contains 10 digits.");
            if (!IsValidEmail(c.Email)) throw new InvalidContactException("Email is not valid");
        }
    }
}
