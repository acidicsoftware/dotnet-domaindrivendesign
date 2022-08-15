using System.Linq;
using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class ExcludeWithHiddenMembersTests
{
    [TestMethod]
    public void WHILE_ValueHidesExcludedFieldWithDefaultField_THEN_OnlyIncludeSubclassFieldInIncludedValues()
    {
        // Arrange
        const string baseFieldValue = "Some base field value";
        const string subFieldValue = "Some sub field value";
        
        var value = new ValueHidingExcludedFieldWithDefaultField(baseFieldValue, subFieldValue);

        var expectedIncludedValues = new[]
        {
            subFieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueHidingExcludedFieldWithDefaultField : ValueWithExcludedProtectedField
    {
        protected readonly string _field;
        
        public ValueHidingExcludedFieldWithDefaultField(string baseField, string subField) : base(baseField)
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
    public void WHILE_ValueHidesDefaultFieldWithExcludedField_THEN_OnlyIncludeBaseClassFieldInIncludedValues()
    {
        // Arrange
        const string baseFieldValue = "Some base field value";
        const string subFieldValue = "Some sub field value";
        
        var value = new ValueHidingDefaultFieldWithExcludedField(baseFieldValue, subFieldValue);

        var expectedIncludedValues = new[]
        {
            baseFieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }

    private sealed class ValueHidingDefaultFieldWithExcludedField : ValueWithField
    {
        [Exclude]
        protected readonly string _field;
        
        public ValueHidingDefaultFieldWithExcludedField(string baseField, string subField) : base(baseField)
        {
            _field = subField;
        }
    }
    
    private abstract class ValueWithField : Value<ValueWithField>
    {
        protected readonly string _field;

        protected ValueWithField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHidesExcludedFieldWithExcludedField_THEN_DoNotIncludeFieldsInIncludedValues()
    {
        // Arrange
        var value = new ValueHidingExcludedFieldWithExcludedField("Some base field value", "Some sub field value");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueHidingExcludedFieldWithExcludedField : ValueWithExcludedProtectedField
    {
        [Exclude]
        protected readonly string _field;
        
        public ValueHidingExcludedFieldWithExcludedField(string baseField, string subField) : base(baseField)
        {
            _field = subField;
        }
    }

    [TestMethod]
    public void WHILE_ValueHidesExcludedPropertyWithDefaultProperty_THEN_OnlyIncludeSubclassPropertyInIncludedValues()
    {
        // Arrange
        const string basePropertyValue = "Some base property value";
        const string subPropertyValue = "Some sub property value";
        
        var value = new ValueHidingExcludedPropertyWithDefaultField(basePropertyValue, subPropertyValue);

        var expectedIncludedValues = new[]
        {
            subPropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueHidingExcludedPropertyWithDefaultField : ValueWithExcludedProtectedProperty
    {
        public ValueHidingExcludedPropertyWithDefaultField(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }
        
        protected string Property { get; }
    }
    
    private abstract class ValueWithExcludedProtectedProperty : Value<ValueWithExcludedProtectedProperty>
    {
        protected ValueWithExcludedProtectedProperty(string property)
        {
            Property = property;
        }

        [Exclude]
        protected string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueHidesDefaultPropertyWithExcludedProperty_THEN_OnlyIncludeBaseClassPropertyInIncludedValues()
    {
        // Arrange
        const string basePropertyValue = "Some base property value";
        const string subPropertyValue = "Some sub property value";
        
        var value = new ValueHidingDefaultPropertyWithExcludedProperty(basePropertyValue, subPropertyValue);

        var expectedIncludedValues = new[]
        {
            basePropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues); 
    }

    private sealed class ValueHidingDefaultPropertyWithExcludedProperty : ValueWithProperty
    {
        public ValueHidingDefaultPropertyWithExcludedProperty(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }
        
        [Exclude]
        protected string Property { get; }
    }
    
    private abstract class ValueWithProperty : Value<ValueWithProperty>
    {
        protected ValueWithProperty(string property)
        {
            Property = property;
        }
        
        protected string Property { get; }
    }

    [TestMethod]
    public void WHILE_ValueHidesExcludedPropertyWithExcludedProperty_THEN_DoNotIncludePropertiesInIncludedValues()
    {
        // Arrange
        var value = new ValueHidingExcludedPropertyWithExcludedProperty("Some base property value", "Some sub property value");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueHidingExcludedPropertyWithExcludedProperty : ValueWithExcludedProtectedProperty
    {
        public ValueHidingExcludedPropertyWithExcludedProperty(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }
        
        [Exclude]
        protected string Property { get; }
    }
}