using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class IncludeWithVirtualMembersTests
{
    [TestMethod]
    public void WHILE_ValueOverridesIncludedPropertyWithDefaultProperty_THEN_OnlyIncludeOverridingPropertyInIncludedValues()
    {
        // Arrange
        const string basePropertyValue = "This is a base property.";
        const string subPropertyValue = "This is a sub property.";
        
        var expectedIncludedValues = new object[]
        {
            subPropertyValue
        };
        
        var value = new ValueOverridingIncludedPropertyWithDefaultProperty(basePropertyValue, subPropertyValue);

        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }

    private sealed class ValueOverridingIncludedPropertyWithDefaultProperty : ValueWithVirtualIncludedProperty
    {
        public ValueOverridingIncludedPropertyWithDefaultProperty(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }

        protected override string Property { get; }
    }
    
    private abstract class ValueWithVirtualIncludedProperty : Value<ValueWithVirtualIncludedProperty>
    {
        protected ValueWithVirtualIncludedProperty(string property)
        {
            Property = property;
        }

        [Include]
        protected virtual string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueOverridesPropertyWithIncludedProperty_THEN_OnlyIncludeOverridingPropertyInIncludedValues()
    {
        // Arrange
        const string basePropertyValue = "Some base property value";
        const string subPropertyValue = "Some sub property value";
        
        var value = new ValueOverridesPropertyWithIncludedProperty(basePropertyValue, subPropertyValue);

        var expectedIncludedValues = new[]
        {
            subPropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueOverridesPropertyWithIncludedProperty : ValueWithVirtualProperty
    {
        public ValueOverridesPropertyWithIncludedProperty(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }

        [Include]
        protected override string Property { get; }
    }
    
    private abstract class ValueWithVirtualProperty : Value<ValueWithVirtualProperty>
    {
        public ValueWithVirtualProperty(string property)
        {
            Property = property;
        }

        protected virtual string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueOverridesIncludedPropertyWithIncludedProperty_THEN_OnlyIncludeOverridingPropertyInIncludedValues()
    {
        // Arrange
        const string basePropertyValue = "Some base property value";
        const string subPropertyValue = "Some sub property value";
        
        var value = new ValueOverridesIncludedPropertyWithIncludedProperty(basePropertyValue, subPropertyValue);

        var expectedIncludedValues = new[]
        {
            subPropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueOverridesIncludedPropertyWithIncludedProperty : ValueWithVirtualIncludedProperty
    {
        public ValueOverridesIncludedPropertyWithIncludedProperty(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }

        [Include]
        protected override string Property { get; }
    }
}