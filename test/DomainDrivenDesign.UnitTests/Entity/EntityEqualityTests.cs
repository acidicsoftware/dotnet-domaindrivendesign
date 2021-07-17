using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acidic.DomainDrivenDesign.UnitTests.Entity
{
    [TestClass]
    public sealed class EntityEqualityTests
    {
        [TestMethod]
        public void WHEN_Comparing_EqualsMethod_Specific_WHILE_IdentifiersAreEqual_THEN_ReturnTrue()
        {
            // Arrange
            const int identifier = 1337;

            var leftEntityMock = new Mock<Entity<int>>(MockBehavior.Loose, identifier);
            var leftEntity = leftEntityMock.Object;

            var rightEntityMock = new Mock<Entity<int>>(MockBehavior.Loose, identifier);
            var rightEntity = rightEntityMock.Object;

            // Act
            var entitiesAreEqual = leftEntity.Equals(rightEntity);

            // Assert
            Assert.IsTrue(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsMethod_Specific_WHILE_IdentifiersAreNotEqual_THEN_ReturnFalse()
        {
            // Arrange
            const int leftIdentifier = 1337;
            const int rightIdentifier = 4242;

            var leftEntityMock = new Mock<Entity<int>>(MockBehavior.Loose, leftIdentifier);
            var leftEntity = leftEntityMock.Object;

            var rightEntityMock = new Mock<Entity<int>>(MockBehavior.Loose, rightIdentifier);
            var rightEntity = rightEntityMock.Object;

            // Act
            var entitiesAreEqual = leftEntity.Equals(rightEntity);

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsMethod_Specific_WHILE_InputIsNull_THEN_ReturnFalse()
        {
            // Arrange
            const int identifier = 1337;

            var leftEntityMock = new Mock<Entity<int>>(MockBehavior.Loose, identifier);
            var leftEntity = leftEntityMock.Object;

            Entity<int> rightEntity = null;

            // Act
            var entitiesAreEqual = leftEntity.Equals(rightEntity);

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsMethod_Object_WHILE_IdentifiersAreEqual_THEN_ReturnTrue()
        {
            // Arrange
            const int identifier = 1337;

            var leftEntityMock = new Mock<Entity<int>>(MockBehavior.Loose, identifier);
            var leftEntity = leftEntityMock.Object;

            var rightEntityMock = new Mock<Entity<int>>(MockBehavior.Loose, identifier);
            var rightEntity = (object)rightEntityMock.Object;

            // Act
            var entitiesAreEqual = leftEntity.Equals(rightEntity);

            // Assert
            Assert.IsTrue(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsMethod_Object_WHILE_IdentifiersAreNotEqual_THEN_ReturnFalse()
        {
            // Arrange
            const int leftIdentifier = 1337;
            const int rightIdentifier = 4242;

            var leftEntityMock = new Mock<Entity<int>>(MockBehavior.Loose, leftIdentifier);
            var leftEntity = leftEntityMock.Object;

            var rightEntityMock = new Mock<Entity<int>>(MockBehavior.Loose, rightIdentifier);
            var rightEntity = (object)rightEntityMock.Object;

            // Act
            var entitiesAreEqual = leftEntity.Equals(rightEntity);

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsMethod_Object_WHILE_InputIsNull_THEN_ReturnFalse()
        {
            // Arrange
            const int identifier = 1337;

            var leftEntityMock = new Mock<Entity<int>>(MockBehavior.Loose, identifier);
            var leftEntity = leftEntityMock.Object;

            var rightEntity = (object)null;

            // Act
            var entitiesAreEqual = leftEntity.Equals(rightEntity);

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsOperator_WHILE_IdentifiersAreEqual_THEN_ReturnTrue()
        {
            // Arrange
            const int identifier = 1337;

            var leftEntityMock = new Mock<Entity<int>>(identifier);
            var leftEntity = leftEntityMock.Object;

            var rightEntityMock = new Mock<Entity<int>>(identifier);
            var rightEntity = rightEntityMock.Object;

            // Act
            var entitiesAreEqual = leftEntity == rightEntity;

            // Assert
            Assert.IsTrue(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsOperator_WHILE_IdentifiersAreNotEqual_THEN_ReturnFalse()
        {
            // Arrange
            const int leftIdentifier = 1337;
            const int rightIdentifier = 4242;

            var leftEntityMock = new Mock<Entity<int>>(leftIdentifier);
            var leftEntity = leftEntityMock.Object;

            var rightEntityMock = new Mock<Entity<int>>(rightIdentifier);
            var rightEntity = rightEntityMock.Object;

            // Act
            var entitiesAreEqual = leftEntity == rightEntity;

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsOperator_WHILE_LeftSideIsNull_THEN_ReturnFalse()
        {
            // Arrange
            const int identifier = 1337;

            Entity<int> leftEntity = null;

            var rightEntityMock = new Mock<Entity<int>>(identifier);
            var rightEntity = rightEntityMock.Object;

            // Act
            var entitiesAreEqual = leftEntity == rightEntity;

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsOperator_WHILE_RightSideIsNull_THEN_ReturnFalse()
        {
            // Arrange
            const int identifier = 1337;

            var leftEntityMock = new Mock<Entity<int>>(identifier);
            var leftEntity = leftEntityMock.Object;

            Entity<int> rightEntity = null;

            // Act
            var entitiesAreEqual = leftEntity == rightEntity;

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_EqualsOperator_WHILE_BothSidesAreNull_THEN_ReturnTrue()
        {
            // Arrange
            Entity<int> leftEntity = null;
            Entity<int> rightEntity = null;

            // Act
            var entitiesAreEqual = leftEntity == rightEntity;

            // Assert
            Assert.IsTrue(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_NotEqualsOperator_WHILE_IdentifiersAreEqual_THEN_ReturnFalse()
        {
            // Arrange
            const int identifier = 1337;

            var leftEntityMock = new Mock<Entity<int>>(identifier);
            var leftEntity = leftEntityMock.Object;

            var rightEntityMock = new Mock<Entity<int>>(identifier);
            var rightEntity = rightEntityMock.Object;

            // Act
            var entitiesAreEqual = leftEntity != rightEntity;

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_NotEqualsOperator_WHILE_IdentifiersAreNotEqual_THEN_ReturnTrue()
        {
            // Arrange
            const int leftIdentifier = 1337;
            const int rightIdentifier = 4242;

            var leftEntityMock = new Mock<Entity<int>>(leftIdentifier);
            var leftEntity = leftEntityMock.Object;

            var rightEntityMock = new Mock<Entity<int>>(rightIdentifier);
            var rightEntity = rightEntityMock.Object;

            // Act
            var entitiesAreEqual = leftEntity != rightEntity;

            // Assert
            Assert.IsTrue(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_NotEqualsOperator_WHILE_LeftSideIsNull_THEN_ReturnTrue()
        {
            // Arrange
            const int identifier = 1337;

            IntEntity leftEntity = null;

            var rightEntityMock = new Mock<Entity<int>>(identifier);
            var rightEntity = rightEntityMock.Object;

            // Act
            var entitiesAreEqual = leftEntity != rightEntity;

            // Assert
            Assert.IsTrue(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_NotEqualsOperator_WHILE_RightSideIsNull_THEN_ReturnTrue()
        {
            // Arrange
            const int identifier = 1337;

            var leftEntityMock = new Mock<Entity<int>>(identifier);
            var leftEntity = leftEntityMock.Object;

            Entity<int> rightEntity = null;

            // Act
            var entitiesAreEqual = leftEntity != rightEntity;

            // Assert
            Assert.IsTrue(entitiesAreEqual);
        }

        [TestMethod]
        public void WHEN_Comparing_NotEqualsOperator_WHILE_BothSidesAreNull_THEN_ReturnFalse()
        {
            // Arrange
            Entity<int> leftEntity = null;
            Entity<int> rightEntity = null;

            // Act
            var entitiesAreEqual = leftEntity != rightEntity;

            // Assert
            Assert.IsFalse(entitiesAreEqual);
        }
    }
}