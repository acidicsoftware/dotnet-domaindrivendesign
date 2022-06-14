using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value
{
    [TestClass]
    public sealed class HashCodeCalculationTests
    {
        [TestMethod]
        public void WHILE_BothValuesHaveNoFields_THEN_HashCodesAreEquivalent()
        {
            // Arrange
            var value1 = new NoFieldsValue();
            var value2 = new NoFieldsValue();

            // Act
            var value1HashCode = value1.GetHashCode();
            var value2HashCode = value2.GetHashCode();

            // Assert
            Assert.AreEqual(value1HashCode, value2HashCode);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("Some value")]
        public void WHILE_BothValuesHaveSingleField_WHEN_FieldValuesAreSimilar_THEN_HashCodesAreEquivalent(string fieldValue)
        {
            // Arrange
            var value1 = new SingleFieldValue(fieldValue);
            var value2 = new SingleFieldValue(fieldValue);

            // Act
            var value1HashCode = value1.GetHashCode();
            var value2HashCode = value2.GetHashCode();

            // Assert
            Assert.AreEqual(value1HashCode, value2HashCode);
        }
        
        [DataTestMethod]
        [DataRow(null, "")]
        [DataRow("", "Some value")]
        [DataRow("Some value 1", "Some value 2")]
        public void WHILE_BothValuesHaveSingleField_WHEN_FieldValuesAreDifferent_THEN_HashCodesAreNotEquivalent(string fieldValue1, string fieldValue2)
        {
            // Arrange
            var value1 = new SingleFieldValue(fieldValue1);
            var value2 = new SingleFieldValue(fieldValue2);

            // Act
            var value1HashCode = value1.GetHashCode();
            var value2HashCode = value2.GetHashCode();

            // Assert
            Assert.AreNotEqual(value1HashCode, value2HashCode);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("Some value", "Some value")]
        public void WHILE_BothValuesHaveMultipleFields_WHEN_FieldValuesAreSimilar_THEN_HashCodesAreEquivalent(string field1Value, string field2Value)
        {
            // Arrange
            var value1 = new MultipleFieldsValue(field1Value, field2Value);
            var value2 = new MultipleFieldsValue(field1Value, field2Value);
            
            // Act
            var value1HashCode = value1.GetHashCode();
            var value2HashCode = value2.GetHashCode();

            // Assert
            Assert.AreEqual(value1HashCode, value2HashCode);
        }
        
        [DataTestMethod]
        [DataRow("", null, null, null)]
        [DataRow(null, "", null, null)]
        [DataRow(null, null, "", null)]
        [DataRow(null, null, null, "")]
        [DataRow("", "", null, null)]
        [DataRow(null, null, "", "")]
        [DataRow("", "", "", null)]
        [DataRow("", "", null, "")]
        [DataRow(null, "", "", "")]
        [DataRow("", null, "", "")]
        [DataRow("Some value 1", "Some value 2", "Some value 2", "Some value 1")]
        public void WHILE_BothValuesHaveMultipleFields_WHEN_FieldValuesAreDifferent_THEN_HashCodesAreNotEquivalent(string value1Field1, string value1Field2, string value2Field1, string value2Field2)
        {
            // Arrange
            var value1 = new MultipleFieldsValue(value1Field1, value1Field2);
            var value2 = new MultipleFieldsValue(value2Field1, value2Field2);
            
            // Act
            var value1HashCode = value1.GetHashCode();
            var value2HashCode = value2.GetHashCode();

            // Assert
            Assert.AreNotEqual(value1HashCode, value2HashCode);
        }
    }
}