using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class DefaultFieldInclusionBehaviorTests
{
    [TestMethod]
    public void WHILE_ValueHasPrivateField_THEN_IncludePrivateFieldInIncludedValues()
    {
        // Arrange
        const string fieldValue = "Some random private field value";
        var value = new ValueWithPrivateField(fieldValue);

        var expectedIncludedValues = new[]
        {
            fieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithPrivateField : Value<ValueWithPrivateField>
    {
        private readonly string _field;

        public ValueWithPrivateField(string field)
        {
            _field = field;
        }
    }

    [TestMethod]
    public void WHILE_ValueHasProtectedField_THEN_IncludeProtectedFieldInIncludedValues()
    {
        // Arrange
        const string fieldValue = "Some random protected field value";
        var value = new ValueWithProtectedField(fieldValue);

        var expectedIncludedValues = new[]
        {
            fieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithProtectedField : Value<ValueWithProtectedField>
    {
        protected readonly string _field;

        public ValueWithProtectedField(string field)
        {
            _field = field;
        }
    }

    [TestMethod]
    public void WHILE_ValueHasPublicField_THEN_IncludePublicFieldInIncludedValues()
    {
        // Arrange
        const string fieldValue = "Some random public field value";
        var value = new ValueWithPublicField(fieldValue);

        var expectedIncludedValues = new[]
        {
            fieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithPublicField : Value<ValueWithPublicField>
    {
        public readonly string _field;

        public ValueWithPublicField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueInheritsPrivateField_THEN_IncludeInheritedPrivateFieldInIncludedValues()
    {
        // Arrange
        const string fieldValue = "Some random inherited private field value";
        var value = new ValueWithInheritedPrivateField(fieldValue);

        var expectedIncludedValues = new[]
        {
            fieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithInheritedPrivateField : BaseValueWithPrivateField
    {
        public ValueWithInheritedPrivateField(string field) : base(field)
        {
        }
    }
    
    private abstract class BaseValueWithPrivateField : Value<BaseValueWithPrivateField>
    {
        private readonly string _field;

        public BaseValueWithPrivateField(string field)
        {
            _field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueInheritsProtectedField_THEN_IncludeInheritedProtectedFieldInIncludedValues()
    {
        // Arrange
        const string fieldValue = "Some random inherited protected field value";
        var value = new ValueWithInheritedProtectedField(fieldValue);

        var expectedIncludedValues = new[]
        {
            fieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithInheritedProtectedField : BaseValueWithProtectedField
    {
        public ValueWithInheritedProtectedField(string field) : base(field)
        {
        }
    }
    
    private abstract class BaseValueWithProtectedField : Value<BaseValueWithProtectedField>
    {
        protected readonly string Field;

        public BaseValueWithProtectedField(string field)
        {
            Field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueInheritsPublicField_THEN_IncludeInheritedPublicFieldInIncludedValues()
    {
        // Arrange
        const string fieldValue = "Some random inherited public field value";
        var value = new ValueWithInheritedPublicField(fieldValue);

        var expectedIncludedValues = new[]
        {
            fieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithInheritedPublicField : BaseValueWithPublicField
    {
        public ValueWithInheritedPublicField(string field) : base(field)
        {
        }
    }
    
    private abstract class BaseValueWithPublicField : Value<BaseValueWithPublicField>
    {
        public readonly string Field;

        public BaseValueWithPublicField(string field)
        {
            Field = field;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasPrivateProperty_THEN_IncludePrivatePropertyInIncludedValues()
    {
        // Arrange
        const string fieldValue = "Some random private property value";
        var value = new ValueWithPrivateProperty(fieldValue);

        var expectedIncludedValues = new[]
        {
            fieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithPrivateProperty : Value<ValueWithPrivateProperty>
    {
        private string Property { get; }

        public ValueWithPrivateProperty(string property)
        {
            Property = property;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasProtectedProperty_THEN_IncludeProtectedPropertyInIncludedValues()
    {
        // Arrange
        const string fieldValue = "Some random protected property value";
        var value = new ValueWithProtectedProperty(fieldValue);

        var expectedIncludedValues = new[]
        {
            fieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithProtectedProperty : Value<ValueWithProtectedProperty>
    {
        protected string PropertyValue { get; }

        public ValueWithProtectedProperty(string propertyValue)
        {
            PropertyValue = propertyValue;
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasPublicProperty_THEN_IncludePublicPropertyInIncludedValues()
    {
        // Arrange
        const string fieldValue = "Some random public property value";
        var value = new ValueWithPublicProperty(fieldValue);

        var expectedIncludedValues = new[]
        {
            fieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithPublicProperty : Value<ValueWithPublicProperty>
    {
        public string Property { get; }

        public ValueWithPublicProperty(string property)
        {
            Property = property;
        }
    }
    
    [TestMethod]
    public void WHILE_InheritedValueHasPrivateProperty_THEN_IncludeInheritedPrivatePropertyInIncludedValues()
    {
        // Arrange
        const string fieldValue = "Some random inherited private property value";
        var value = new ValueWithInheritedPrivateProperty(fieldValue);

        var expectedIncludedValues = new[]
        {
            fieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithInheritedPrivateProperty : BaseValueWithPrivateProperty
    {
        public ValueWithInheritedPrivateProperty(string property) : base(property)
        {
        }
    }
    
    private abstract class BaseValueWithPrivateProperty : Value<BaseValueWithPrivateProperty>
    {
        private string Property { get; }

        public BaseValueWithPrivateProperty(string property)
        {
            Property = property;
        }
    }
    
    [TestMethod]
    public void WHILE_InheritedValueHasProtectedProperty_THEN_IncludeInheritedProtectedPropertyInIncludedValues()
    {
        // Arrange
        const string fieldValue = "Some random inherited protected property value";
        var value = new ValueWithInheritedProtectedProperty(fieldValue);

        var expectedIncludedValues = new[]
        {
            fieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithInheritedProtectedProperty : BaseValueWithProtectedProperty
    {
        public ValueWithInheritedProtectedProperty(string property) : base(property)
        {
        }
    }
    
    private abstract class BaseValueWithProtectedProperty : Value<BaseValueWithProtectedProperty>
    {
        protected string Property { get; }

        public BaseValueWithProtectedProperty(string property)
        {
            Property = property;
        }
    }
    
    [TestMethod]
    public void WHILE_InheritedValueHasPublicProperty_THEN_IncludeInheritedPublicPropertyInIncludedValues()
    {
        // Arrange
        const string fieldValue = "Some random inherited public property value";
        var value = new ValueWithInheritedPublicProperty(fieldValue);

        var expectedIncludedValues = new[]
        {
            fieldValue
        };
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueWithInheritedPublicProperty : BaseValueWithPublicProperty
    {
        public ValueWithInheritedPublicProperty(string property) : base(property)
        {
        }
    }
    
    private abstract class BaseValueWithPublicProperty : Value<BaseValueWithPublicProperty>
    {
        public string Property { get; }

        public BaseValueWithPublicProperty(string property)
        {
            Property = property;
        }
    }
}