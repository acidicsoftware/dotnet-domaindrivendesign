using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcidicSoftware.DomainDriven.UnitTests.Entity
{
    [TestClass]
    public class Entity_HashCode_Tests
    {
        [TestMethod]
        public void WHILE_IdentifierIsInt_WHEN_CalculatingHashCode_THEN_ReturnIdentifierHashCode()
        {
            // Arrange
            const int identifier = 1337;
            var entity = new IntTestEntity(identifier);

            var expectedHashCode = identifier.GetHashCode();

            // Act
            var actualHashCode = entity.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }
    }
}
