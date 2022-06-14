using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value
{
    [TestClass]
    public sealed class ComparisonTests
    {
        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", null)]
        [DataRow(null, "")]
        [DataRow("", "")]
        [DataRow("Value 1", "Value 2")]
        [DataRow("Value 2", "Value 1")]
        public void WHILE_UsingExplicitEqualsMethod_WHEN_FieldsAreEqual_THEN_ValuesAreEquivalent(string field1, string field2)
        {
            // Arrange
            var leftValue = new MultipleFieldsValue(field1, field2);
            var rightValue = new MultipleFieldsValue(field1, field2);

            // Act
            var valuesAreEqual = leftValue.Equals(rightValue);

            // Assert
            Assert.IsTrue(valuesAreEqual);
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
        [DataRow("", null, "", "")]
        [DataRow(null, "", "", "")]
        public void WHILE_UsingExplicitEqualsMethod_WHEN_FieldsAreNotEqual_THEN_ValuesAreNotEquivalent(string value1Field1, string value1Field2, string value2Field1, string value2Field2)
        {
            // Arrange
            var leftValue = new MultipleFieldsValue(value1Field1, value1Field2);
            var rightValue = new MultipleFieldsValue(value2Field1, value2Field2);

            // Act
            var valuesAreEqual = leftValue.Equals(rightValue);

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHILE_UsingExplicitEqualsMethod_WHEN_InputValueIsNull_THEN_ValuesAreNotEquivalent()
        {
            // Arrange
            const string field1 = "Value 1";
            const string field2 = "Value 2";

            var leftValue = new MultipleFieldsValue(field1, field2);
            var rightValue = null as MultipleFieldsValue;

            // Act
            var valuesAreEqual = leftValue.Equals(rightValue);

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }
        
        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", null)]
        [DataRow(null, "")]
        [DataRow("", "")]
        [DataRow("Value 1", "Value 2")]
        [DataRow("Value 2", "Value 1")]
        public void WHILE_UsingImplicitEqualsMethod_WHEN_FieldsAreEqual_THEN_ValuesAreEquivalent(string field1, string field2)
        {
            // Arrange
            var leftValue = new MultipleFieldsValue(field1, field2);
            var rightValue = new MultipleFieldsValue(field1, field2) as object;

            // Act
            var valuesAreEqual = leftValue.Equals(rightValue);

            // Assert
            Assert.IsTrue(valuesAreEqual);
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
        [DataRow("", null, "", "")]
        [DataRow(null, "", "", "")]
        public void WHILE_UsingImplicitEqualsMethod_WHEN_FieldsAreNotEqual_THEN_ValuesAreNotEquivalent(string value1Field1, string value1Field2, string value2Field1, string value2Field2)
        {
            // Arrange
            var leftValue = new MultipleFieldsValue(value1Field1, value1Field2);
            var rightValue = new MultipleFieldsValue(value2Field1, value2Field2) as object;

            // Act
            var valuesAreEqual = leftValue.Equals(rightValue);

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHILE_UsingImplicitEqualsMethod_WHEN_InputValueIsNull_THEN_ValuesAreNotEquivalent()
        {
            // Arrange
            const string field1 = "Value 1";
            const string field2 = "Value 2";

            var leftValue = new MultipleFieldsValue(field1, field2);
            var rightValue = null as object;

            // Act
            var valuesAreEqual = leftValue.Equals(rightValue);

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }
        
        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", null)]
        [DataRow(null, "")]
        [DataRow("", "")]
        [DataRow("Value 1", "Value 2")]
        [DataRow("Value 2", "Value 1")]
        public void WHILE_UsingEqualsOperator_WHEN_FieldsAreEqual_THEN_ValuesAreEquivalent(string field1, string field2)
        {
            // Arrange
            var leftValue = new MultipleFieldsValue(field1, field2);
            var rightValue = new MultipleFieldsValue(field1, field2);

            // Act
            var valuesAreEqual = leftValue == rightValue;

            // Assert
            Assert.IsTrue(valuesAreEqual);
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
        [DataRow("", null, "", "")]
        [DataRow(null, "", "", "")]
        public void WHILE_UsingEqualsOperator_WHEN_FieldsAreNotEqual_THEN_ValuesAreNotEquivalent(string value1Field1, string value1Field2, string value2Field1, string value2Field2)
        {
            // Arrange
            var leftValue = new MultipleFieldsValue(value1Field1, value1Field2);
            var rightValue = new MultipleFieldsValue(value2Field1, value2Field2);

            // Act
            var valuesAreEqual = leftValue == rightValue;

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_UsingEqualsOperator_WHILE_LeftSideIsNull_THEN_ValuesAreNotEquivalent()
        {
            // Arrange
            var leftValue = null as MultipleFieldsValue;
            var rightValue = new MultipleFieldsValue("Field 1", "Field 2");

            // Act
            var valuesAreEqual = leftValue == rightValue;

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_UsingEqualsOperator_WHILE_RightSideIsNull_THEN_ValuesAreNotEquivalent()
        {
            // Arrange
            var leftValue = new MultipleFieldsValue("Field 1", "Field 2");
            var rightValue = null as MultipleFieldsValue;

            // Act
            var valuesAreEqual = leftValue == rightValue;

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_UsingEqualsOperator_WHILE_BothSidesAreNull_THEN_ValuesAreEquivalent()
        {
            // Arrange
            var leftValue = null as MultipleFieldsValue;
            var rightValue = null as MultipleFieldsValue;

            // Act
            var valuesAreEqual = leftValue == rightValue;

            // Assert
            Assert.IsTrue(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_UsingNotEqualsOperator_WHILE_FieldsAreEqual_THEN_ReturnFalse()
        {
            // Arrange
            const string field1 = "Value 1";
            const string field2 = "Value 2";

            var leftValue = new MultipleFieldsValue(field1, field2);
            var rightValue = new MultipleFieldsValue(field1, field2);

            // Act
            var valuesAreEqual = leftValue != rightValue;

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_UsingNotEqualsOperator_WHILE_FieldsAreNotEqual_THEN_ReturnTrue()
        {
            // Arrange
            const string field1 = "Value 1";
            const string field2 = "Value 2";
            const string field3 = "Value 3";

            var leftValue = new MultipleFieldsValue(field1, field3);
            var rightValue = new MultipleFieldsValue(field2, field3);

            // Act
            var valuesAreEqual = leftValue != rightValue;

            // Assert
            Assert.IsTrue(valuesAreEqual);
        }
    }
}