using System.Linq;
using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class MembersNotIncludedTests
{
    [TestMethod]
    public void WHILE_ValueHasPrivateStaticField_THEN_DoNotIncludeFieldInIncludedValues()
    {
        // Arrange
        var value = new ValueWithPrivateStaticField();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueWithPrivateStaticField : Value<ValueWithPrivateStaticField>
    {
        private static readonly string Field = "Some magic private static field value";
    }
    
    [TestMethod]
    public void WHILE_ValueHasProtectedStaticField_THEN_DoNotIncludeFieldInIncludedValues()
    {
        // Arrange
        var value = new ValueWithProtectedStaticField();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueWithProtectedStaticField : Value<ValueWithProtectedStaticField>
    {
        protected static readonly string Field = "Some magic protected static field value";
    }
    
    [TestMethod]
    public void WHILE_ValueHasPublicStaticField_THEN_DoNotIncludeFieldInIncludedValues()
    {
        // Arrange
        var value = new ValueWithPublicStaticField();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueWithPublicStaticField : Value<ValueWithPublicStaticField>
    {
        public static readonly string Field = "Some magic public static field value";
    }
    
    [TestMethod]
    public void WHILE_ValueHasPrivateStaticProperty_THEN_DoNotIncludePropertyInIncludedValues()
    {
        // Arrange
        var value = new ValueWithPrivateStaticProperty();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueWithPrivateStaticProperty : Value<ValueWithPrivateStaticProperty>
    {
        private static string Field { get; } = "Some magic private static property value";
    }
    
    [TestMethod]
    public void WHILE_ValueHasProtectedStaticProperty_THEN_DoNotIncludePropertyInIncludedValues()
    {
        // Arrange
        var value = new ValueWithProtectedStaticProperty();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueWithProtectedStaticProperty : Value<ValueWithProtectedStaticProperty>
    {
        protected static string Field { get; } = "Some magic protected static property value";
    }
    
    [TestMethod]
    public void WHILE_ValueHasPublicStaticProperty_THEN_DoNotIncludePropertyInIncludedValues()
    {
        // Arrange
        var value = new ValueWithPublicStaticProperty();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueWithPublicStaticProperty : Value<ValueWithPublicStaticProperty>
    {
        public static string Field { get; } = "Some magic public static property value";
    }
    
    [TestMethod]
    public void WHILE_ValueHasPrivateMethod_THEN_DoNotIncludeMethodReturnValueInIncludedValues()
    {
        // Arrange
        var value = new ValueWithPrivateMethod();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueWithPrivateMethod : Value<ValueWithPrivateMethod>
    {
        private string Method()
        {
            return "Some magic private method value";
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasProtectedMethod_THEN_DoNotIncludeMethodReturnValueInIncludedValues()
    {
        // Arrange
        var value = new ValueWithProtectedMethod();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueWithProtectedMethod : Value<ValueWithProtectedMethod>
    {
        protected string Method()
        {
            return "Some magic protected method value";
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasPublicMethod_THEN_DoNotIncludeMethodReturnValueInIncludedValues()
    {
        // Arrange
        var value = new ValueWithPublicMethod();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueWithPublicMethod : Value<ValueWithPublicMethod>
    {
        public string Method()
        {
            return "Some magic public method value";
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasPrivateStaticMethod_THEN_DoNotIncludeMethodReturnValueInIncludedValues()
    {
        // Arrange
        var value = new ValueWithPrivateStaticMethod();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueWithPrivateStaticMethod : Value<ValueWithPrivateStaticMethod>
    {
        private static string Method()
        {
            return "Some magic private static method value";
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasProtectedStaticMethod_THEN_DoNotIncludeMethodReturnValueInIncludedValues()
    {
        // Arrange
        var value = new ValueWithProtectedStaticMethod();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueWithProtectedStaticMethod : Value<ValueWithProtectedStaticMethod>
    {
        protected static string Method()
        {
            return "Some magic protected static method value";
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasPublicStaticMethod_THEN_DoNotIncludeMethodReturnValueInIncludedValues()
    {
        // Arrange
        var value = new ValueWithPublicStaticMethod();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }

    private sealed class ValueWithPublicStaticMethod : Value<ValueWithPublicStaticMethod>
    {
        public static string Method()
        {
            return "Some magic public static method value";
        }
    }

    [TestMethod]
    public void WHILE_ValueHasPrivateInnerClass_THEN_DoNotIncludeInnerClassInIncludedValues()
    {
        // Arrange
        var value = new ValueWithPrivateInnerClass();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithPrivateInnerClass : Value<ValueWithPrivateInnerClass>
    {
        private class InnerClass
        {
            
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasProtectedInnerClass_THEN_DoNotIncludeInnerClassInIncludedValues()
    {
        // Arrange
        var value = new ValueWithProtectedInnerClass();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithProtectedInnerClass : Value<ValueWithProtectedInnerClass>
    {
        protected class InnerClass
        {
            
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasPublicInnerClass_THEN_DoNotIncludeInnerClassInIncludedValues()
    {
        // Arrange
        var value = new ValueWithPublicInnerClass();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithPublicInnerClass : Value<ValueWithPublicInnerClass>
    {
        public class InnerClass
        {
            
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasPrivateStaticInnerClass_THEN_DoNotIncludeStaticInnerClassInIncludedValues()
    {
        // Arrange
        var value = new ValueWithPrivateStaticInnerClass();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithPrivateStaticInnerClass : Value<ValueWithPrivateStaticInnerClass>
    {
        private static class InnerClass
        {
            
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasProtectedStaticInnerClass_THEN_DoNotIncludeStaticInnerClassInIncludedValues()
    {
        // Arrange
        var value = new ValueWithProtectedStaticInnerClass();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithProtectedStaticInnerClass : Value<ValueWithProtectedStaticInnerClass>
    {
        protected static class InnerClass
        {
            
        }
    }
    
    [TestMethod]
    public void WHILE_ValueHasPublicStaticInnerClass_THEN_DoNotIncludeStaticInnerClassInIncludedValues()
    {
        // Arrange
        var value = new ValueWithPublicStaticInnerClass();

        // Act
        var includedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        Assert.IsFalse(includedValues.Any());
    }
    
    private sealed class ValueWithPublicStaticInnerClass : Value<ValueWithPublicStaticInnerClass>
    {
        public static class InnerClass
        {
            
        }
    }
}