using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acidic.DomainDrivenDesign.UnitTests.TinyValue
{
    [TestClass]
    public sealed class InstantiationTests
    {
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("Field 1 Value")]
        public void WHILE_TinyHasOneField_THEN_FieldsAreSet(string expectedField1Value)
        {
            // Arrange

            // Act
            var tinyValue = new Mock<TinyValue<string>>(expectedField1Value).Object;

            // Assert
            Assert.AreEqual(expectedField1Value, tinyValue.Value);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("Field 1 Value", "Field 2 Value")]
        public void WHILE_TinyHasTwoFields_THEN_FieldsAreSet(string expectedField1Value, string expectedField2Value)
        {
            // Arrange

            // Act
            var tinyValue = new Mock<TinyValue<string, string>>(expectedField1Value, expectedField2Value).Object;

            // Assert
            Assert.AreEqual(expectedField1Value, tinyValue.Value1);
            Assert.AreEqual(expectedField2Value, tinyValue.Value2);
        }

        [DataTestMethod]
        [DataRow(null, null, null)]
        [DataRow("Field 1 Value", "Field 2 Value", "Field 3 Value")]
        public void WHILE_TinyHasThreeFields_THEN_FieldsAreSet(string expectedField1Value, string expectedField2Value, string expectedField3Value)
        {
            // Arrange

            // Act
            var tinyValue = new Mock<TinyValue<string, string, string>>(expectedField1Value, expectedField2Value, expectedField3Value).Object;

            // Assert
            Assert.AreEqual(expectedField1Value, tinyValue.Value1);
            Assert.AreEqual(expectedField2Value, tinyValue.Value2);
            Assert.AreEqual(expectedField3Value, tinyValue.Value3);
        }

        [DataTestMethod]
        [DataRow(null, null, null, null)]
        [DataRow("Field 1 Value", "Field 2 Value", "Field 3 Value", "Field 4 Value")]
        public void WHILE_TinyHasFourFields_THEN_FieldsAreSet(string expectedField1Value, string expectedField2Value, string expectedField3Value, string expectedField4Value)
        {
            // Arrange

            // Act
            var tinyValue = new Mock<TinyValue<string, string, string, string>>(expectedField1Value, expectedField2Value, expectedField3Value, expectedField4Value).Object;

            // Assert
            Assert.AreEqual(expectedField1Value, tinyValue.Value1);
            Assert.AreEqual(expectedField2Value, tinyValue.Value2);
            Assert.AreEqual(expectedField3Value, tinyValue.Value3);
            Assert.AreEqual(expectedField4Value, tinyValue.Value4);
        }

        [DataTestMethod]
        [DataRow(null, null, null, null, null)]
        [DataRow("Field 1 Value", "Field 2 Value", "Field 3 Value", "Field 4 Value", "Field 5 Value")]
        public void WHILE_TinyHasFiveFields_THEN_FieldsAreSet(string expectedField1Value, string expectedField2Value, string expectedField3Value, string expectedField4Value, string expectedField5Value)
        {
            // Arrange

            // Act
            var tinyValue = new Mock<TinyValue<string, string, string, string, string>>(expectedField1Value, expectedField2Value, expectedField3Value, expectedField4Value, expectedField5Value).Object;

            // Assert
            Assert.AreEqual(expectedField1Value, tinyValue.Value1);
            Assert.AreEqual(expectedField2Value, tinyValue.Value2);
            Assert.AreEqual(expectedField3Value, tinyValue.Value3);
            Assert.AreEqual(expectedField4Value, tinyValue.Value4);
            Assert.AreEqual(expectedField5Value, tinyValue.Value5);
        }
    }
}