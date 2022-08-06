using System.Linq;
using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class ExcludeWithVirtualMembersTests
{
    [TestMethod]
    public void WHILE_ValueOverridesExcludedPropertyWithDefaultProperty_THEN_DoNotIncludePropertiesInIncludedValues()
    {
        // Arrange
        var value = new ValueOverridingExcludedPropertyWithDefaultProperty("This is a property.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueOverridingExcludedPropertyWithDefaultProperty : ValueWithVirtualExcludedProperty
    {
        public ValueOverridingExcludedPropertyWithDefaultProperty(string property) : base(property)
        {
            Property = property;
        }

        protected override string Property { get; }
    }
    
    private abstract class ValueWithVirtualExcludedProperty : Value<ValueWithVirtualExcludedProperty>
    {
        protected ValueWithVirtualExcludedProperty(string property)
        {
            Property = property;
        }

        [Exclude]
        protected virtual string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueOverridesDefaultPropertyWithExcludedProperty_THEN_DoNotIncludePropertiesInIncludedValues()
    {
        // Arrange
        var value = new ValueOverridingPropertyWithExcludedProperty("This is a property.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueOverridingPropertyWithExcludedProperty : BaseValueWithVirtualProperty
    {
        public ValueOverridingPropertyWithExcludedProperty(string property) : base(property)
        {
            Property = property;
        }

        [Exclude]
        protected override string Property { get; }
    }
    
    private abstract class BaseValueWithVirtualProperty : Value<BaseValueWithVirtualProperty>
    {
        public BaseValueWithVirtualProperty(string property)
        {
            Property = property;
        }

        protected virtual string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueOverridesExcludedPropertyWithExcludedProperty_THEN_DoNotIncludePropertiesInIncludedValues()
    {
        // Arrange
        var value = new ValueOverridingExcludedPropertyWithExcludedProperty("This is a property.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueOverridingExcludedPropertyWithExcludedProperty : ValueWithVirtualExcludedProperty
    {
        public ValueOverridingExcludedPropertyWithExcludedProperty(string property) : base(property)
        {
            Property = property;
        }

        [Exclude]
        protected override string Property { get; }
    }
}