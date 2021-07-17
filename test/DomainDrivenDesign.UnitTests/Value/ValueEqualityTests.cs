using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value
{
    [TestClass]
    public sealed class ValueEqualityTests
    {
        [TestMethod]
        public void WHEN_Comparing_EqualsMethod_Specific_WHILE_FieldsAreEqual_THEN_ReturnTrue()
        {
            // Arrange
            const int value1 = 42;
            const string value2 = "value";

            var leftValue = new MultipleFieldsValue(value1, value2);
            var rightValue = new MultipleFieldsValue(value1, value2);

            // Act
            var valuesAreEqual = leftValue.Equals(rightValue);

            // Assert
            Assert.IsTrue(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsMethod_Specific_WHILE_FieldsAreNotEqual_THEN_ReturnFalse()
        {
            // Arrange
            const int value1 = 42;
            const int value2 = 1337;
            const string value3 = "value";

            var leftValue = new MultipleFieldsValue(value1, value3);
            var rightValue = new MultipleFieldsValue(value2, value3);

            // Act
            var valuesAreEqual = leftValue.Equals(rightValue);

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsMethod_Specific_WHILE_InputIsNull_THEN_ReturnFalse()
        {
            // Arrange
            const int value1 = 42;
            const string value2 = "value";

            var leftValue = new MultipleFieldsValue(value1, value2);
            MultipleFieldsValue rightValue = null;

            // Act
            var valuesAreEqual = leftValue.Equals(rightValue);

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsMethod_Object_WHILE_FieldsAreEqual_THEN_ReturnTrue()
        {
            // Arrange
            const int value1 = 42;
            const string value2 = "value";

            var leftValue = new MultipleFieldsValue(value1, value2);
            var rightValue = (object)new MultipleFieldsValue(value1, value2);

            // Act
            var valuesAreEqual = leftValue.Equals(rightValue);

            // Assert
            Assert.IsTrue(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsMethod_Object_WHILE_FieldsAreNotEqual_THEN_ReturnFalse()
        {
            // Arrange
            const int value1 = 42;
            const int value2 = 1337;
            const string value3 = "value";

            var leftValue = new MultipleFieldsValue(value1, value3);
            var rightValue = (object)new MultipleFieldsValue(value2, value3);

            // Act
            var valuesAreEqual = leftValue.Equals(rightValue);

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsMethod_Object_WHILE_InputIsNull_THEN_ReturnFalse()
        {
            // Arrange
            const int value1 = 42;
            const string value2 = "value";

            var leftValue = new MultipleFieldsValue(value1, value2);
            var rightValue = (object)null;

            // Act
            var valuesAreEqual = leftValue.Equals(rightValue);

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsOperator_WHILE_FieldsAreEqual_THEN_ReturnTrue()
        {
            // Arrange
            const int value1 = 42;
            const string value2 = "value";

            var leftValue = new MultipleFieldsValue(value1, value2);
            var rightValue = new MultipleFieldsValue(value1, value2);

            // Act
            var valuesAreEqual = leftValue == rightValue;

            // Assert
            Assert.IsTrue(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsOperator_WHILE_FieldsAreNotEqual_THEN_ReturnFalse()
        {
            // Arrange
            const int value1 = 42;
            const int value2 = 1337;
            const string value3 = "value";

            var leftValue = new MultipleFieldsValue(value1, value3);
            var rightValue = new MultipleFieldsValue(value2, value3);

            // Act
            var valuesAreEqual = leftValue == rightValue;

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsOperator_WHILE_LeftSideIsNull_RightSideIsNotNull_THEN_ReturnFalse()
        {
            // Arrange
            const int value1 = 42;
            const string value2 = "value";

            MultipleFieldsValue leftValue = null;
            var rightValue = new MultipleFieldsValue(value1, value2);

            // Act
            var valuesAreEqual = leftValue == rightValue;

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsOperator_WHILE_LeftSideIsNotNull_RightSideIsNull_THEN_ReturnFalse()
        {
            // Arrange
            const int value1 = 42;
            const string value2 = "value";

            var leftValue = new MultipleFieldsValue(value1, value2);
            MultipleFieldsValue rightValue = null;

            // Act
            var valuesAreEqual = leftValue == rightValue;

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsOperator_WHILE_LeftSideIsNull_RightSideIsNull_THEN_ReturnTrue()
        {
            // Arrange
            MultipleFieldsValue leftValue = null;
            MultipleFieldsValue rightValue = null;

            // Act
            var valuesAreEqual = leftValue == rightValue;

            // Assert
            Assert.IsTrue(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_NotEqualsOperator_WHILE_FieldsAreEqual_THEN_ReturnFalse()
        {
            // Arrange
            const int value1 = 42;
            const string value2 = "value";

            var leftValue = new MultipleFieldsValue(value1, value2);
            var rightValue = new MultipleFieldsValue(value1, value2);

            // Act
            var valuesAreEqual = leftValue != rightValue;

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_NotEqualsOperator_WHILE_FieldsAreNotEqual_THEN_ReturnTrue()
        {
            // Arrange
            const int value1 = 42;
            const int value2 = 1337;
            const string value3 = "value";

            var leftValue = new MultipleFieldsValue(value1, value3);
            var rightValue = new MultipleFieldsValue(value2, value3);

            // Act
            var valuesAreEqual = leftValue != rightValue;

            // Assert
            Assert.IsTrue(valuesAreEqual);
        }
    }
}