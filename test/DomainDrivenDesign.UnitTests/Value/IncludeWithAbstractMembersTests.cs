using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class IncludeWithAbstractMembersTests
{
    [TestMethod]
    public void WHILE_ValueImplementsAbstractIncludedPropertyWithDefaultProperty_THEN_IncludePropertyOnceInIncludedValues()
    {
        // Arrange
        const string propertyValue = "This is a property.";
        
        var expectedIncludedValues = new object[]
        {
            propertyValue
        };
        
        var value = new ValueImplementingAbstractIncludedPropertyWithDefaultProperty(propertyValue);

        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueImplementingAbstractIncludedPropertyWithDefaultProperty : ValueWithAbstractIncludedProperty
    {
        public ValueImplementingAbstractIncludedPropertyWithDefaultProperty(string property)
        {
            Property = property;
        }

        protected override string Property { get; }
    }
    
    private abstract class ValueWithAbstractIncludedProperty : Value<ValueWithAbstractIncludedProperty>
    {
        [Include]
        protected abstract string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueImplementsAbstractPropertyWithIncludedProperty_THEN_IncludePropertyOnceInIncludedValues()
    {
        // Arrange
        const string propertyValue = "Some property value";
        
        var value = new ValueImplementingAbstractPropertyWithIncludedProperty(propertyValue);

        var expectedIncludedValues = new[]
        {
            propertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }

    private sealed class ValueImplementingAbstractPropertyWithIncludedProperty : ValueWithAbstractProperty
    {
        public ValueImplementingAbstractPropertyWithIncludedProperty(string property)
        {
            Property = property;
        }

        [Include]
        protected override string Property { get; }
    }
    
    private abstract class ValueWithAbstractProperty : Value<ValueWithAbstractProperty>
    {
        protected abstract string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueImplementsAbstractIncludedPropertyWithIncludedProperty_THEN_IncludePropertyOnceInIncludedValues()
    {
        // Arrange
        const string propertyValue = "Some property value";
        
        var value = new ValueImplementingAbstractIncludedPropertyWithIncludedProperty(propertyValue);

        var expectedIncludedValues = new[]
        {
            propertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }

    private sealed class ValueImplementingAbstractIncludedPropertyWithIncludedProperty : ValueWithAbstractIncludedProperty
    {
        public ValueImplementingAbstractIncludedPropertyWithIncludedProperty(string property)
        {
            Property = property;
        }

        [Include]
        protected override string Property { get; }
    }
}