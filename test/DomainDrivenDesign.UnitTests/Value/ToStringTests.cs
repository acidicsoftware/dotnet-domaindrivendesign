using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value
{
    [TestClass]
    public sealed class ToStringTests
    {
        [TestMethod]
        public void WHEN_ValueHasNoFields_THEN_ReturnEmptyString()
        {
            // Arrange
            const string expectedFieldValue = "";

            var value = new NoFieldsValue();

            // Act
            var actualFieldValue = value.ToString();

            // Assert
            Assert.AreEqual(expectedFieldValue, actualFieldValue);
        }

        [TestMethod]
        public void WHEN_ValueHasSingleField_THEN_ReturnFieldString()
        {
            // Arrange
            const string fieldValue = "Some awesome value";
            
            var expectedValueString = fieldValue;

            var value = new SingleFieldValue(fieldValue);

            // Act
            var actualValueString = value.ToString();

            // Assert
            Assert.AreEqual(expectedValueString, actualValueString);
        }

        [TestMethod]
        public void WHEN_ValueHasMultipleFields_THEN_ReturnConcatenatedFieldsString()
        {
            // Arrange
            const string field1Value = "Some awesome value";
            const string field2Value = "An even more awesome value";

            var expectedValueString = $"{field1Value} - {field2Value}";

            var value = new MultipleFieldsValue(field1Value, field2Value);

            // Act
            var actualValueString = value.ToString();

            // Assert
            Assert.AreEqual(expectedValueString, actualValueString);
        }
    }
}