using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Entity
{
    [TestClass]
    public class EntityEqualityTests
    {
        [TestMethod]
        public void WHILE_IdentifiersAreEquivalent_WHEN_Comparing_EqualsMethod_THEN_ReturnTrue()
        {
            // Arrange
            const int identifier = 1337;

            var entity1 = new IntTestEntity(identifier);
            var entity2 = new IntTestEntity(identifier);

            // Act
            var entitiesAreEqual = entity1.Equals(entity2);

            // Assert
            Assert.IsTrue(entitiesAreEqual);
        }

        [TestMethod]
        public void WHILE_IdentifiersAreNotEquivalent_WHEN_Comparing_EqualsMethod_THEN_ReturnFalse()
        {
            // Arrange
            const int identifier1 = 1337;
            const int identifier2 = 4242;

            var entity1 = new IntTestEntity(identifier1);
            var entity2 = new IntTestEntity(identifier2);

            // Act
            var entitiesAreEqual = entity1.Equals(entity2);

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHILE_InputIsNull_WHEN_Comparing_EqualsMethod_THEN_ReturnTrue()
        {
            // Arrange
            const int identifier = 1337;

            var entity1 = new IntTestEntity(identifier);
            IntTestEntity entity2 = null;

            // Act
            var entitiesAreEqual = entity1.Equals(entity2);

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHILE_IdentifiersAreEquivalent_WHEN_Comparing_EqualsOperator_THEN_ReturnTrue()
        {
            // Arrange
            const int identifier = 1337;

            var entity1 = new IntTestEntity(identifier);
            var entity2 = new IntTestEntity(identifier);

            // Act
            var entitiesAreEqual = entity1 == entity2;

            // Assert
            Assert.IsTrue(entitiesAreEqual);
        }

        [TestMethod]
        public void WHILE_IdentifiersAreNotEquivalent_WHEN_Comparing_EqualsOperator_THEN_ReturnFalse()
        {
            // Arrange
            const int identifier1 = 1337;
            const int identifier2 = 4242;

            var entity1 = new IntTestEntity(identifier1);
            var entity2 = new IntTestEntity(identifier2);

            // Act
            var entitiesAreEqual = entity1 == entity2;

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHILE_LeftSideIsNull_RightSideIsNotNull_WHEN_Comparing_EqualsOperator_THEN_ReturnFalse()
        {
            // Arrange
            const int identifier = 1337;

            IntTestEntity entity1 = null;
            var entity2 = new IntTestEntity(identifier);

            // Act
            var entitiesAreEqual = entity1 == entity2;

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHILE_LeftSideIsNotNull_RightSideIsNull_WHEN_Comparing_EqualsOperator_THEN_ReturnFalse()
        {
            // Arrange
            const int identifier = 1337;

            var entity1 = new IntTestEntity(identifier);
            IntTestEntity entity2 = null;

            // Act
            var entitiesAreEqual = entity1 == entity2;

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHILE_BothSidesAreNull_WHEN_Comparing_EqualsOperator_THEN_ReturnTrue()
        {
            // Arrange
            IntTestEntity entity1 = null;
            IntTestEntity entity2 = null;

            // Act
            var entitiesAreEqual = entity1 == entity2;

            // Assert
            Assert.IsTrue(entitiesAreEqual);
        }

        [TestMethod]
        public void WHILE_IdentifiersAreEquivalent_WHEN_Comparing_NotEqualsOperator_THEN_ReturnFalse()
        {
            // Arrange
            const int identifier = 1337;

            var entity1 = new IntTestEntity(identifier);
            var entity2 = new IntTestEntity(identifier);

            // Act
            var entitiesAreEqual = entity1 != entity2;

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHILE_IdentifiersAreNotEquivalent_WHEN_Comparing_NotEqualsOperator_THEN_ReturnTrue()
        {
            // Arrange
            const int identifier1 = 1337;
            const int identifier2 = 4242;

            var entity1 = new IntTestEntity(identifier1);
            var entity2 = new IntTestEntity(identifier2);

            // Act
            var entitiesAreEqual = entity1 != entity2;

            // Assert
            Assert.IsTrue(entitiesAreEqual);
        }
    }
}