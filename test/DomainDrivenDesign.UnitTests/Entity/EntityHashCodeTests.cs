using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acidic.DomainDrivenDesign.UnitTests.Entity
{
    [TestClass]
    public class EntityHashCodeTests
    {
        [TestMethod]
        public void WHEN_CalculatingHashCode_THEN_ReturnIdentifierHashCode()
        {
            // Arrange
            const int identifier = 1337;
            var entityMock = new Mock<Entity<int>>(MockBehavior.Loose, identifier);
            var entity = entityMock.Object;

            var expectedHashCode = identifier.GetHashCode();

            // Act
            var actualHashCode = entity.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }
    }
}
