# Domain Driven Design Components
![ci branch parameter](https://github.com/acidicsoftware/dotnet-domaindrivendesign/workflows/Continuous%20Integration/badge.svg?branch=trunk)

This .NET library provides base classes useful in projects that aims to conform to Domain Driven Design principles or projects that just wants to use the tiny types pattern.

The code is heavily inspired by the book Patterns, Principles, and Practices of Domain-Driven Design by Scott Millett.

## Classes
The library defines three different base classes.

* Entity
* Value
* TinyValue

## Entity
Base class for entities and aggregate roots.

An entity is defined by having a unique identifier. This identifier alone makes the entity unique.

If two entities share the same identifier values they are considered equal. This is also true even when the other data contained within the two entities are different.

```csharp
public sealed class Basket : Entity<Guid>
{
  public Address InvoiceAddress { get; }
  public Address? DeliveryAddress { get; }

  public Basket(Guid identifier, Address invoiceAddress, Address? deliveryAddress) : base(identifier)
  {
     InvoiceAddress = invoiceAddress;
     DeliveryAddress = deliveryAddress;
  }
}
```

From outside the class the entity identifier is accessible via the `Identifier` property.

```csharp
var basket = new Basket(identifier);
var basketIdentifier = basket.Identifier;
```

The `Equals()` method is implemented to only compare the two entities identifiers. No other fields are taken into account when comparing.

The `==` and `!=` operators are also available for comparing entities.

## Value
The base class for value classes.

A value class contains one or more fields. Two instances of the same value type are considered to be equal if and only if the corresponding fields in each instance have the same values.

```csharp
public sealed class Address : Value<Address>
{
  private readonly string _street;
  private readonly string _houseNumber;
  private readonly string _floor;
  private readonly string _postalCode;

  public string Street => _street;
  public string HouseNumber => _houseNumber;
  public string Floor => _floor;
  public string PostalCode => _postalCode;
  
  public Address(string street, string houseNumber, string floor, string postalCode)
  {
    _street = street;
    _houseNumber = houseNumber;
    _floor = floor;
    _postalCode = postalCode;
  }
} 
```

The `Value` base class uses reflection to identify the fields used in equality operations. All private instance fields in subclasses of `Value` will by default be part of this list.

To exclude a private instance field from equality checks annotate the field with [IgnoreFieldAttribute](src/DomainDrivenDesign/IgnoreFieldAttribute.cs).

```csharp
public sealed class SomeValue : Value<SomeValue> {

  private readonly string _fieldToInclude;
  
  [IgnoreField]
  private readonly string _fieldToExclude;

  public string FieldToInclude => _fieldToInclude;
  public string FieldToExclude => _fieldToExclude;
  
  public SomeValue(string fieldToInclude, string fieldToExclude)
  {
    _fieldToInclude = fieldToInclude;
    _fieldToExclude = fieldToExclude;
  }
} 
```

The abstract property `PropertiesForEqualityCheck` defines what fields makes the value class unique. The fields included in this array, will be use in equality checks and will influence the result, when two values objects of the same type are compared using the `Equals()` method.

The `==` and `!=` operators are also available for comparing values types.

## TinyValue

Coming soon.

*Copyright © 2022 Michel Gammelgaard, Acidus. All rights reserved. Provided under the [MIT license](LICENSE).*
