using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acidic.DomainDrivenDesign.UnitTests.TinyValue
{
    [TestClass]
    public class TinyValuePropertyRegistrationTests
    {
        [TestMethod]
        public void WHEN_OneValue_WHILE_InstanceCreated_THEN_ReturnCorrectHashCode()
        {
            // Arrange
            const int fieldValue = 1337;

            var tinyValue = new TinyValue<int>(fieldValue);

            var expectedHashCode = 352033288;
            expectedHashCode = expectedHashCode * -1521134295 + fieldValue.GetHashCode();

            // Act
            var actualHashCode = tinyValue.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }

        [TestMethod]
        public void WHEN_TwoValues_WHILE_InstanceCreated_THEN_ReturnCorrectHashCode()
        {
            // Arrange
            const int field1Value = 1337;
            const string field2Value = "value";

            var tinyValue = new TinyValue<int, string>(field1Value, field2Value);

            var expectedHashCode = 352033288;
            expectedHashCode = expectedHashCode * -1521134295 + field1Value.GetHashCode();
            expectedHashCode = expectedHashCode * -1521134295 + field2Value.GetHashCode();

            // Act
            var actualHashCode = tinyValue.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }

        [TestMethod]
        public void WHEN_ThreeValues_WHILE_InstanceCreated_THEN_ReturnCorrectHashCode()
        {
            // Arrange
            const int field1Value = 1337;
            const string field2Value = "value";
            const double field3Value = 42.42;

            var tinyValue = new TinyValue<int, string, double>(field1Value, field2Value, field3Value);

            var expectedHashCode = 352033288;
            expectedHashCode = expectedHashCode * -1521134295 + field1Value.GetHashCode();
            expectedHashCode = expectedHashCode * -1521134295 + field2Value.GetHashCode();
            expectedHashCode = expectedHashCode * -1521134295 + field3Value.GetHashCode();

            // Act
            var actualHashCode = tinyValue.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }

        [TestMethod]
        public void WHEN_FourValues_WHILE_InstanceCreated_THEN_ReturnCorrectHashCode()
        {
            // Arrange
            const int field1Value = 1337;
            const string field2Value = "value";
            const double field3Value = 42.42;
            const float field4Value = 42.1337f;

            var tinyValue = new TinyValue<int, string, double, float>(field1Value, field2Value, field3Value, field4Value);

            var expectedHashCode = 352033288;
            expectedHashCode = expectedHashCode * -1521134295 + field1Value.GetHashCode();
            expectedHashCode = expectedHashCode * -1521134295 + field2Value.GetHashCode();
            expectedHashCode = expectedHashCode * -1521134295 + field3Value.GetHashCode();
            expectedHashCode = expectedHashCode * -1521134295 + field4Value.GetHashCode();

            // Act
            var actualHashCode = tinyValue.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }

        [TestMethod]
        public void WHEN_FiveValues_WHILE_InstanceCreated_THEN_ReturnCorrectHashCode()
        {
            // Arrange
            const int field1Value = 1337;
            const string field2Value = "value";
            const double field3Value = 42.42;
            const float field4Value = 42.1337f;
            const int field5Value = 3;

            var tinyValue = new TinyValue<int, string, double, float, int>(field1Value, field2Value, field3Value, field4Value, field5Value);

            var expectedHashCode = 352033288;
            expectedHashCode = expectedHashCode * -1521134295 + field1Value.GetHashCode();
            expectedHashCode = expectedHashCode * -1521134295 + field2Value.GetHashCode();
            expectedHashCode = expectedHashCode * -1521134295 + field3Value.GetHashCode();
            expectedHashCode = expectedHashCode * -1521134295 + field4Value.GetHashCode();
            expectedHashCode = expectedHashCode * -1521134295 + field5Value.GetHashCode();

            // Act
            var actualHashCode = tinyValue.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }
    }
}