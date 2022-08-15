using System.Linq;
using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class IncludeWithHiddenMembersTests
{
    [TestMethod]
    public void WHILE_ValueHidesIncludedFieldWithDefaultField_THEN_IncludeBothFieldsInIncludedValues()
    {
        // Arrange
        const string baseFieldValue = "Some base field value";
        const string subFieldValue = "Some sub field value";
        
        var value = new ValueHidingIncludedFieldWithDefaultField(baseFieldValue, subFieldValue);

        var expectedIncludedValues = new[]
        {
            subFieldValue,
            baseFieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueHidingIncludedFieldWithDefaultField : ValueWithIncludedProtectedField
    {
        protected readonly string _field;
        
        public ValueHidingIncludedFieldWithDefaultField(string baseField, string subField) : base(baseField)
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
    public void WHILE_ValueHidesDefaultFieldWithIncludedField_THEN_IncludeBothFieldsInIncludedValues()
    {
        // Arrange
        const string baseFieldValue = "Some base field value";
        const string subFieldValue = "Some sub field value";
        
        var value = new ValueHidingDefaultFieldWithIncludedField(baseFieldValue, subFieldValue);

        var expectedIncludedValues = new[]
        {
            subFieldValue,
            baseFieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }

    private sealed class ValueHidingDefaultFieldWithIncludedField : ValueWithField
    {
        [Include]
        protected readonly string _field;
        
        public ValueHidingDefaultFieldWithIncludedField(string baseField, string subField) : base(baseField)
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
    public void WHILE_ValueHidesIncludedFieldWithIncludedField_THEN_IncludeBothFieldsInIncludedValues()
    {
        // Arrange
        const string basePropertyValue = "Some base property value";
        const string subPropertyValue = "Some sub property value";
        
        var value = new ValueHidingIncludedFieldWithIncludedField(basePropertyValue, subPropertyValue);

        var expectedIncludedValues = new[]
        {
            subPropertyValue,
            basePropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues); 
    }

    private sealed class ValueHidingIncludedFieldWithIncludedField : ValueWithIncludedProtectedField
    {
        [Include]
        protected readonly string _field;
        
        public ValueHidingIncludedFieldWithIncludedField(string baseField, string subField) : base(baseField)
        {
            _field = subField;
        }
    }

    [TestMethod]
    public void WHILE_ValueHidesIncludedPropertyWithDefaultProperty_THEN_IncludeBothPropertiesInIncludedValues()
    {
        // Arrange
        const string basePropertyValue = "Some base property value";
        const string subPropertyValue = "Some sub property value";
        
        var value = new ValueHidingIncludedPropertyWithDefaultField(basePropertyValue, subPropertyValue);

        var expectedIncludedValues = new[]
        {
            subPropertyValue,
            basePropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueHidingIncludedPropertyWithDefaultField : ValueWithIncludedProtectedProperty
    {
        public ValueHidingIncludedPropertyWithDefaultField(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }
        
        protected string Property { get; }
    }
    
    private abstract class ValueWithIncludedProtectedProperty : Value<ValueWithIncludedProtectedProperty>
    {
        protected ValueWithIncludedProtectedProperty(string property)
        {
            Property = property;
        }

        [Include]
        protected string Property { get; }
    }

    [TestMethod]
    public void WHILE_ValueHidesDefaultPropertyWithIncludedProperty_THEN_IncludeBothPropertiesInIncludedValues()
    {
        // Arrange
        const string basePropertyValue = "Some base property value";
        const string subPropertyValue = "Some sub property value";
        
        var value = new ValueHidingDefaultPropertyWithIncludedProperty(basePropertyValue, subPropertyValue);

        var expectedIncludedValues = new[]
        {
            subPropertyValue,
            basePropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues); 
    }

    private sealed class ValueHidingDefaultPropertyWithIncludedProperty : ValueWithProperty
    {
        public ValueHidingDefaultPropertyWithIncludedProperty(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }
        
        [Include]
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
    public void WHILE_ValueHidesIncludedPropertyWithIncludedProperty_THEN_IncludeBothPropertiesInIncludedValues()
    {
        // Arrange
        const string basePropertyValue = "Some base property value";
        const string subPropertyValue = "Some sub property value";
        
        var value = new ValueHidingIncludedPropertyWithIncludedProperty(basePropertyValue, subPropertyValue);

        var expectedIncludedValues = new[]
        {
            subPropertyValue,
            basePropertyValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues); 
    }

    private sealed class ValueHidingIncludedPropertyWithIncludedProperty : ValueWithIncludedProtectedProperty
    {
        public ValueHidingIncludedPropertyWithIncludedProperty(string baseProperty, string subProperty) : base(baseProperty)
        {
            Property = subProperty;
        }
        
        [Include]
        protected string Property { get; }
    }
}