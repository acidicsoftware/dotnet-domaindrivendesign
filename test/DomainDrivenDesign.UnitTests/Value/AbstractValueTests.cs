using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class AbstractValueTests
{
    [TestMethod]
    public void WHILE_ValueImplementsAbstractProperty_THEN_OnlyIncludePropertyValueOnceInIncludedValues()
    {
        const string propertyValue = "Property value";
        
        var value = new ValueThatOverridesAbstractProperty(propertyValue);
        
        var expectedIncludedValues = new[]
        {
            propertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueThatOverridesAbstractProperty : ValueWithAbstractProperty
    {
        public ValueThatOverridesAbstractProperty(string propertyValue)
        {
            Property = propertyValue;
        }

        public override string Property { get; }
    }
    
    private abstract class ValueWithAbstractProperty : Value<ValueWithAbstractProperty>
    {
        public abstract string Property { get; }
    }
}