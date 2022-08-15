using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class MembersIncludedOrderingTests
{
    [TestMethod]
    public void WHILE_BaseValueHasFieldAndProperty_THEN_AddMemberValuesToIncludedValuesInTheCorrectOrder()
    {
        // Arrange
        const string fieldValue = "Some field value";
        const string propertyValue = "Some property value";
        
        var expectedIncludedValues = new[]
        {
            fieldValue,
            propertyValue
        };
        
        var value = new ValueWithFieldAndProperty(fieldValue, propertyValue);

        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        CollectionAssert.AreEqual(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithFieldAndProperty : Value<ValueWithFieldAndProperty>
    {
        private readonly string _field;

        public ValueWithFieldAndProperty(string field, string property)
        {
            _field = field;
            Property = property;
        }

        private string Property { get; }
    }

    [TestMethod]
    public void WHILE_BaseValueAndSubclassBothHaveFieldAndProperty_THEN_AddMemberValuesToIncludedValuesInTheCorrectOrder()
    {
        // Arrange
        const string subclassFieldValue = "Some subclass field value";
        const string subclassPropertyValue = "Some subclass property value";
        const string baseClassFieldValue = "Some base class field value";
        const string baseClassPropertyValue = "Some base class property value";
        
        var expectedIncludedValues = new[]
        {
            subclassFieldValue,
            subclassPropertyValue,
            baseClassFieldValue,
            baseClassPropertyValue
        };
        
        var value = new SubValueWithFieldAndProperty(subclassFieldValue, subclassPropertyValue, baseClassFieldValue, baseClassPropertyValue);

        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        CollectionAssert.AreEqual(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class SubValueWithFieldAndProperty : BaseValueWithFieldAndProperty
    {
        private readonly string _field;

        public SubValueWithFieldAndProperty(string field, string property, string baseField, string baseProperty) : base(baseField, baseProperty)
        {
            _field = field;
            Property = property;
        }

        private string Property { get; }
    }

    private abstract class BaseValueWithFieldAndProperty : Value<BaseValueWithFieldAndProperty>
    {
        private readonly string _baseField;

        public BaseValueWithFieldAndProperty(string baseField, string baseProperty)
        {
            _baseField = baseField;
            BaseProperty = baseProperty;
        }

        private string BaseProperty { get; }
    }
}