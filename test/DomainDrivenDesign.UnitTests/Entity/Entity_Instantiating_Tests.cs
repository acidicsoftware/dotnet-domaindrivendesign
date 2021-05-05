using AcidicSoftware.DomainDriven.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcidicSoftware.DomainDriven.UnitTests.Entity
{
    [TestClass]
    public class Entity_Instantiating_Tests
    {
        [TestMethod]
        public void WHILE_ArgumentsAreValid_WHEN_Instantiating_THEN_CreateInstance()
        {
            // Arrange
            const int expectedIdentifier = 1337;

            // Act
            var entity = new IntTestEntity(expectedIdentifier);

            // Assert
            Assert.AreEqual(expectedIdentifier, entity.Identifier);
        }

        [TestMethod]
        public void WHILE_ArgumentIsNull_WHEN_Instantiating_THEN_ThrowException()
        {
            // Arrange, Act & Assert
            ExceptionHelpers.ExpectArgumentNullException("identifier", () => new StringTestEntity(null));
        }

        [TestMethod]
        public void WHILE_IdentifierIsDefaultValue_WHEN_Instantiating_THEN_ThrowException()
        {
            // Arrange
            const int expectedIdentifier = default;

            // Act & Assert
            ExceptionHelpers.ExpectArgumentException("identifier", () => new IntTestEntity(expectedIdentifier));
        }
    }
}