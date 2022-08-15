using System.Linq;
using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class ExcludeValueTests
{
    [TestMethod]
    public void WHILE_ValueHasExcludedPrivateField_THEN_DoNotIncludeFieldInIncludedValues()
    {
        // Arrange
        var value = new ValueWithExcludedPrivateField("This is a field.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithExcludedPrivateField : Value<ValueWithExcludedPrivateField>
    {
        [Exclude]
        private readonly string _field;

        public ValueWithExcludedPrivateField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasExcludedProtectedField_THEN_DoNotIncludeFieldInIncludedValues()
    {
        // Arrange
        var value = new ValueWithExcludedProtectedField("This is a field.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private class ValueWithExcludedProtectedField : Value<ValueWithExcludedProtectedField>
    {
        [Exclude]
        protected readonly string _field;

        public ValueWithExcludedProtectedField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasExcludedPublicField_THEN_DoNotIncludeFieldInIncludedValues()
    {
        // Arrange
        var value = new ValueWithExcludedPublicField("This is a field.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithExcludedPublicField : Value<ValueWithExcludedPublicField>
    {
        [Exclude]
        public readonly string _field;

        public ValueWithExcludedPublicField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasExcludedPrivateProperty_THEN_DoNotIncludePropertyInIncludedValues()
    {
        // Arrange
        var value = new ValueWithExcludedPrivateProperty("This is a property.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithExcludedPrivateProperty : Value<ValueWithExcludedPrivateProperty>
    {
        public ValueWithExcludedPrivateProperty(string property)
        {
            Property = property;
        }
        
        [Exclude]
        private string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueHasExcludedProtectedProperty_THEN_DoNotIncludePropertyInIncludedValues()
    {
        // Arrange
        var value = new ValueWithExcludedProtectedProperty("This is a property.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private class ValueWithExcludedProtectedProperty : Value<ValueWithExcludedProtectedProperty>
    {
        public ValueWithExcludedProtectedProperty(string property)
        {
            Property = property;
        }
        
        [Exclude]
        protected string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueHasExcludedPublicProperty_THEN_DoNotIncludePropertyInIncludedValues()
    {
        // Arrange
        var value = new ValueWithExcludedPublicProperty("This is a property.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithExcludedPublicProperty : Value<ValueWithExcludedPublicProperty>
    {
        public ValueWithExcludedPublicProperty(string property)
        {
            Property = property;
        }
        
        [Exclude]
        public string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueHasMultipleExcludedFields_THEN_DoNotIncludeFieldsInIncludedValues()
    {
        // Arrange
        var value = new ValueWithMultipleExcludedFields("This is the first field.", "This is the second field.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithMultipleExcludedFields : Value<ValueWithMultipleExcludedFields>
    {
        [Exclude]
        private readonly string _firstField;
    
        [Exclude]
        private readonly string _secondField;

        public ValueWithMultipleExcludedFields(string firstField, string secondField)
        {
            _firstField = firstField;
            _secondField = secondField;
        }
    }

    [TestMethod]
    public void WHILE_ValueInheritsExcludedField_THEN_DoNotIncludeFieldInIncludedValues()
    {
        // Arrange
        var value = new ValueInheritingExcludedField("This is a field.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueInheritingExcludedField : BaseValueWithExcludedPrivateField
    {
        public ValueInheritingExcludedField(string field) : base(field)
        {
        }
    }
    
    private abstract class BaseValueWithExcludedPrivateField : Value<BaseValueWithExcludedPrivateField>
    {
        [Exclude]
        private readonly string _field;

        protected BaseValueWithExcludedPrivateField(string field)
        {
            _field = field;
        }
    }

    [TestMethod]
    public void WHILE_ValueWithExcludedFieldInheritsExcludedField_THEN_DoNotIncludeFieldsInIncludedValues()
    {
        // Arrange
        var value = new ValueWithExcludedFieldInheritingExcludedField("This is a base field.", "This is a sub field.");

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);

        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithExcludedFieldInheritingExcludedField : BaseValueWithExcludedPrivateField
    {
        [Exclude]
        private readonly string _subField;
        
        public ValueWithExcludedFieldInheritingExcludedField(string baseField, string subField) : base(baseField)
        {
            _subField = subField;
        }
    }
}