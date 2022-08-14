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
The `Entity` class is the base class for entities and aggregate roots.

An entity is defined by having a unique identifier. This identifier alone makes an entity unique.

Two entities of the same type are considered to be equal if and only if they have the same identifier value. This is also true even when the other data contained within the two entities are different.

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
var basket = new Basket(identifier, invoiceAddress, deliveryAddress);
var basketIdentifier = basket.Identifier;
```

The `Equals()` method is implemented to compare only the identifiers of two entity classes of the same type.
No other members are taken into consideration when comparing entity classes.

The `==` and `!=` operators are also available for comparison operations.

## Value
The `Value` class is the base class for value types.

By default all fields and properties (from now on referred to a **value members**) in a value type, are evaluated when comparing two values of the same type.
This is true no matter which access modifier the value members are decorated with.

Two values of the same type are considered to be equal if and only if all corresponding value members in each instance have the same value.

```csharp
public sealed class Address : Value<Address>
{
  public readonly string Street;
  public readonly string HouseNumber;
  public readonly string Floor;
  public readonly string PostalCode;
  
  public Address(string street, string houseNumber, string floor, string postalCode)
  {
    Street = street;
    HouseNumber = houseNumber;
    Floor = floor;
    PostalCode = postalCode;
  }
} 
```

The `Equals()` method is implemented to compare only included value members of two instances.
All excluded value members are skipped. More on that in the next sections.

The `==` and `!=` operators are also available for comparison operations.

### Value Member State
A value member can be in one of three inclusion states.

| State | Annotation | Description |
| :-- | :-- | :-- |
| Neutral | No Annotation | Value member is included by default. |
| Included | [IncludeAttribute](src/DomainDrivenDesign/IncludeAttribute.cs) | Value member is included |
| Excluded | [ExcludeAttribute](src/DomainDrivenDesign/ExcludeAttribute.cs) | Value member is excluded |

### Excluding Value Members
Annotate a value member with [ExcludeAttribute](src/DomainDrivenDesign/ExcludeAttribute.cs) to exclude it from equality operations.

```csharp
public class Sushi : Value<Sushi> 
{
  public virtual string Name { get; }
  
  [Exclude]
  public virtual double Price  { get; }
  
  public Sushi(string name, double price)
  {
    Name = name;
    Price = price;
  }
}
```

In this case the property `Price` is ignored in all equality operations.

```csharp
var firstSalmonNirigi = new Sushi("Salmon Nigiri", 1.99);
var secondSalmonNirigi = new Sushi("Salmon Nigiri", 0.99);

var salmonNigiriPiecesAreEqual = firstSalmonNirigi == secondSalmonNirigi; // true
```

### Including Value Members
An excluded virtual property can be included in a child class by overriding the property and annotating it with [IncludeAttribute](src/DomainDrivenDesign/IncludeAttribute.cs).

```csharp
public class PriceConsciousSushi : Sushi
{
  [Include]
  public override double Price { get; }
  
  public PriceConsciousSushi(string name, string price) : base(name, price)
  {
    Price = price;
  }
}
```

`PriceConsciousSushi` will in this case behave as if the `Price` property had never been excluded.

```csharp
var firstSalmonNirigi = new PriceConsciousSushi("Salmon Nigiri", 1.99);
var secondSalmonNirigi = new PriceConsciousSushi("Salmon Nigiri", 0.99);

var salmonNigiriPiecesAreEqual = firstSalmonNirigi.Equals(secondSalmonNirigi); // false
```

If the `Price` property had not been explicitly annotated with [IncludeAttribute](src/DomainDrivenDesign/IncludeAttribute.cs) then the exclusion would have been inherited and the price would still have been ignored.

### Inheritance
The inclusion state of value members are inherited by child classes.
If a value member is excluded then it's also excluded in all classes inheriting from this class.

Properties are special value member in that they can be overridden if marked as virtual.
If a property is overridden, the properties are checked one by one starting from the o





Note that if a value member is annotated with both [ExcludeAttribute](src/DomainDrivenDesign/ExcludeAttribute.cs) and [IncludeAttribute](src/DomainDrivenDesign/IncludeAttribute.cs) then the value member will be excluded since an exclude trumps an include.

### Custom Property Backing Fields
Manually implemented backing fields for properties should be excluded manually. Otherwise they'll be included in equality operation.

```csharp
public class Sushi : Value<Sushi> 
{
  [Exclude]
  private readonly string _name;

  public virtual string Name => _name;
    
  public Sushi(string name)
  {
    _name = name;
  }
}
```

Technically it wouldn't matter whether or not the backing field in this example was excluded, but it's important to keep in mind that all fields and properties are included in equality operations by default.

Backing fields automatically created by the compiler for properties are always ignored.

## TinyValue

Coming soon.

*Copyright © 2022 Michel Gammelgaard, Acidus. All rights reserved. Provided under the [MIT license](LICENSE).*
