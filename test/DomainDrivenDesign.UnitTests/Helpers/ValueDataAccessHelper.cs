using System;
using System.Reflection;

namespace Acidic.DomainDrivenDesign.UnitTests.Helpers;

internal static class ValueDataAccessHelper
{
    public static object[] GetIncludedValuesFromValueObject<T>(Value<T> value) where T : Value<T>
    {
        var valueBaseType = value.GetType();

        while (valueBaseType != typeof(Value<T>) || valueBaseType.BaseType != typeof(object) || valueBaseType.BaseType.BaseType != null)
        {
            valueBaseType = valueBaseType!.BaseType;
        }
            
        var lazyIncludedValues = valueBaseType
            .GetField("_includedValues", BindingFlags.Instance | BindingFlags.NonPublic)?
            .GetValue(value) as Lazy<object[]>;

        if (lazyIncludedValues == null)
        {
            throw new ApplicationException("Unable to locate the field '_includedValues' in the base value class! Has it been changed?");
        }

        return lazyIncludedValues.Value;
    }
}