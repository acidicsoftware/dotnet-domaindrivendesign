using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            const int fieldValue = 1337;

            var value = new SingleFieldValue(fieldValue);

            var expectedHashCode = 352033288;
            expectedHashCode = expectedHashCode * -1521134295 + fieldValue.GetHashCode();

            // Act
            var actualHashCode = value.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }

        [TestMethod]
        public void WHEN_CalculatingHashCode_WHILE_ValueHasMultipleValues_THEN_ReturnHashCode()
        {
            // Arrange
            const int field1Value = 1337;
            const string field2Value = "value";

            var value = new MultipleFieldsValue(field1Value, field2Value);

            var expectedHashCode = 352033288;
            expectedHashCode = expectedHashCode * -1521134295 + field1Value.GetHashCode();
            expectedHashCode = expectedHashCode * -1521134295 + field2Value.GetHashCode();

            // Act
            var actualHashCode = value.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }
    }
}