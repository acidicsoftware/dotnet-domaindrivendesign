using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acidic.DomainDrivenDesign.UnitTests.TinyValue
{
    [TestClass]
    public sealed class TinyValueInstantiationTests
    {
        [TestMethod]
        public void WHEN_OneValue_Instantiating_THEN_PropertiesAreSet()
        {
            // Arrange
            const int expectedFieldValue = 1337;

            // Act
            var entity = new Mock<TinyValue<int>>(expectedFieldValue).Object;

            // Assert
            Assert.AreEqual(expectedFieldValue, entity.Value);
        }

        [TestMethod]
        public void WHEN_TwoValues_Instantiating_THEN_PropertiesAreSet()
        {
            // Arrange
            const int expectedField1Value = 1337;
            const string expectedField2Value = "Value";

            // Act
            var entity = new Mock<TinyValue<int, string>>(expectedField1Value, expectedField2Value).Object;

            // Assert
            Assert.AreEqual(expectedField1Value, entity.Value1);
            Assert.AreEqual(expectedField2Value, entity.Value2);
        }

        [TestMethod]
        public void WHEN_ThreeValues_Instantiating_THEN_PropertiesAreSet()
        {
            // Arrange
            const int expectedField1Value = 1337;
            const string expectedField2Value = "Value";
            const double expectedField3Value = 42.42;

            // Act
            var entity = new Mock<TinyValue<int, string, double>>(expectedField1Value, expectedField2Value, expectedField3Value).Object;

            // Assert
            Assert.AreEqual(expectedField1Value, entity.Value1);
            Assert.AreEqual(expectedField2Value, entity.Value2);
            Assert.AreEqual(expectedField3Value, entity.Value3);
        }

        [TestMethod]
        public void WHEN_FourValues_Instantiating_THEN_PropertiesAreSet()
        {
            // Arrange
            const int expectedField1Value = 1337;
            const string expectedField2Value = "Value";
            const double expectedField3Value = 42.42;
            const float expectedField4Value = 42.1337f;

            // Act
            var entity = new Mock<TinyValue<int, string, double, float>>(expectedField1Value, expectedField2Value, expectedField3Value, expectedField4Value).Object;

            // Assert
            Assert.AreEqual(expectedField1Value, entity.Value1);
            Assert.AreEqual(expectedField2Value, entity.Value2);
            Assert.AreEqual(expectedField3Value, entity.Value3);
            Assert.AreEqual(expectedField4Value, entity.Value4);
        }

        [TestMethod]
        public void WHEN_FiveValues_Instantiating_THEN_PropertiesAreSet()
        {
            // Arrange
            const int expectedField1Value = 1337;
            const string expectedField2Value = "Value";
            const double expectedField3Value = 42.42;
            const float expectedField4Value = 42.1337f;
            const int expectedField5Value = 3;

            // Act
            var entity = new Mock<TinyValue<int, string, double, float, int>>(expectedField1Value, expectedField2Value, expectedField3Value, expectedField4Value, expectedField5Value).Object;

            // Assert
            Assert.AreEqual(expectedField1Value, entity.Value1);
            Assert.AreEqual(expectedField2Value, entity.Value2);
            Assert.AreEqual(expectedField3Value, entity.Value3);
            Assert.AreEqual(expectedField4Value, entity.Value4);
            Assert.AreEqual(expectedField5Value, entity.Value5);
        }
    }
}