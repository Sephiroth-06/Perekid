using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozaika.Models;

namespace Mozaika.Tests
{
    [TestClass]
    public class ProductionCalculatorTests
    {
        private ProductionCalculator calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            calculator = new ProductionCalculator();
        }

        [TestMethod]
        public void CalculateProductQuantity_ValidData_ReturnsPositiveQuantity()
        {
            // Arrange
            string productType = "Напольная плитка";
            string materialType = "Сырье";
            int rawMaterialQuantity = 1000;
            double length = 0.3;
            double width = 0.3;

            // Act
            int result = calculator.CalculateProductQuantity(productType, materialType,
                rawMaterialQuantity, length, width);

            // Assert
            Assert.IsTrue(result >= 0, "Результат расчета должен быть неотрицательным");
        }

        [TestMethod]
        public void CalculateProductQuantity_ZeroRawMaterial_ReturnsZero()
        {
            // Arrange
            string productType = "Напольная плитка";
            string materialType = "Сырье";
            int rawMaterialQuantity = 0;
            double length = 0.3;
            double width = 0.3;

            // Act
            int result = calculator.CalculateProductQuantity(productType, materialType,
                rawMaterialQuantity, length, width);

            // Assert
            Assert.AreEqual(0, result, "При нулевом сырье результат должен быть 0");
        }

        [TestMethod]
        public void CalculateProductQuantity_NegativeParameters_ReturnsError()
        {
            // Arrange
            string productType = "Напольная плитка";
            string materialType = "Сырье";
            int rawMaterialQuantity = -100;
            double length = -0.3;
            double width = -0.3;

            // Act
            int result = calculator.CalculateProductQuantity(productType, materialType,
                rawMaterialQuantity, length, width);

            // Assert
            Assert.AreEqual(-1, result, "При отрицательных параметрах должен возвращаться -1");
        }

        [TestMethod]
        public void CalculateProductQuantity_EmptyProductType_ReturnsError()
        {
            // Arrange
            string productType = "";
            string materialType = "Сырье";
            int rawMaterialQuantity = 1000;
            double length = 0.3;
            double width = 0.3;

            // Act
            int result = calculator.CalculateProductQuantity(productType, materialType,
                rawMaterialQuantity, length, width);

            // Assert
            Assert.AreEqual(-1, result, "При пустом типе продукции должен возвращаться -1");
        }

        [TestMethod]
        public void CalculateProductQuantity_EmptyMaterialType_ReturnsError()
        {
            // Arrange
            string productType = "Напольная плитка";
            string materialType = "";
            int rawMaterialQuantity = 1000;
            double length = 0.3;
            double width = 0.3;

            // Act
            int result = calculator.CalculateProductQuantity(productType, materialType,
                rawMaterialQuantity, length, width);

            // Assert
            Assert.AreEqual(-1, result, "При пустом типе материала должен возвращаться -1");
        }
    }
}
    