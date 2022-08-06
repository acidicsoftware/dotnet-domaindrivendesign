using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.IntegrationTests.Value;

[TestClass]
public sealed class SimpleValueWithPropertiesTests
{
    [DataTestMethod]
    [DataRow("John", "Connor", 10U, "John", "Connor", 10U, true)]
    [DataRow("Bob", "Connor", 10U, "John", "Connor", 10U, false)]
    [DataRow("John", "Connor", 10U, "Bob", "Connor", 10U, false)]
    [DataRow("John", "Bing", 10U, "John", "Connor", 10U, false)]
    [DataRow("John", "Connor", 10U, "John", "Bing", 10U, false)]
    [DataRow("John", "Connor", 9U, "John", "Connor", 10U, false)]
    [DataRow("John", "Connor", 10U, "John", "Connor", 9U, false)]
    [DataRow("Connor", "John", 10U, "John", "Connor", 9U, false)]
    public void WHILE_ValueContainsSimpleProperties_THEN_ValuesAreEqualIfAllPropertiesAreEqual(string firstFirstName, string firstLastName, uint firstAge, string secondFirstName, string secondLastName, uint secondAge, bool expectedValuesAreEqual)
    {
        // Arrange
        var firstValue = new SimpleValue(firstFirstName, firstLastName, firstAge);
        var secondValue = new SimpleValue(secondFirstName, secondLastName, secondAge);
        
        // Act
        var actualValuesAreEqual = firstValue.Equals(secondValue);
        
        // Assert
        Assert.AreEqual(expectedValuesAreEqual, actualValuesAreEqual);
    }
    
    private sealed class SimpleValue : Value<SimpleValue>
    {
        public SimpleValue(string firstName, string lastName, uint age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public uint Age { get; }
    }
}