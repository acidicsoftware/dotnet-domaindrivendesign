using System.Linq;
using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class ExcludeWithAbstractMembersTests
{
    [TestMethod]
    public void WHILE_ValueImplementsAbstractExcludedPropertyWithDefaultProperty_THEN_DoNotIncludePropertiesInIncludedValues()
    {
        // Arrange
        var value = new ValueImplementingAbstractExcludedPropertyWithDefaultProperty("This is a property.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueImplementingAbstractExcludedPropertyWithDefaultProperty : ValueWithAbstractExcludedProperty
    {
        public ValueImplementingAbstractExcludedPropertyWithDefaultProperty(string property)
        {
            Property = property;
        }

        protected override string Property { get; }
    }
    
    private abstract class ValueWithAbstractExcludedProperty : Value<ValueWithAbstractExcludedProperty>
    {
        [Exclude]
        protected abstract string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueImplementsAbstractPropertyWithExcludedProperty_THEN_DoNotIncludePropertiesInIncludedValues()
    {
        // Arrange
        var value = new ValueImplementsDefaultAbstractPropertyWithExcludedProperty("This is a property.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueImplementsDefaultAbstractPropertyWithExcludedProperty : ValueWithAbstractProperty
    {
        public ValueImplementsDefaultAbstractPropertyWithExcludedProperty(string property)
        {
            Property = property;
        }

        [Exclude]
        protected override string Property { get; }
    }
    
    private abstract class ValueWithAbstractProperty : Value<ValueWithAbstractProperty>
    {
        protected abstract string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueImplementsAbstractExcludedPropertyWithExcludedProperty_THEN_DoNotIncludePropertiesInIncludedValues()
    {
        // Arrange
        var value = new ValueImplementsExcludedAbstractPropertyWithExcludedProperty("This is a property.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueImplementsExcludedAbstractPropertyWithExcludedProperty : ValueWithAbstractExcludedProperty
    {
        public ValueImplementsExcludedAbstractPropertyWithExcludedProperty(string property)
        {
            Property = property;
        }

        [Exclude]
        protected override string Property { get; }
    }
}