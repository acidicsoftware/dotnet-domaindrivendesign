using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.ManualValue;

[TestClass]
public sealed class CompareNestedValuesTests
{
    [TestMethod]
    public void WHILE_OuterValuesAreEquivalent_NestedValuesAreEquivalent_WHEN_ComparingValues_THEN_ValuesAreEquivalent()
    {
        // Arrange
        const string firstValueOuterFieldValue = "Outer field value";
        const string firstValueNestedFieldValue = "Nested field value";
        const string secondValueOuterFieldValue = firstValueOuterFieldValue;
        const string secondValueNestedFieldValue = firstValueNestedFieldValue;

        var firstValue = new OuterValue(firstValueOuterFieldValue, new NestedValue(firstValueNestedFieldValue));
        var secondValue = new OuterValue(secondValueOuterFieldValue, new NestedValue(secondValueNestedFieldValue));

        // Assert
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsTrue(valuesAreEquivalent);
    }

    [TestMethod]
    public void WHILE_OuterValuesAreDifferent_NestedValuesAreEquivalent_WHEN_ComparingValues_THEN_ValuesAreDifferent()
    {
        // Arrange
        const string firstValueOuterFieldValue = "Outer field value";
        const string firstValueNestedFieldValue = "Nested field value";
        const string secondValueOuterFieldValue = "Different outer field value";
        const string secondValueNestedFieldValue = firstValueNestedFieldValue;

        var firstValue = new OuterValue(firstValueOuterFieldValue, new NestedValue(firstValueNestedFieldValue));
        var secondValue = new OuterValue(secondValueOuterFieldValue, new NestedValue(secondValueNestedFieldValue));

        // Assert
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsFalse(valuesAreEquivalent);
    }

    [TestMethod]
    public void WHILE_OuterValuesAreEquivalent_NestedValuesAreDifferent_WHEN_ComparingValues_THEN_ValuesAreDifferent()
    {
        // Arrange
        const string firstValueOuterFieldValue = "Outer field value";
        const string firstValueNestedFieldValue = "Nested field value";
        const string secondValueOuterFieldValue = firstValueOuterFieldValue;
        const string secondValueNestedFieldValue = "Different nested field value";

        var firstValue = new OuterValue(firstValueOuterFieldValue, new NestedValue(firstValueNestedFieldValue));
        var secondValue = new OuterValue(secondValueOuterFieldValue, new NestedValue(secondValueNestedFieldValue));

        // Assert
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsFalse(valuesAreEquivalent);
    }

    [TestMethod]
    public void WHILE_OuterValuesAreDifferent_NestedValuesAreDifferent_WHEN_ComparingValues_THEN_ValuesAreDifferent()
    {
        // Arrange
        const string firstValueOuterFieldValue = "Outer field value";
        const string firstValueNestedFieldValue = "Nested field value";
        const string secondValueOuterFieldValue = "Different outer field value";
        const string secondValueNestedFieldValue = "Different nested field value";

        var firstValue = new OuterValue(firstValueOuterFieldValue, new NestedValue(firstValueNestedFieldValue));
        var secondValue = new OuterValue(secondValueOuterFieldValue, new NestedValue(secondValueNestedFieldValue));

        // Assert
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsFalse(valuesAreEquivalent);
    }
    
    private sealed class OuterValue : ManualValue<OuterValue>
    {
        private readonly string _dataField;
        private readonly  NestedValue _nestedValue;

        public OuterValue(string dataField, NestedValue nestedValue)
        {
            _dataField = dataField;
            _nestedValue = nestedValue;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { _dataField, _nestedValue };
    }

    private sealed class NestedValue : ManualValue<NestedValue>
    {
        private readonly  string _nestedField;

        public NestedValue(string nestedField)
        {
            _nestedField = nestedField;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { _nestedField };
    }
}