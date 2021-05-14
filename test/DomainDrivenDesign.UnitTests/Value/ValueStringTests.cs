using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value
{
    [TestClass]
    public class ValueStringTests
    {
        [TestMethod]
        public void WHEN_ConvertingToString_WHILE_ValueHasNoFields_THEN_ReturnEmptyString()
        {
            // Arrange
            var expectedFieldValue = string.Empty;

            var value = new NoFieldsValue();

            // Act
            var actualFieldValue = value.ToString();

            // Assert
            Assert.AreEqual(expectedFieldValue, actualFieldValue);
        }

        [TestMethod]
        public void WHEN_ConvertingToString_WHILE_ValueHasSingleField_THEN_ReturnFieldString()
        {
            // Arrange
            const int fieldValue = 42;

            var expectedValueString = fieldValue.ToString();

            var value = new SingleFieldValue(fieldValue);

            // Act
            var actualValueString = value.ToString();

            // Assert
            Assert.AreEqual(expectedValueString, actualValueString);
        }

        [TestMethod]
        public void WHEN_ConvertingToString_WHILE_ValueHasMultipleFields_THEN_ReturnConcatenatedFieldsString()
        {
            // Arrange
            const int field1Value = 42;
            const string field2Value = "value";

            var expectedValueString = $"{field1Value.ToString()} - {field2Value.ToString()}";

            var value = new MultipleFieldsValue(field1Value, field2Value);

            // Act
            var actualValueString = value.ToString();

            // Assert
            Assert.AreEqual(expectedValueString, actualValueString);
        }
    }
}