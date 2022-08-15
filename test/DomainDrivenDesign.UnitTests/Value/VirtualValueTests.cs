using Acidic.DomainDrivenDesign.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class VirtualValueTests
{
    [TestMethod]
    public void WHILE_ValueOverridesVirtualProperty_THEN_IncludeOnlyOverridingValueInIncludedValues()
    {
        // Arrange
        const string baseClassPropertyValue = "Base class property value";
        const string subclassPropertyValue = "Subclass property value";

        var expectedIncludedValues = new[]
        {
            subclassPropertyValue
        };
        
        var value = new ValueThatOverridesVirtualProperty(baseClassPropertyValue, subclassPropertyValue);
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueThatOverridesVirtualProperty : BaseClassValueWithVirtualProperty
    {
        public ValueThatOverridesVirtualProperty(string basePropertyValue, string subclassPropertyValue) : base(basePropertyValue)
        {
            Property = subclassPropertyValue;
        }

        public override string Property { get; }
    }
    
    [TestMethod]
    public void WHILE_ValueIgnoresVirtualProperty_THEN_IncludeOnlyVirtualPropertyValueInIncludedValues()
    {
        // Arrange
        const string baseClassPropertyValue = "Base class property value";

        var expectedIncludedValues = new[]
        {
            baseClassPropertyValue
        };
        
        var value = new ValueThatIgnoresVirtualProperty(baseClassPropertyValue);
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueThatIgnoresVirtualProperty : BaseClassValueWithVirtualProperty
    {
        public ValueThatIgnoresVirtualProperty(string basePropertyValue) : base(basePropertyValue)
        {
        }
    }

    [TestMethod]
    public void WHILE_ValueHidesVirtualProperty_THEN_IncludeBothBaseClassPropertyAndSubclassPropertyValuesInIncludedValues()
    {
        // Arrange
        const string baseClassPropertyValue = "Base class property value";
        const string subclassPropertyValue = "Subclass property value";

        var expectedIncludedValues = new[]
        {
            subclassPropertyValue,
            baseClassPropertyValue
        };
        
        var value = new ValueThatHidesVirtualProperty(baseClassPropertyValue, subclassPropertyValue);
        
        // Act
        var actualIncludedValues = ValueDataAccessHelper.GetIncludedValuesFromValueObject(value);
        
        // Assert
        CollectionAssert.AreEquivalent(expectedIncludedValues, actualIncludedValues);
    }
    
    private sealed class ValueThatHidesVirtualProperty : BaseClassValueWithVirtualProperty
    {
        public ValueThatHidesVirtualProperty(string basePropertyValue, string subclassPropertyValue) : base(basePropertyValue)
        {
            Property = subclassPropertyValue;
        }

        public string Property { get; }
    }
    
    private abstract class BaseClassValueWithVirtualProperty : Value<BaseClassValueWithVirtualProperty>
    {
        protected BaseClassValueWithVirtualProperty(string basePropertyValue)
        {
            Property = basePropertyValue;
        }

        public virtual string Property { get; }
    }
}