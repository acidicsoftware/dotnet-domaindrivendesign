using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Acidic.DomainDrivenDesign.IntegrationTests.Value;

[TestClass]
public sealed class ValueWithNestedValueTests
{
    [TestMethod]
    public void WHILE_ValueHasNestedValues_WHEN_AllFieldsAreEqual_THEN_ValuesAreEqual()
    {
        // Arrange
        var customerIdentifier = Guid.Parse("e17bbe95-b5b7-4b37-93ad-cded9fbbebf5");
        const string streetName = "Some street name";
        const string zipCode = "Some zip code";
        const string city = "Some city";
        
        var firstValue = new Customer(new CustomerIdentifier(customerIdentifier), new Address(streetName, zipCode, city));
        var secondValue = new Customer(new CustomerIdentifier(customerIdentifier), new Address(streetName, zipCode, city));
        
        // Act
        var valuesAreEqual = firstValue.Equals(secondValue);
        
        // Assert
        Assert.IsTrue(valuesAreEqual);
    }
    
    [TestMethod]
    public void WHILE_ValueHasNestedValues_WHEN_SingleFieldAreDifferent_THEN_ValuesAreNotEqual()
    {
        // Arrange
        var firstCustomerIdentifier = Guid.Parse("e17bbe95-b5b7-4b37-93ad-cded9fbbebf5");
        var secondCustomerIdentifier = Guid.Parse("500c9f18-4d93-42e5-b3c6-3e97183526dd");
        const string streetName = "Some street name";
        const string zipCode = "Some zip code";
        const string city = "Some city";
        
        var firstValue = new Customer(new CustomerIdentifier(firstCustomerIdentifier), new Address(streetName, zipCode, city));
        var secondValue = new Customer(new CustomerIdentifier(secondCustomerIdentifier), new Address(streetName, zipCode, city));
        
        // Act
        var valuesAreEqual = firstValue.Equals(secondValue);
        
        // Assert
        Assert.IsFalse(valuesAreEqual);
    }
    
    private sealed class Customer
    {
        public readonly CustomerIdentifier CustomerIdentifier;
        public readonly Address Address;

        public Customer(CustomerIdentifier customerIdentifier, Address address)
        {
            CustomerIdentifier = customerIdentifier;
            Address = address;
        }
    }
    
    private sealed class CustomerIdentifier : Value<CustomerIdentifier>
    {
        public readonly Guid Identifier;

        public CustomerIdentifier(Guid identifier)
        {
            Identifier = identifier;
        }
    }

    private sealed class Address : Value<Address>
    {
        public readonly string StreetName;
        public readonly string ZipCode;
        public readonly string City;

        public Address(string streetName, string zipCode, string city)
        {
            StreetName = streetName;
            ZipCode = zipCode;
            City = city;
        }
    }
}