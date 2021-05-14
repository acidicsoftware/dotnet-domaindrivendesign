using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Runtime.Serialization;

namespace Acidic.DomainDrivenDesign.UnitTests.TinyValue
{
    [TestClass]
    public class TinyValueSerializationTests
    {
        [TestMethod]
        public void WHEN_Serializing_OneValue_THEN_ValueIsSaved()
        {
            // Arrange
            const int expectedFieldValue = 1337;

            var tinyValue = new TinyValue<int>(expectedFieldValue);

            var formatterConverterMock = new Mock<IFormatterConverter>();

            var serializationInfo = new SerializationInfo(tinyValue.GetType(), formatterConverterMock.Object);
            var streamingContext = new StreamingContext(StreamingContextStates.All);

            // Act
            tinyValue.GetObjectData(serializationInfo, streamingContext);

            // Assert
            var serializedFieldValue = serializationInfo.GetInt32(nameof(tinyValue.Value));

            Assert.AreEqual(1, serializationInfo.MemberCount);
            Assert.AreEqual(expectedFieldValue, serializedFieldValue);
        }

        [TestMethod]
        public void WHEN_Serializing_TwoValues_THEN_ValuesAreSaved()
        {
            // Arrange
            const int expectedField1Value = 1337;
            const string expectedField2Value = "value";

            var tinyValue = new TinyValue<int, string>(expectedField1Value, expectedField2Value);

            var formatterConverterMock = new Mock<IFormatterConverter>();

            var serializationInfo = new SerializationInfo(tinyValue.GetType(), formatterConverterMock.Object);
            var streamingContext = new StreamingContext(StreamingContextStates.All);

            // Act
            tinyValue.GetObjectData(serializationInfo, streamingContext);

            // Assert
            var serializedField1Value = serializationInfo.GetInt32(nameof(tinyValue.Value1));
            var serializedField2Value = serializationInfo.GetString(nameof(tinyValue.Value2));

            Assert.AreEqual(2, serializationInfo.MemberCount);
            Assert.AreEqual(expectedField1Value, serializedField1Value);
            Assert.AreEqual(expectedField2Value, serializedField2Value);
        }

        [TestMethod]
        public void WHEN_Serializing_ThreeValues_THEN_ValuesAreSaved()
        {
            // Arrange
            const int expectedField1Value = 1337;
            const string expectedField2Value = "value";
            const double expectedField3Value = 42.42;

            var tinyValue = new TinyValue<int, string, double>(expectedField1Value, expectedField2Value, expectedField3Value);

            var formatterConverterMock = new Mock<IFormatterConverter>();

            var serializationInfo = new SerializationInfo(tinyValue.GetType(), formatterConverterMock.Object);
            var streamingContext = new StreamingContext(StreamingContextStates.All);

            // Act
            tinyValue.GetObjectData(serializationInfo, streamingContext);

            // Assert
            var serializedField1Value = serializationInfo.GetInt32(nameof(tinyValue.Value1));
            var serializedField2Value = serializationInfo.GetString(nameof(tinyValue.Value2));
            var serializedField3Value = serializationInfo.GetDouble(nameof(tinyValue.Value3));

            Assert.AreEqual(3, serializationInfo.MemberCount);
            Assert.AreEqual(expectedField1Value, serializedField1Value);
            Assert.AreEqual(expectedField2Value, serializedField2Value);
            Assert.AreEqual(expectedField3Value, serializedField3Value);
        }

        [TestMethod]
        public void WHEN_Serializing_FourValues_THEN_ValuesAreSaved()
        {
            // Arrange
            const int expectedField1Value = 1337;
            const string expectedField2Value = "value";
            const double expectedField3Value = 42.42;
            const float expectedField4Value = 42.1337f;

            var tinyValue = new TinyValue<int, string, double, float>(expectedField1Value, expectedField2Value, expectedField3Value, expectedField4Value);

            var formatterConverterMock = new Mock<IFormatterConverter>();

            var serializationInfo = new SerializationInfo(tinyValue.GetType(), formatterConverterMock.Object);
            var streamingContext = new StreamingContext(StreamingContextStates.All);

            // Act
            tinyValue.GetObjectData(serializationInfo, streamingContext);

            // Assert
            var serializedField1Value = serializationInfo.GetInt32(nameof(tinyValue.Value1));
            var serializedField2Value = serializationInfo.GetString(nameof(tinyValue.Value2));
            var serializedField3Value = serializationInfo.GetDouble(nameof(tinyValue.Value3));
            var serializedField4Value = serializationInfo.GetSingle(nameof(tinyValue.Value4));

            Assert.AreEqual(4, serializationInfo.MemberCount);
            Assert.AreEqual(expectedField1Value, serializedField1Value);
            Assert.AreEqual(expectedField2Value, serializedField2Value);
            Assert.AreEqual(expectedField3Value, serializedField3Value);
            Assert.AreEqual(expectedField4Value, serializedField4Value);
        }

        [TestMethod]
        public void WHEN_Serializing_FiveValues_THEN_ValuesAreSaved()
        {
            // Arrange
            const int expectedField1Value = 1337;
            const string expectedField2Value = "value";
            const double expectedField3Value = 42.42;
            const float expectedField4Value = 42.1337f;
            const int expectedField5Value = 3;

            var tinyValue = new TinyValue<int, string, double, float, int>(expectedField1Value, expectedField2Value, expectedField3Value, expectedField4Value, expectedField5Value);

            var formatterConverterMock = new Mock<IFormatterConverter>();

            var serializationInfo = new SerializationInfo(tinyValue.GetType(), formatterConverterMock.Object);
            var streamingContext = new StreamingContext(StreamingContextStates.All);

            // Act
            tinyValue.GetObjectData(serializationInfo, streamingContext);

            // Assert
            var serializedField1Value = serializationInfo.GetInt32(nameof(tinyValue.Value1));
            var serializedField2Value = serializationInfo.GetString(nameof(tinyValue.Value2));
            var serializedField3Value = serializationInfo.GetDouble(nameof(tinyValue.Value3));
            var serializedField4Value = serializationInfo.GetSingle(nameof(tinyValue.Value4));
            var serializedField5Value = serializationInfo.GetInt32(nameof(tinyValue.Value5));

            Assert.AreEqual(5, serializationInfo.MemberCount);
            Assert.AreEqual(expectedField1Value, serializedField1Value);
            Assert.AreEqual(expectedField2Value, serializedField2Value);
            Assert.AreEqual(expectedField3Value, serializedField3Value);
            Assert.AreEqual(expectedField4Value, serializedField4Value);
            Assert.AreEqual(expectedField5Value, serializedField5Value);
        }

        [TestMethod]
        public void WHEN_Deserializing_OneValue_WHILE_SupplyingSerializedData_THEN_ValueIsDeserialized()
        {
            // Arrange
            const int expectedFieldValue = 1337;

            var tinyValue = new TinyValue<int>(expectedFieldValue);

            var formatterConverterMock = new Mock<IFormatterConverter>();

            var serializationInfo = new SerializationInfo(tinyValue.GetType(), formatterConverterMock.Object);
            var streamingContext = new StreamingContext(StreamingContextStates.All);

            tinyValue.GetObjectData(serializationInfo, streamingContext);

            // Act
            var deserializedTinyValue = new TinyValue<int>(serializationInfo, streamingContext);

            // Assert
            Assert.AreEqual(expectedFieldValue, deserializedTinyValue.Value);
        }

        [TestMethod]
        public void WHEN_Deserializing_TwoValues_WHILE_SupplyingSerializedData_THEN_ValuesAreDeserialized()
        {
            // Arrange
            const int expectedField1Value = 1337;
            const string expectedField2Value = "value";

            var tinyValue = new TinyValue<int, string>(expectedField1Value, expectedField2Value);

            var formatterConverterMock = new Mock<IFormatterConverter>();

            var serializationInfo = new SerializationInfo(tinyValue.GetType(), formatterConverterMock.Object);
            var streamingContext = new StreamingContext(StreamingContextStates.All);

            tinyValue.GetObjectData(serializationInfo, streamingContext);

            // Act
            var deserializedTinyValue = new TinyValue<int, string>(serializationInfo, streamingContext);

            // Assert
            Assert.AreEqual(expectedField1Value, deserializedTinyValue.Value1);
            Assert.AreEqual(expectedField2Value, deserializedTinyValue.Value2);
        }

        [TestMethod]
        public void WHEN_Deserializing_ThreeValues_WHILE_SupplyingSerializedData_THEN_ValuesAreDeserialized()
        {
            // Arrange
            const int expectedField1Value = 1337;
            const string expectedField2Value = "value";
            const double expectedField3Value = 42.42;

            var tinyValue = new TinyValue<int, string, double>(expectedField1Value, expectedField2Value, expectedField3Value);

            var formatterConverterMock = new Mock<IFormatterConverter>();

            var serializationInfo = new SerializationInfo(tinyValue.GetType(), formatterConverterMock.Object);
            var streamingContext = new StreamingContext(StreamingContextStates.All);

            tinyValue.GetObjectData(serializationInfo, streamingContext);

            // Act
            var deserializedTinyValue = new TinyValue<int, string, double>(serializationInfo, streamingContext);

            // Assert
            Assert.AreEqual(expectedField1Value, deserializedTinyValue.Value1);
            Assert.AreEqual(expectedField2Value, deserializedTinyValue.Value2);
            Assert.AreEqual(expectedField3Value, deserializedTinyValue.Value3);
        }

        [TestMethod]
        public void WHEN_Deserializing_FourValues_WHILE_SupplyingSerializedData_THEN_ValuesAreDeserialized()
        {
            // Arrange
            const int expectedField1Value = 1337;
            const string expectedField2Value = "value";
            const double expectedField3Value = 42.42;
            const float expectedField4Value = 42.1337f;

            var tinyValue = new TinyValue<int, string, double, float>(expectedField1Value, expectedField2Value, expectedField3Value, expectedField4Value);

            var formatterConverterMock = new Mock<IFormatterConverter>();

            var serializationInfo = new SerializationInfo(tinyValue.GetType(), formatterConverterMock.Object);
            var streamingContext = new StreamingContext(StreamingContextStates.All);

            tinyValue.GetObjectData(serializationInfo, streamingContext);

            // Act
            var deserializedTinyValue = new TinyValue<int, string, double, float>(serializationInfo, streamingContext);

            // Assert
            Assert.AreEqual(expectedField1Value, deserializedTinyValue.Value1);
            Assert.AreEqual(expectedField2Value, deserializedTinyValue.Value2);
            Assert.AreEqual(expectedField3Value, deserializedTinyValue.Value3);
            Assert.AreEqual(expectedField4Value, deserializedTinyValue.Value4);
        }

        [TestMethod]
        public void WHEN_Deserializing_FiveValues_WHILE_SupplyingSerializedData_THEN_ValuesAreDeserialized()
        {
            // Arrange
            const int expectedField1Value = 1337;
            const string expectedField2Value = "value";
            const double expectedField3Value = 42.42;
            const float expectedField4Value = 42.1337f;
            const int expectedField5Value = 3;

            var tinyValue = new TinyValue<int, string, double, float, int>(expectedField1Value, expectedField2Value, expectedField3Value, expectedField4Value, expectedField5Value);

            var formatterConverterMock = new Mock<IFormatterConverter>();

            var serializationInfo = new SerializationInfo(tinyValue.GetType(), formatterConverterMock.Object);
            var streamingContext = new StreamingContext(StreamingContextStates.All);

            tinyValue.GetObjectData(serializationInfo, streamingContext);

            // Act
            var deserializedTinyValue = new TinyValue<int, string, double, float, int>(serializationInfo, streamingContext);

            // Assert
            Assert.AreEqual(expectedField1Value, deserializedTinyValue.Value1);
            Assert.AreEqual(expectedField2Value, deserializedTinyValue.Value2);
            Assert.AreEqual(expectedField3Value, deserializedTinyValue.Value3);
            Assert.AreEqual(expectedField4Value, deserializedTinyValue.Value4);
            Assert.AreEqual(expectedField5Value, deserializedTinyValue.Value5);
        }
    }
}