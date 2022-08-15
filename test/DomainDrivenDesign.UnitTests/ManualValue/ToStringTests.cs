using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.ManualValue;

[TestClass]
public sealed class ToStringTests
{
    [TestMethod]
    public void WHILE_ValueHasNoValues_WHEN_GettingString_THEN_ReturnEmptyString()
    {
        // Arrange
        const string expectedValueString = "";

        var value = new EmptyValue();

        // Act
        var actualEmptyValueString = value.ToString();

        // Assert
        Assert.AreEqual(expectedValueString, actualEmptyValueString);
    }
        
    private sealed class EmptyValue : ManualValue<EmptyValue>
    {
        protected override object[] PropertiesForEqualityCheck => Array.Empty<object>();
    }

    [TestMethod]
    public void WHILE_ValueHasSingleField_WHEN_GettingString_THEN_ReturnStringWithFieldValue()
    {
        // Arrange
        const string fieldValue = "Some awesome value";
        
        const string expectedValueString = fieldValue;

        var value = new SingleFieldValue(fieldValue);

        // Act
        var actualSingleFieldString = value.ToString();

        // Assert
        Assert.AreEqual(expectedValueString, actualSingleFieldString);
    }
        
    private sealed class SingleFieldValue : ManualValue<SingleFieldValue>
    {
        private readonly string _field1;

        public SingleFieldValue(string field1)
        {
            _field1 = field1;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { _field1 };
    }

    [TestMethod]
    public void WHILE_ValueHasMultipleFields_WHEN_GettingString_THEN_ReturnConcatenatedFieldsString()
    {
        // Arrange
        const string firstFieldValue = "Some awesome value";
        const string secondFieldValue = "An even more awesome value";

        const string expectedValueString = $"{firstFieldValue} - {secondFieldValue}";

        var value = new MultipleFieldsValue(firstFieldValue, secondFieldValue);

        // Act
        var actualMultipleFieldsString = value.ToString();

        // Assert
        Assert.AreEqual(expectedValueString, actualMultipleFieldsString);
    }
        
    private sealed class MultipleFieldsValue : ManualValue<MultipleFieldsValue>
    {
        private readonly string _field1;
        private readonly string _field2;

        public MultipleFieldsValue(string field1, string field2)
        {
            _field1 = field1;
            _field2 = field2;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { _field1, _field2 };
    }
}