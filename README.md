# Acidic Domain Driven Design ![ci branch parameter](https://github.com/acidicsoftware/dotnet-domaindrivendesign/workflows/Continuous%20Integration/badge.svg?branch=trunk)
This library provides base classes useful in projects that conforms to Domain Driven Design principles or projects that just wants to use the tiny types pattern.

The code is heavily inspired by Scott Millett's book Patterns, Principles, and Practices of Domain-Driven Design.

## Classes
The library defines three different base classes.

* Entity
* Value
* TinyValue

## Entity
The base class for entities and aggregate roots.

An Entity is defined by having a unique identifier and this identifier alone makes an entity unique. If two entities share the same identifier, they are considered equal, even if the other data contained in the entities are different.

```csharp
public sealed class Basket : Entity<Guid> {

  public Address InvoiceAddress { get; }
  public Address DeliveryAddress { get; }
  
  /* More fields */

  public Basket(guid identifier) : base(identifier)
  {
  }
} 
```

From outside the class, the entity identifier is accessible via the `Identifier` property.

```csharp
var basket = new Basket(identifier);
var basketIdentifier = basket.Identifier;
```

The `Equals()` method is implemented to only compare the two entities identifiers. No other field are taken into consideration when comparing entities.

The `==` and `!=` operators are also available for comparing entities.

## Value
The base class for value classes.

A value class contains one or more fields (or values). Two instances of the same value type are consideres to be equal if and only if, the corresponding fields in each instance has the same values.

```csharp
public sealed class Address : Value<Address> {

  public string Street { get; }
  public string HouseNumber { get; }
  public string Floor { get; }
  public string PostalCode { get; }
  
  /* More fields */
  
  protected override object[] PropertiesForEqualityCheck => new object[] { Street, HouseNumber, Floor, PostalCode };

  public Address(string street, string houseNumber, string floor, string postalCode)
  {
    Street = street;
    HouseNumber = houseNumber;
    Floor = floor;
    PostalCode = postalCode;
  }
} 
```

The abstract property `PropertiesForEqualityCheck` defines what fields makes the value class unique. The fields included in this array, will be use in equality checks and will influence the result, when two values objects of the same type are compared using the `Equals()` method.

The `==` and `!=` operators are also available for comparing values types.

## TinyValue

Coming soon.

*© Copyright 2021 Michel Gammelgaard. All rights reserved. Provided under the [MIT license](LICENSE).*
