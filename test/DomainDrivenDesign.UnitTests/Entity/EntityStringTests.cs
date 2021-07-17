using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Entity
{
    [TestClass]
    public sealed class EntityStringTests
    {
        [TestMethod]
        public void WHEN_ConvertingToString_THEN_ReturnIdentifiersString()
        {
            // Arrange
            const int identifier = 1337;
            var expectedIdentifierString = identifier.ToString();

            var entity = new IntEntity(identifier);

            // Act
            var actualIdentifierString = entity.ToString();

            // Assert
            Assert.AreEqual(expectedIdentifierString, actualIdentifierString);
        }
    }
}