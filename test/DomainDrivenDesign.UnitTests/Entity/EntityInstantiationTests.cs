using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acidic.DomainDrivenDesign.UnitTests.Entity
{
    [TestClass]
    public sealed class EntityInstantiationTests
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
        public void WHILE_ValidIdentifierIsProvided_WHEN_Instantiating_THEN_CreateInstance(int expectedIdentifier)
        {
            // Act
            var entityMock = new Mock<Entity<int>>(expectedIdentifier);
            var entity = entityMock.Object;

            // Assert
            var actualIdentifier = entity.GetType().GetProperty("Identifier", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(entity) as int?;
            Assert.AreEqual(expectedIdentifier, actualIdentifier);
        }

        [TestMethod]
        public void WHILE_IdentifierIsNull_WHEN_InstantiatingEntity_THEN_ThrowException()
        {
            // Arrange
            const string identifier = null;

            // Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => new StringEntity(identifier));
            Assert.AreEqual("identifier", exception.ParamName);
        }
        
        private sealed class StringEntity : Entity<string>
        {
            public StringEntity(string identifier) : base(identifier)
            {
            }
        }
    }
}