using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.ManualValue;

[TestClass]
public sealed class CompareValuesTests
{
    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow("", null)]
    [DataRow(null, "")]
    [DataRow("", "")]
    [DataRow("Value 1", "Value 2")]
    [DataRow("Value 2", "Value 1")]
    public void WHILE_AllFieldsInMultiFieldValueHaveEquivalentValues_WHEN_UsingExplicitEqualsMethod_THEN_ValuesAreEquivalent(string firstFieldValue, string secondFieldValue)
    {
        // Arrange
        var firstValue = new MultipleFieldsValue(firstFieldValue, secondFieldValue);
        var secondValue = new MultipleFieldsValue(firstFieldValue, secondFieldValue);

        // Act
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsTrue(valuesAreEquivalent);
    }

    [DataTestMethod]
    [DataRow("", null, null, null)]
    [DataRow(null, "", null, null)]
    [DataRow(null, null, "", null)]
    [DataRow(null, null, null, "")]
    [DataRow("", "", null, null)]
    [DataRow(null, null, "", "")]
    [DataRow("", "", "", null)]
    [DataRow("", "", null, "")]
    [DataRow("", null, "", "")]
    [DataRow(null, "", "", "")]
    public void WHILE_FieldsInMultiFieldValueHaveDifferentValues_WHEN_UsingExplicitEqualsMethod_THEN_ValuesAreNotEquivalent(string firstValueFirstFieldValue, string firstValueSecondFieldValue, string secondValueFirstFieldValue, string secondValueSecondFieldValue)
    {
        // Arrange
        var firstValue = new MultipleFieldsValue(firstValueFirstFieldValue, firstValueSecondFieldValue);
        var secondValue = new MultipleFieldsValue(secondValueFirstFieldValue, secondValueSecondFieldValue);

        // Act
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsFalse(valuesAreEquivalent);
    }

    [TestMethod]
    public void WHILE_InputValueIsNull_WHEN_UsingExplicitEqualsMethod_THEN_ValuesAreNotEquivalent()
    {
        // Arrange
        var firstValue = new MultipleFieldsValue("First field value", "Second field value");
        var secondValue = null as MultipleFieldsValue;

        // Act
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsFalse(valuesAreEquivalent);
    }
    
    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow("", null)]
    [DataRow(null, "")]
    [DataRow("", "")]
    [DataRow("Value 1", "Value 2")]
    [DataRow("Value 2", "Value 1")]
    public void WHILE_AllFieldsInMultiFieldValueHaveEquivalentValues_WHEN_UsingImplicitEqualsMethod_THEN_ValuesAreEquivalent(string firstFieldValue, string secondFieldValue)
    {
        // Arrange
        var firstValue = new MultipleFieldsValue(firstFieldValue, secondFieldValue);
        var secondValue = new MultipleFieldsValue(firstFieldValue, secondFieldValue) as object;

        // Act
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsTrue(valuesAreEquivalent);
    }

    [DataTestMethod]
    [DataRow("", null, null, null)]
    [DataRow(null, "", null, null)]
    [DataRow(null, null, "", null)]
    [DataRow(null, null, null, "")]
    [DataRow("", "", null, null)]
    [DataRow(null, null, "", "")]
    [DataRow("", "", "", null)]
    [DataRow("", "", null, "")]
    [DataRow("", null, "", "")]
    [DataRow(null, "", "", "")]
    public void WHILE_FieldsInMultiFieldValueHaveDifferentValues_WHEN_UsingImplicitEqualsMethod_THEN_ValuesAreNotEquivalent(string firstValueFirstFieldValue, string firstValueSecondFieldValue, string secondValueFirstFieldValue, string secondValueSecondFieldValue)
    {
        // Arrange
        var firstValue = new MultipleFieldsValue(firstValueFirstFieldValue, firstValueSecondFieldValue);
        var secondValue = new MultipleFieldsValue(secondValueFirstFieldValue, secondValueSecondFieldValue) as object;

        // Act
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsFalse(valuesAreEquivalent);
    }

    [TestMethod]
    public void WHILE_InputValueIsNull_WHEN_UsingImplicitEqualsMethod_THEN_ValuesAreNotEquivalent()
    {
        // Arrange
        var firstValue = new MultipleFieldsValue("First field value", "Second field value");
        var secondValue = null as object;

        // Act
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsFalse(valuesAreEquivalent);
    }
    
    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow("", null)]
    [DataRow(null, "")]
    [DataRow("", "")]
    [DataRow("Value 1", "Value 2")]
    [DataRow("Value 2", "Value 1")]
    public void WHILE_AllFieldsInMultiFieldValueHaveEquivalentValues_WHEN_UsingEqualsOperator_THEN_ValuesAreEquivalent(string firstFieldValue, string secondFieldValue)
    {
        // Arrange
        var firstValue = new MultipleFieldsValue(firstFieldValue, secondFieldValue);
        var secondValue = new MultipleFieldsValue(firstFieldValue, secondFieldValue);

        // Act
        var valuesAreEquivalent = firstValue == secondValue;

        // Assert
        Assert.IsTrue(valuesAreEquivalent);
    }
    
    [DataTestMethod]
    [DataRow("", null, null, null)]
    [DataRow(null, "", null, null)]
    [DataRow(null, null, "", null)]
    [DataRow(null, null, null, "")]
    [DataRow("", "", null, null)]
    [DataRow(null, null, "", "")]
    [DataRow("", "", "", null)]
    [DataRow("", "", null, "")]
    [DataRow("", null, "", "")]
    [DataRow(null, "", "", "")]
    public void WHILE_FieldsInMultiFieldValueHaveDifferentValues_WHEN_UsingEqualsOperator_THEN_ValuesAreNotEquivalent(string firstValueFirstFieldValue, string firstValueSecondFieldValue, string secondValueFirstFieldValue, string secondValueSecondFieldValue)
    {
        // Arrange
        var firstValue = new MultipleFieldsValue(firstValueFirstFieldValue, firstValueSecondFieldValue);
        var secondValue = new MultipleFieldsValue(secondValueFirstFieldValue, secondValueSecondFieldValue);

        // Act
        var valuesAreEquivalent = firstValue == secondValue;

        // Assert
        Assert.IsFalse(valuesAreEquivalent);
    }

    [TestMethod]
    public void WHILE_LeftSideValueIsNull_WHEN_UsingEqualsOperator_THEN_ValuesAreNotEquivalent()
    {
        // Arrange
        var firstValue = null as MultipleFieldsValue;
        var secondValue = new MultipleFieldsValue("Field 1", "Field 2");

        // Act
        var valuesAreEquivalent = firstValue == secondValue;

        // Assert
        Assert.IsFalse(valuesAreEquivalent);
    }

    [TestMethod]
    public void WHILE_RightSideValueIsNull_WHEN_UsingEqualsOperator_THEN_ValuesAreNotEquivalent()
    {
        // Arrange
        var firstValue = new MultipleFieldsValue("Field 1", "Field 2");
        var secondValue = null as MultipleFieldsValue;

        // Act
        var valuesAreEquivalent = firstValue == secondValue;

        // Assert
        Assert.IsFalse(valuesAreEquivalent);
    }

    [TestMethod]
    public void WHILE_BothSidesValuesAreNull_WHEN_UsingEqualsOperator_THEN_ValuesAreEquivalent()
    {
        // Arrange
        var firstValue = null as MultipleFieldsValue;
        var secondValue = null as MultipleFieldsValue;

        // Act
        var valuesAreEquivalent = firstValue == secondValue;

        // Assert
        Assert.IsTrue(valuesAreEquivalent);
    }

    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow("", null)]
    [DataRow(null, "")]
    [DataRow("", "")]
    [DataRow("Value 1", "Value 2")]
    [DataRow("Value 2", "Value 1")]
    public void WHILE_AllFieldsInMultiFieldValueHaveEquivalentValues_WHEN_UsingNotEqualsOperator_THEN_ValuesAreNotDifferent(string firstFieldValue, string secondFieldValue)
    {
        // Arrange
        var firstValue = new MultipleFieldsValue(firstFieldValue, secondFieldValue);
        var secondValue = new MultipleFieldsValue(firstFieldValue, secondFieldValue);

        // Act
        var valuesAreNotEquivalent = firstValue != secondValue;

        // Assert
        Assert.IsFalse(valuesAreNotEquivalent);
    }

    [DataTestMethod]
    [DataRow("", null, null, null)]
    [DataRow(null, "", null, null)]
    [DataRow(null, null, "", null)]
    [DataRow(null, null, null, "")]
    [DataRow("", "", null, null)]
    [DataRow(null, null, "", "")]
    [DataRow("", "", "", null)]
    [DataRow("", "", null, "")]
    [DataRow("", null, "", "")]
    [DataRow(null, "", "", "")]
    public void WHILE_FieldsInMultiFieldValueHaveDifferentValues_WHEN_UsingNotEqualsOperator_THEN_ValuesAreDifferent(string firstValueFirstFieldValue, string firstValueSecondFieldValue, string secondValueFirstFieldValue, string secondValueSecondFieldValue)
    {
        // Arrange
        var firstValue = new MultipleFieldsValue(firstValueFirstFieldValue, firstValueSecondFieldValue);
        var secondValue = new MultipleFieldsValue(secondValueFirstFieldValue, secondValueSecondFieldValue);

        // Act
        var valuesAreNotEquivalent = firstValue != secondValue;

        // Assert
        Assert.IsTrue(valuesAreNotEquivalent);
    }
    
    private sealed class MultipleFieldsValue : ManualValue<MultipleFieldsValue>
    {
        private readonly string _field1;
        private readonly string _field2;

        public MultipleFieldsValue(string field1, string field2)
        {
            _field1 = field1;
            _field2 = field2;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { _field1, _field2 };
    }

    [TestMethod]
    public void WHILE_ValueHasFieldThatIsNotIncluded_WHEN_IgnoredFieldValuesAreEqual_THEN_ValuesAreEqual()
    {
        // Arrange
        const string includedField = "Some included field value";
        const string ignoredField = "Some ignored field value";
        
        var firstValue = new ValueWithIgnoredField(includedField, ignoredField);
        var secondValue = new ValueWithIgnoredField(includedField, ignoredField);

        // Act
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsTrue(valuesAreEquivalent);
    }
    
    [TestMethod]
    public void WHILE_ValueHasFieldThatIsNotIncluded_WHEN_IgnoredFieldValuesAreDifferent_THEN_ValuesAreEqual()
    {
        // Arrange
        const string includedField = "Some included field value";
        const string ignoredFieldInFirstValue = "The ignored field in the first value";
        const string ignoredFieldInSecondValue = "The ignored field in the second value";
        
        var firstValue = new ValueWithIgnoredField(includedField, ignoredFieldInFirstValue);
        var secondValue = new ValueWithIgnoredField(includedField, ignoredFieldInSecondValue);

        // Act
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsTrue(valuesAreEquivalent);
    }
    
    [TestMethod]
    public void WHILE_ValueHasFieldThatIsNotIncluded_WHEN_IncludedFieldValuesAreDifferent_THEN_ValuesAreNotEqual()
    {
        // Arrange
        const string includedFieldInFirstValue = "The included field in the first value";
        const string includedFieldInSecondValue = "The included field in the second value";
        const string ignoredField = "Some ignored field value";
        
        var firstValue = new ValueWithIgnoredField(includedFieldInFirstValue, ignoredField);
        var secondValue = new ValueWithIgnoredField(includedFieldInSecondValue, ignoredField);

        // Act
        var valuesAreEquivalent = firstValue.Equals(secondValue);

        // Assert
        Assert.IsFalse(valuesAreEquivalent);
    }
    
    private sealed class ValueWithIgnoredField : ManualValue<ValueWithIgnoredField>
    {
        private readonly string _includedField;
        private readonly string _ignoredField;

        public ValueWithIgnoredField(string includedField, string ignoredField)
        {
            _includedField = includedField;
            _ignoredField = ignoredField;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { _includedField };
    }
}