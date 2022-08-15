using System.Linq;
using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class IncludeExcludeMixingTests
{
    [TestMethod]
    public void WHILE_ValueHasFieldThatIsBothIncludedAndExcluded_THEN_DoNotIncludeFieldInIncludedValues()
    {
        // Arrange
        var value = new ValueWithExcludedAndIncludedField("Some field value");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithExcludedAndIncludedField : Value<ValueWithExcludedAndIncludedField>
    {
        [Include]
        [Exclude]
        private readonly string _field;

        public ValueWithExcludedAndIncludedField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasPropertyThatIsBothIncludedAndExcluded_THEN_DoNotIncludePropertyInIncludedValues()
    {
        // Arrange
        var value = new ValueWithExcludedAndIncludedProperty("Some property value");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithExcludedAndIncludedProperty : Value<ValueWithExcludedAndIncludedProperty>
    {
        public ValueWithExcludedAndIncludedProperty(string property)
        {
            Property = property;
        }
        
        [Include]
        [Exclude]
        private string Property { get; }
    }

    [TestMethod]
    public void WHILE_ValueOverridesExcludedVirtualPropertyWithIncludedProperty_THEN_OnlyIncludeSubclassPropertyInIncludedValues()
    {
        // Arrange
        const string basePropertyValue = "Some base property";
        const string subPropertyValue = "Some sub property";
        
        var value = new ValueThatOverridesExcludedVirtualPropertyWithIncludedProperty(basePropertyValue, subPropertyValue);

        var expectedIncludedValues = new[]
        {
            subPropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueThatOverridesExcludedVirtualPropertyWithIncludedProperty : ValueWithExcludedVirtualProperty
    {
        public ValueThatOverridesExcludedVirtualPropertyWithIncludedProperty(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }

        [Include]
        protected override string Property { get; }
    }

    private abstract class ValueWithExcludedVirtualProperty : Value<ValueWithExcludedVirtualProperty>
    {
        protected ValueWithExcludedVirtualProperty(string property)
        {
            Property = property;
        }

        [Exclude]
        protected virtual string Property { get; }
    }

    [TestMethod]
    public void WHILE_ValueOverridesIncludedVirtualPropertyWithExcludedProperty_THEN_DoNotIncludePropertyInIncludedValues()
    {
        // Arrange
        var value = new ValueThatOverridesIncludedVirtualPropertyWithExcludedProperty("Some base property", "Some sub property");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueThatOverridesIncludedVirtualPropertyWithExcludedProperty : ValueWithIncludedVirtualProperty
    {
        public ValueThatOverridesIncludedVirtualPropertyWithExcludedProperty(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }

        [Exclude]
        protected override string Property { get; }
    }

    private abstract class ValueWithIncludedVirtualProperty : Value<ValueWithIncludedVirtualProperty>
    {
        protected ValueWithIncludedVirtualProperty(string property)
        {
            Property = property;
        }

        [Include]
        protected virtual string Property { get; }
    }

    [TestMethod]
    public void WHILE_ValueImplementsExcludedAbstractPropertyWithIncludedProperty_THEN_IncludePropertyOnceInIncludedValues()
    {
        // Arrange
        const string propertyValue = "Some property";
        
        var value = new ValueThatImplementsExcludedAbstractPropertyWithIncludedProperty(propertyValue);

        var expectedIncludedValues = new[]
        {
            propertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueThatImplementsExcludedAbstractPropertyWithIncludedProperty : ValueWithExcludedAbstractProperty
    {
        public ValueThatImplementsExcludedAbstractPropertyWithIncludedProperty(string property)
        {
            Property = property;
        }

        [Include]
        protected override string Property { get; }
    }

    private abstract class ValueWithExcludedAbstractProperty : Value<ValueWithExcludedAbstractProperty>
    {
        [Exclude]
        protected abstract string Property { get; }
    }

    [TestMethod]
    public void WHILE_ValueImplementsIncludedAbstractPropertyWithExcludedProperty_THEN_DoNotIncludePropertyInIncludedValues()
    {
        // Arrange
        var value = new ValueThatImplementsIncludedAbstractPropertyWithExcludedProperty("Some property");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueThatImplementsIncludedAbstractPropertyWithExcludedProperty : ValueWithIncludedAbstractProperty
    {
        public ValueThatImplementsIncludedAbstractPropertyWithExcludedProperty(string property)
        {
            Property = property;
        }

        [Exclude]
        protected override string Property { get; }
    }

    private abstract class ValueWithIncludedAbstractProperty : Value<ValueWithIncludedAbstractProperty>
    {
        [Include]
        protected abstract string Property { get; }
    }

    [TestMethod]
    public void WHILE_ValueHidesExcludedFieldWithIncludedField_THEN_IncludeSubclassFieldInIncludedValues()
    {
        // Arrange
        const string baseFieldValue = "Some base field";
        const string subFieldValue = "Some sub field";
        
        var value = new ValueHidingExcludedFieldWithIncludedField(baseFieldValue, subFieldValue);

        var expectedIncludedValues = new[]
        {
            subFieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }

    private sealed class ValueHidingExcludedFieldWithIncludedField : ValueWithExcludedProtectedField
    {
        [Include]
        protected readonly string _field;
        
        public ValueHidingExcludedFieldWithIncludedField(string baseField, string subField) : base(baseField)
        {
            _field = subField;
        }
    }

    private abstract class ValueWithExcludedProtectedField : Value<ValueWithExcludedProtectedField>
    {
        [Exclude]
        protected readonly string _field;

        protected ValueWithExcludedProtectedField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHidesIncludedFieldWithExcludedField_THEN_IncludeBaseClassFieldInIncludedValues()
    {
        // Arrange
        const string baseFieldValue = "Some base field";
        const string subFieldValue = "Some sub field";
        
        var value = new ValueHidingIncludedFieldWithExcludedField(baseFieldValue, subFieldValue);

        var expectedIncludedValues = new[]
        {
            baseFieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueHidingIncludedFieldWithExcludedField : ValueWithIncludedProtectedField
    {
        [Exclude]
        protected readonly string _field;
        
        public ValueHidingIncludedFieldWithExcludedField(string baseField, string subField) : base(baseField)
        {
            _field = subField;
        }
    }

    private abstract class ValueWithIncludedProtectedField : Value<ValueWithIncludedProtectedField>
    {
        [Include]
        protected readonly string _field;

        protected ValueWithIncludedProtectedField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHidesExcludedPropertyWithIncludedProperty_THEN_IncludeSubclassPropertyInIncludedValues()
    {
        // Arrange
        const string basePropertyValue = "Some base property";
        const string subPropertyValue = "Some sub property";
        
        var value = new ValueHidingExcludedPropertyWithIncludedProperty(basePropertyValue, subPropertyValue);

        var expectedIncludedValues = new[]
        {
            subPropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueHidingExcludedPropertyWithIncludedProperty : ValueWithExcludedProtectedProperty
    {
        public ValueHidingExcludedPropertyWithIncludedProperty(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }
        
        [Include]
        protected readonly string Property;
    }

    private abstract class ValueWithExcludedProtectedProperty : Value<ValueWithExcludedProtectedProperty>
    {
        protected ValueWithExcludedProtectedProperty(string property)
        {
            Property = property;
        }
        
        [Exclude]
        protected readonly string Property;
    }
    
    [TestMethod]
    public void WHILE_ValueHidesIncludedPropertyWithExcludedProperty_THEN_IncludeBaseClassPropertyInIncludedValues()
    {
        // Arrange
        const string basePropertyValue = "Some base property";
        const string subPropertyValue = "Some sub property";
        
        var value = new ValueHidingIncludedPropertyWithExcludedProperty(basePropertyValue, subPropertyValue);

        var expectedIncludedValues = new[]
        {
            basePropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueHidingIncludedPropertyWithExcludedProperty : ValueWithIncludedProtectedProperty
    {
        public ValueHidingIncludedPropertyWithExcludedProperty(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }
        
        [Exclude]
        protected readonly string Property;
    }

    private abstract class ValueWithIncludedProtectedProperty : Value<ValueWithIncludedProtectedProperty>
    {
        protected ValueWithIncludedProtectedProperty(string property)
        {
            Property = property;
        }
        
        [Include]
        protected readonly string Property;
    }
}