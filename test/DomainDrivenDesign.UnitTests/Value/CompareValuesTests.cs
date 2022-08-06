using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

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
    
    private sealed class MultipleFieldsValue : Value<MultipleFieldsValue>
    {
        private readonly string _field1;
        private readonly string _field2;

        public MultipleFieldsValue(string field1, string field2)
        {
            _field1 = field1;
            _field2 = field2;
        }
    }
}