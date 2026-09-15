using AddressBookApp.src.AddressBookApp.Exceptions;
using AddressBookApp.src.AddressBookApp.Models;
using AddressBookApp.src.AddressBookApp.Validation;

namespace AddressBookTests
{
    public class ContactValidatorTests
    {
        private ContactValidator validator;
        [SetUp]
        public void Setup()
        {
            validator = new ContactValidator();
        }

        [Test]
        public void ValidContact_ShouldPass()
        {
            Contact contact = new Contact("Kashvi", "Chuchra", "Gobind Colony, Dhand Road", "Kaithal", "Haryana", "136027", "7777555567", "kashvi@gmail.com");
            Assert.DoesNotThrow(() => validator.Validate(contact));
        }

        [Test]
        public void InValidContact_ShouldThrowError()
        {
            Contact contact = new Contact("Kashvi", "Chuchra", "Gobind Colony, Dhand Road", "Kaithal", "Haryana", "136027", "777755556", "kashvi@gmail.com");
            Assert.Throws<InvalidContactException>(() => validator.Validate(contact));
        }

        [Test]
        public void InvalidEmail()
        {
            Contact contact = new Contact("Kashvi", "Chuchra", "Gobind Colony, Dhand Road", "Kaithal", "Haryana", "136027", "777755556", "kashv@");
            Assert.Throws<InvalidContactException>(() => validator.Validate(contact));
        }
    }
}
