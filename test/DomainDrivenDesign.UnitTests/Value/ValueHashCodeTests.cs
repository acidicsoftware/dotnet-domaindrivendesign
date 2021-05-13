using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acidic.DomainDrivenDesign.UnitTests.Value
{
    [TestClass]
    public class ValueHashCodeTests
    {
        [TestMethod]
        public void WHEN_CalculatingHashCode_WHILE_ValueHasNoFields_THEN_ReturnHashCode()
        {
            // Arrange
            var value = new NoFieldsValue();

            const int expectedHashCode = 352033288;

            // Act
            var actualHashCode = value.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }

        [TestMethod]
        public void WHEN_CalculatingHashCode_WHILE_ValueHasSingleValue_THEN_ReturnHashCode()
        {
            // Arrange
            const int valueField = 1337;

            var value = new SingleFieldValue(valueField);

            var expectedHashCode = 352033288;
            expectedHashCode = expectedHashCode * -1521134295 + valueField.GetHashCode();

            // Act
            var actualHashCode = value.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }

        [TestMethod]
        public void WHEN_CalculatingHashCode_WHILE_ValueHasMultipleValues_THEN_ReturnHashCode()
        {
            // Arrange
            const int valueField1 = 1337;
            const string valueField2 = "value";

            var value = new MultipleFieldsValue(valueField1, valueField2);

            var expectedHashCode = 352033288;
            expectedHashCode = expectedHashCode * -1521134295 + valueField1.GetHashCode();
            expectedHashCode = expectedHashCode * -1521134295 + valueField2.GetHashCode();

            // Act
            var actualHashCode = value.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }
    }
}