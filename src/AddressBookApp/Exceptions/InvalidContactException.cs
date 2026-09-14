using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp.src.AddressBookApp.Exceptions
{
    public class InvalidContactException:Exception
    {
        public InvalidContactException(string message): base(message) { }
    }
}
