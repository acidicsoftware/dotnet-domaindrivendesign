using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Value;

[TestClass]
public sealed class HashCodeTests
{
    [TestMethod]
    public void WHILE_ValuesHaveNoMembers_THEN_HashCodesAreEquivalent()
    {
        // Arrange
        var firstValue = new EmptyValue();
        var secondValue = new EmptyValue();

        // Act
        var firstValueHashCode = firstValue.GetHashCode();
        var secondValueHashCode = secondValue.GetHashCode();

        // Assert
        Assert.AreEqual(firstValueHashCode, secondValueHashCode);
    }
        
    private sealed class EmptyValue : Value<EmptyValue>
    {
    }

    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("Some value")]
    public void WHILE_ValuesHaveSingleFieldWithSimilarValues_THEN_HashCodesAreEquivalent(string fieldValue)
    {
        // Arrange
        var firstValue = new SingleFieldValue(fieldValue);
        var secondValue = new SingleFieldValue(fieldValue);

        // Act
        var firstValueHashCode = firstValue.GetHashCode();
        var secondValueHashCode = secondValue.GetHashCode();

        // Assert
        Assert.AreEqual(firstValueHashCode, secondValueHashCode);
    }
        
    [DataTestMethod]
    [DataRow(null, "")]
    [DataRow("", "Some value")]
    [DataRow("Some value 1", "Some value 2")]
    public void WHILE_ValuesHaveSingleFieldWithDifferentValues_THEN_HashCodesAreNotEquivalent(string firstValueFieldValue, string secondValueFieldValue)
    {
        // Arrange
        var firstValue = new SingleFieldValue(firstValueFieldValue);
        var secondValue = new SingleFieldValue(secondValueFieldValue);

        // Act
        var firstValueHashCode = firstValue.GetHashCode();
        var secondValueHashCode = secondValue.GetHashCode();

        // Assert
        Assert.AreNotEqual(firstValueHashCode, secondValueHashCode);
    }
        
    public sealed class SingleFieldValue : Value<SingleFieldValue>
    {
        private readonly string _field1;

        public SingleFieldValue(string field1)
        {
            _field1 = field1;
        }
    }

    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow("", "")]
    [DataRow("Some value", "Some value")]
    public void WHILE_ValuesHaveMultipleFieldsWithSimilarValues_THEN_HashCodesAreEquivalent(string firstFieldValue, string secondFieldValue)
    {
        // Arrange
        var firstValue = new MultipleFieldsValue(firstFieldValue, secondFieldValue);
        var secondValue = new MultipleFieldsValue(firstFieldValue, secondFieldValue);
            
        // Act
        var firstValueHashCode = firstValue.GetHashCode();
        var secondValueHashCode = secondValue.GetHashCode();

        // Assert
        Assert.AreEqual(firstValueHashCode, secondValueHashCode);
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
    [DataRow(null, "", "", "")]
    [DataRow("", null, "", "")]
    [DataRow("Some value 1", "Some value 2", "Some value 2", "Some value 1")]
    public void WHILE_ValuesHaveMultipleFieldsWithDifferentValues_THEN_HashCodesAreNotEquivalent(string firstValueFirstFieldValue, string firstValueSecondFieldValue, string secondValueFirstFieldValue, string secondValueSecondFieldValue)
    {
        // Arrange
        var firstValue = new MultipleFieldsValue(firstValueFirstFieldValue, firstValueSecondFieldValue);
        var secondValue = new MultipleFieldsValue(secondValueFirstFieldValue, secondValueSecondFieldValue);
            
        // Act
        var firstValueHashCode = firstValue.GetHashCode();
        var secondValueHashCode = secondValue.GetHashCode();

        // Assert
        Assert.AreNotEqual(firstValueHashCode, secondValueHashCode);
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