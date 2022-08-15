using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class HiddenValueTests
{
    [TestMethod]
    public void WHILE_ValueHidesFieldInInheritedValue_THEN_IncludeBothFieldsInIncludedValues()
    {
        // Arrange
        const string baseFieldValue = "Some random base field value";
        const string subFieldValue = "Some random sub field value";
        
        var value = new ValueThatHidesFieldFromInheritedValue(baseFieldValue, subFieldValue);

        var expectedIncludedValues = new[]
        {
            baseFieldValue,
            subFieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }

    private sealed class ValueThatHidesFieldFromInheritedValue : BaseValueWithHideableField
    {
        protected readonly string Field;

        public ValueThatHidesFieldFromInheritedValue(string baseField, string subField) : base(baseField)
        {
            Field = subField;
        }
    }
    
    private abstract class BaseValueWithHideableField : Value<BaseValueWithHideableField> 
    {
        protected readonly string Field;
        
        public BaseValueWithHideableField(string field)
        {
            Field = field;
        }
    }

    [TestMethod]
    public void WHILE_ValueHidesPropertyThatOverridesProperty_THEN_IncludeHidingAndOverridingValuesInIncludedValues()
    {
        // Arrange
        const string hidingPropertyValue = "Hiding property value";
        const string overridingPropertyValue = "Overriding property value";
        const string virtualPropertyValue = "Virtual property value";
        
        var value = new ValueThatHidesPropertyThatOverridesVirtualProperty(hidingPropertyValue, overridingPropertyValue, virtualPropertyValue);

        var expectedIncludedValues = new[]
        {
            hidingPropertyValue,
            overridingPropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueThatHidesPropertyThatOverridesVirtualProperty : ValueThatOverridesVirtualProperty
    {
        public ValueThatHidesPropertyThatOverridesVirtualProperty(string hidingProperty, string overridingProperty, string virtualProperty)  : base(overridingProperty, virtualProperty)
        {
            Property = hidingProperty;
        }

        protected string Property { get; }
    }

    private abstract class ValueThatOverridesVirtualProperty : ValueWithVirtualProperty
    {
        protected ValueThatOverridesVirtualProperty(string overridingProperty, string virtualProperty) : base(virtualProperty)
        {
            Property = overridingProperty;
        }

        protected override string Property { get; }
    }
    
    private abstract class ValueWithVirtualProperty : Value<ValueWithVirtualProperty>
    {
        protected ValueWithVirtualProperty(string property)
        {
            Property = property;
        }

        protected virtual string Property { get; }
    }

    [TestMethod]
    public void WHILE_ValueOverridesPropertyThatHidesProperty_THEN_IncludeOverridingAndHidingValuesInIncludedValues()
    {
        // Arrange
        const string overridingPropertyValue = "Overriding property value";
        const string hidingPropertyValue = "Hiding property value";
        const string basePropertyValue = "Base property value";
        
        var value = new ValueThatOverridesPropertyThatHidesProperty(overridingPropertyValue, hidingPropertyValue, basePropertyValue);

        var expectedIncludedValues = new[]
        {
            overridingPropertyValue,
            basePropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueThatOverridesPropertyThatHidesProperty : ValueThatHidesPropertyWithVirtualProperty
    {
        public ValueThatOverridesPropertyThatHidesProperty(string overridingProperty, string hidingProperty, string baseProperty)  : base(hidingProperty, baseProperty)
        {
            Property = overridingProperty;
        }

        protected override string Property { get; }
    }

    private abstract class ValueThatHidesPropertyWithVirtualProperty : ValueWithProperty
    {
        protected ValueThatHidesPropertyWithVirtualProperty(string hidingProperty, string baseProperty) : base(baseProperty)
        {
            Property = hidingProperty;
        }

        protected virtual string Property { get; }
    }

    [TestMethod]
    public void WHILE_ValueHidesPropertyThatImplementsProperty_THEN_IncludeHidingAndImplementingValuesInIncludedValues()
    {
        // Arrange
        const string hidingPropertyValue = "Hiding property value";
        const string implementingPropertyValue = "Overriding property value";
        
        var value = new ValueThatHidesPropertyImplementingProperty(hidingPropertyValue, implementingPropertyValue);

        var expectedIncludedValues = new[]
        {
            hidingPropertyValue,
            implementingPropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueThatHidesPropertyImplementingProperty : ValueThatImplementsProperty
    {
        public ValueThatHidesPropertyImplementingProperty(string hidingProperty, string implementingProperty) : base(implementingProperty)
        {
            Property = hidingProperty;
        }

        protected string Property { get; }
    }
    
    private abstract class ValueThatImplementsProperty : ValueWithAbstractProperty
    {
        protected ValueThatImplementsProperty(string property)
        {
            Property = property;
        }

        protected override string Property { get; }
    }
    
    private abstract class ValueWithAbstractProperty : Value<ValueWithAbstractProperty>
    {
        protected abstract string Property { get; }
    }

    [TestMethod]
    public void WHILE_ValueImplementsPropertyThatHidesProperty_THEN_IncludeHiddenAndImplementingValuesInIncludedValues()
    {
        // Arrange
        const string implementingPropertyValue = "Implementing property value";
        const string basePropertyValue = "Base property value";
        
        var value = new ValueThatImplementsPropertyThatHidesProperty(implementingPropertyValue, basePropertyValue);

        var expectedIncludedValues = new[]
        {
            basePropertyValue,
            implementingPropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueThatImplementsPropertyThatHidesProperty : ValueThatHidesPropertyWithAbstractProperty
    {
        public ValueThatImplementsPropertyThatHidesProperty(string implementingProperty, string baseProperty) : base(baseProperty)
        {
            Property = implementingProperty;
        }

        protected override string Property { get; }
    }
    
    private abstract class ValueThatHidesPropertyWithAbstractProperty : ValueWithProperty
    {
        protected abstract string Property { get; }

        protected ValueThatHidesPropertyWithAbstractProperty(string baseProperty) : base(baseProperty)
        {
        }
    }
    
    private abstract class ValueWithProperty : Value<ValueWithProperty>
    {
        protected ValueWithProperty(string property)
        {
            Property = property;
        }

        protected string Property { get; }
    }
}