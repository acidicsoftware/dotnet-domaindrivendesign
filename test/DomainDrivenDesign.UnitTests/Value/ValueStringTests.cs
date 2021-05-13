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
            var expectedValueString = string.Empty;

            var value = new NoFieldsValue();

            // Act
            var actualValueString = value.ToString();

            // Assert
            Assert.AreEqual(expectedValueString, actualValueString);
        }

        [TestMethod]
        public void WHEN_ConvertingToString_WHILE_ValueHasSingleField_THEN_ReturnFieldString()
        {
            // Arrange
            const int vauleField = 42;

            var expectedValueString = vauleField.ToString();

            var value = new SingleFieldValue(vauleField);

            // Act
            var actualValueString = value.ToString();

            // Assert
            Assert.AreEqual(expectedValueString, actualValueString);
        }

        [TestMethod]
        public void WHEN_ConvertingToString_WHILE_ValueHasMultipleFields_THEN_ReturnConcatenatedFieldsString()
        {
            // Arrange
            const int vauleField1 = 42;
            const string valueField2 = "value";

            var expectedValueString = $"{vauleField1.ToString()} - {valueField2.ToString()}";

            var value = new MultipleFieldsValue(vauleField1, valueField2);

            // Act
            var actualValueString = value.ToString();

            // Assert
            Assert.AreEqual(expectedValueString, actualValueString);
        }
    }
}