using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcidicSoftware.DomainDriven.UnitTests.Value
{
    [TestClass]
    public class Value_Equality_Tests
    {
        [TestMethod]
        public void WHILE_FieldsAreEquivalent_WHEN_Comparing_EqualsMethod_THEN_ReturnTrue()
        {
            // Arrange
            const int field1 = 42;
            const double field2 = 1337.4242;

            var value1 = new TestValue(field1, field2);
            var value2 = new TestValue(field1, field2);

            // Act
            var valuesAreEqual = value1.Equals(value2);

            // Assert
            Assert.IsTrue(valuesAreEqual);
        }

        [TestMethod]
        public void WHILE_FieldsAreNotEquivalent_WHEN_Comparing_EqualsMethod_THEN_ReturnFalse()
        {
            // Arrange
            const int value1Field1 = 42;
            const int value2Field1 = 1337;
            const double field2 = 1337.4242;

            var value1 = new TestValue(value1Field1, field2);
            var value2 = new TestValue(value2Field1, field2);

            // Act
            var valuesAreEqual = value1.Equals(value2);

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHILE_InputIsNull_WHEN_Comparing_EqualsMethod_THEN_ReturnFalse()
        {
            // Arrange
            const int field1 = 42;
            const double field2 = 1337.4242;

            var value1 = new TestValue(field1, field2);
            TestValue value2 = null;

            // Act
            var valuesAreEqual = value1.Equals(value2);

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHILE_FieldsAreEquivalent_WHEN_Comparing_EqualsOperator_THEN_ReturnTrue()
        {
            // Arrange
            const int field1 = 42;
            const double field2 = 1337.4242;

            var value1 = new TestValue(field1, field2);
            var value2 = new TestValue(field1, field2);

            // Act
            var valuesAreEqual = value1 == value2;

            // Assert
            Assert.IsTrue(valuesAreEqual);
        }

        [TestMethod]
        public void WHILE_FieldsAreNotEquivalent_WHEN_Comparing_EqualsOperator_THEN_ReturnFalse()
        {
            // Arrange
            const int value1Field1 = 42;
            const int value2Field1 = 1337;
            const double field2 = 1337.4242;

            var value1 = new TestValue(value1Field1, field2);
            var value2 = new TestValue(value2Field1, field2);

            // Act
            var valuesAreEqual = value1 == value2;

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHILE_LeftSideIsNull_RightSideIsNotNull_WHEN_Comparing_EqualsOperator_THEN_ReturnFalse()
        {
            // Arrange
            const int field1 = 42;
            const double field2 = 1337.4242;

            TestValue value1 = null;
            var value2 = new TestValue(field1, field2);

            // Act
            var valuesAreEqual = value1 == value2;

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHILE_LeftSideIsNotNull_RightSideIsNull_WHEN_Comparing_EqualsOperator_THEN_ReturnFalse()
        {
            // Arrange
            const int field1 = 42;
            const double field2 = 1337.4242;

            var value1 = new TestValue(field1, field2);
            TestValue value2 = null;

            // Act
            var valuesAreEqual = value1 == value2;

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHILE_LeftSideIsNull_RightSideIsNull_WHEN_Comparing_EqualsOperator_THEN_ReturnTrue()
        {
            // Arrange
            TestValue value1 = null;
            TestValue value2 = null;

            // Act
            var valuesAreEqual = value1 == value2;

            // Assert
            Assert.IsTrue(valuesAreEqual);
        }

        [TestMethod]
        public void WHILE_FieldsAreEquivalent_WHEN_Comparing_NotEqualsOperator_THEN_ReturnFalse()
        {
            // Arrange
            const int field1 = 42;
            const double field2 = 1337.4242;

            var value1 = new TestValue(field1, field2);
            var value2 = new TestValue(field1, field2);

            // Act
            var valuesAreEqual = value1 != value2;

            // Assert
            Assert.IsFalse(valuesAreEqual);
        }

        [TestMethod]
        public void WHILE_FieldsAreNotEquivalent_WHEN_Comparing_NotEqualsOperator_THEN_ReturnTrue()
        {
            // Arrange
            const int value1Field1 = 42;
            const int value2Field1 = 1337;
            const double field2 = 1337.4242;

            var value1 = new TestValue(value1Field1, field2);
            var value2 = new TestValue(value2Field1, field2);

            // Act
            var valuesAreEqual = value1 != value2;

            // Assert
            Assert.IsTrue(valuesAreEqual);
        }
    }
}