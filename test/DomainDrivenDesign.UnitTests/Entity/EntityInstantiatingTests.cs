using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acidic.DomainDrivenDesign.UnitTests.Entity
{
    [TestClass]
    public class EntityInstantiatingTests
    {
        [TestMethod]
        public void WHEN_Instantiating_WHILE_ArgumentIsValid_THEN_CreateInstance()
        {
            // Arrange
            const int expectedIdentifier = 1337;

            // Act
            var entityMock = new Mock<Entity<int>>(expectedIdentifier);
            var entity = entityMock.Object;

            // Assert
            Assert.AreEqual(expectedIdentifier, entity.Identifier);
        }

        [TestMethod]
        public void WHEN_Instantiating_WHILE_ArgumentIsNull_THEN_ThrowException()
        {
            // Arrange
            const string identifier = null;

            // Act & Assert
            ExceptionHelpers.ExpectArgumentNullException("identifier", () => new StringEntity(identifier));
        }

        [TestMethod]
        public void WHEN_Instantiating_WHILE_IdentifierIsDefaultValue_THEN_ThrowException()
        {
            // Arrange
            const int identifier = default;

            // Act & Assert
            ExceptionHelpers.ExpectArgumentException("identifier", () => new IntEntity(identifier));
        }
    }
}