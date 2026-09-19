using NUnit.Framework;
using AddressBookApp.src.AddressBookApp.Models;
using AddressBookApp.src.AddressBookApp.Validation;
using AddressBookApp.src.AddressBookApp.Exceptions;

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
        public void IsValidName_ValidName_ReturnsTrue()
        {
            bool result = validator.IsValidName("Kashvi");
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidName_LowercaseName_ReturnsFalse()
        {
            bool result = validator.IsValidName("kashvi");
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsValidZip_ValidZip_ReturnsTrue()
        {
            bool result = validator.IsValidZip("136027");
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidZip_InvalidZip_ReturnsFalse()
        {
            bool result = validator.IsValidZip("12345");
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsValidPhone_ValidPhone_ReturnsTrue()
        {
            bool result = validator.IsValidPhone("9876543210");
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidPhone_InvalidPhone_ReturnsFalse()
        {
            bool result = validator.IsValidPhone("987654321");
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsValidEmail_ValidEmail_ReturnsTrue()
        {
            bool result = validator.IsValidEmail("kashvi@gmail.com");
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidEmail_InvalidEmail_ReturnsFalse()
        {
            bool result = validator.IsValidEmail("kashvi@gmail");
            Assert.That(result, Is.False);
        }

        [Test]
        public void Validate_InvalidFirstName_ThrowsException()
        {
            Contact contact = new Contact("k", "Chuchra", "Model Town", "Kaithal", "Haryana", "136027", "9876543210", "kashvi@gmail.com");
            Assert.Throws<InvalidContactException>(() => validator.Validate(contact));
        }

        [Test]
        public void Validate_InvalidPhone_ThrowsException()
        {
            Contact contact = new Contact("Kashvi", "Chuchra", "Model Town", "Kaithal", "Haryana", "136027", "987654321", "kashvi@gmail.com");
            Assert.Throws<InvalidContactException>(() => validator.Validate(contact));
        }
    }
}
