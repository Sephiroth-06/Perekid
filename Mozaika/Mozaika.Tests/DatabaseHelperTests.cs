using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozaika.Models;
using System;

namespace Mozaika.Tests
{
    [TestClass]
    public class DatabaseHelperTests
    {
        [TestMethod]
        public void HashPassword_ValidPassword_ReturnsHashedString()
        {
            // Arrange
            string password = "testpassword123";

            // Act
            string hashed = DatabaseHelper.HashPassword(password);

            // Assert
            Assert.IsNotNull(hashed, "Хэш не должен быть null");
            Assert.IsFalse(string.IsNullOrEmpty(hashed), "Хэш не должен быть пустым");
            Assert.AreNotEqual(password, hashed, "Хэш должен отличаться от оригинального пароля");
            Assert.AreEqual(64, hashed.Length, "Хэш SHA256 должен быть 64 символа");
        }

        [TestMethod]
        public void HashPassword_SamePassword_ReturnsSameHash()
        {
            // Arrange
            string password = "testpassword";

            // Act
            string hash1 = DatabaseHelper.HashPassword(password);
            string hash2 = DatabaseHelper.HashPassword(password);

            // Assert
            Assert.AreEqual(hash1, hash2, "Один и тот же пароль должен давать одинаковый хэш");
        }

        [TestMethod]
        public void HashPassword_DifferentPasswords_ReturnDifferentHashes()
        {
            // Arrange
            string password1 = "password1";
            string password2 = "password2";

            // Act
            string hash1 = DatabaseHelper.HashPassword(password1);
            string hash2 = DatabaseHelper.HashPassword(password2);

            // Assert
            Assert.AreNotEqual(hash1, hash2, "Разные пароли должны давать разные хэши");
        }

        [TestMethod]
        public void HashPassword_EmptyPassword_ReturnsValidHash()
        {
            // Arrange
            string password = "";

            // Act
            string hashed = DatabaseHelper.HashPassword(password);

            // Assert
            Assert.IsNotNull(hashed, "Хэш пустого пароля не должен быть null");
            Assert.AreEqual(64, hashed.Length, "Хэш пустого пароля должен быть 64 символа");
        }

        [TestMethod]
        public void HashPassword_NullPassword_ThrowsException()
        {
            // Arrange
            string password = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                DatabaseHelper.HashPassword(password));
        }
    }
}