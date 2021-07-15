using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acidic.DomainDrivenDesign.UnitTests.Entity
{
    [TestClass]
    public class EntityInstantiationTests
    {
        [DataTestMethod]
        [DataRow(int.MinValue)]
        [DataRow(-1337)]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(default(int))]
        [DataRow(1)]
        [DataRow(1337)]
        [DataRow(int.MaxValue)]
        public void WHEN_Instantiating_WHILE_ArgumentIsValid_THEN_CreateInstance(int expectedIdentifier)
        {
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
    }
}