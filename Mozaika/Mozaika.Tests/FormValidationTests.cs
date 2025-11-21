using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mozaika.Tests
{
    [TestClass]
    public class FormValidationTests
    {
        [TestMethod]
        public void EmailValidation_ValidEmail_ReturnsTrue()
        {
            // Arrange
            string email = "test@example.com";

            // Act
            bool isValid = IsValidEmail(email);

            // Assert
            Assert.IsTrue(isValid, "Корректный email должен проходить валидацию");
        }

        [TestMethod]
        public void EmailValidation_InvalidEmail_ReturnsFalse()
        {
            // Arrange
            string email = "invalid-email";

            // Act
            bool isValid = IsValidEmail(email);

            // Assert
            Assert.IsFalse(isValid, "Некорректный email не должен проходить валидацию");
        }

        [TestMethod]
        public void PhoneValidation_RussianPhone_ReturnsTrue()
        {
            // Arrange
            string phone = "+79991234567";

            // Act
            bool isValid = IsValidPhone(phone);

            // Assert
            Assert.IsTrue(isValid, "Российский номер телефона должен проходить валидацию");
        }

        // Вспомогательные методы валидации
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Простая валидация российских номеров
            return phone.StartsWith("+7") && phone.Length == 12 && phone.Substring(1).All(char.IsDigit);
        }
    }
}