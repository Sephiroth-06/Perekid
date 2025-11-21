using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozaika.Models;

namespace Mozaika.Tests
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void HashPassword_AdminPassword_ReturnsCorrectHash()
        {
            // Arrange
            string adminPassword = "admin123";

            // Act
            string hashed = DatabaseHelper.HashPassword(adminPassword);

            // Assert
            Assert.IsNotNull(hashed);
            Assert.AreEqual("240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9",
                hashed.ToLower(), "Хэш пароля admin123 должен соответствовать ожидаемому");
        }

        [TestMethod]
        public void HashPassword_ManagerPassword_ReturnsValidHash()
        {
            // Arrange
            string managerPassword = "manager123";

            // Act
            string hashed = DatabaseHelper.HashPassword(managerPassword);

            // Assert
            Assert.IsNotNull(hashed);
            Assert.AreEqual(64, hashed.Length);
        }
    }
}