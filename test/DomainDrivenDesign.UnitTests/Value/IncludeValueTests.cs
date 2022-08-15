using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class IncludeValueTests
{
    [TestMethod]
    public void WHILE_ValueHasIncludedPrivateField_THEN_IncludeFieldInIncludedValues()
    {
        // Arrange
        const string fieldValue = "This is a field.";
        var expectedIncludedValues = new object[]
        {
            fieldValue
        };
        
        var value = new ValueWithIncludedPrivateField(fieldValue);

        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithIncludedPrivateField : Value<ValueWithIncludedPrivateField>
    {
        [Include]
        private readonly string _field;

        public ValueWithIncludedPrivateField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasIncludedProtectedField_THEN_IncludeFieldInIncludedValues()
    {
        // Arrange
        const string fieldValue = "This is a field.";
        var expectedIncludedValues = new object[]
        {
            fieldValue
        };
        
        var value = new ValueWithIncludedProtectedField(fieldValue);

        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithIncludedProtectedField : Value<ValueWithIncludedProtectedField>
    {
        [Include]
        protected readonly string _field;

        public ValueWithIncludedProtectedField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasIncludedPublicField_THEN_IncludeFieldInIncludedValues()
    {
        // Arrange
        const string fieldValue = "This is a field.";
        var expectedIncludedValues = new object[]
        {
            fieldValue
        };
        
        var value = new ValueWithIncludedPublicField(fieldValue);

        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithIncludedPublicField : Value<ValueWithIncludedPublicField>
    {
        [Include]
        public readonly string _field;

        public ValueWithIncludedPublicField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasIncludedPrivateProperty_THEN_IncludePropertyInIncludedValues()
    {
        // Arrange
        const string propertyValue = "This is a property.";
        var expectedIncludedValues = new object[]
        {
            propertyValue
        };
        
        var value = new ValueWithIncludedPrivateProperty(propertyValue);

        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithIncludedPrivateProperty : Value<ValueWithIncludedPrivateProperty>
    {
        public ValueWithIncludedPrivateProperty(string property)
        {
            Property = property;
        }
        
        [Include]
        private string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueHasIncludedProtectedProperty_THEN_IncludePropertyInIncludedValues()
    {
        // Arrange
        const string propertyValue = "This is a property.";
        var expectedIncludedValues = new object[]
        {
            propertyValue
        };
        
        var value = new ValueWithIncludedProtectedProperty(propertyValue);

        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithIncludedProtectedProperty : Value<ValueWithIncludedProtectedProperty>
    {
        public ValueWithIncludedProtectedProperty(string property)
        {
            Property = property;
        }
        
        [Include]
        protected string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueHasIncludedPublicProperty_THEN_IncludePropertyInIncludedValues()
    {
        // Arrange
        const string propertyValue = "This is a property.";
        var expectedIncludedValues = new object[]
        {
            propertyValue
        };
        
        var value = new ValueWithIncludedPublicProperty(propertyValue);

        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithIncludedPublicProperty : Value<ValueWithIncludedPublicProperty>
    {
        public ValueWithIncludedPublicProperty(string property)
        {
            Property = property;
        }
        
        [Include]
        public string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueInheritsIncludedField_THEN_IncludeFieldInIncludedValues()
    {
        // Arrange
        const string propertyValue = "This is a property.";
        var expectedIncludedValues = new object[]
        {
            propertyValue
        };
        
        var value = new ValueInheritingIncludedField(propertyValue);

        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueInheritingIncludedField : ValueWithIncludedField
    {
        public ValueInheritingIncludedField(string field) : base(field)
        {
        }
    }
    
    private abstract class ValueWithIncludedField : Value<ValueWithIncludedField>
    {
        [Include]
        private readonly string _field;

        protected ValueWithIncludedField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueWithIncludedFieldInheritsIncludedField_THEN_IncludeBothFieldsInIncludedValues()
    {
        // Arrange
        const string baseFieldValue = "This is a base field.";
        const string subFieldValue = "This is a sub field.";
        var expectedIncludedValues = new object[]
        {
            subFieldValue,
            baseFieldValue
        };
        
        var value = new ValueWithIncludedFieldInheritingIncludedField(baseFieldValue, subFieldValue);

        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithIncludedFieldInheritingIncludedField : ValueWithIncludedField
    {
        [Include]
        private readonly string _subField;
        
        public ValueWithIncludedFieldInheritingIncludedField(string baseField, string subField) : base(baseField)
        {
            _subField = subField;
        }
    }
}