using System;
using System.Runtime.Serialization;

namespace Acidic.DomainDrivenDesign
{
    [Serializable]
    public sealed class TinyValue<T> : Value<TinyValue<T>>, ISerializable
    {
        public T Value { get; }

        public TinyValue(T value)
        {
            Value = value;
        }

        public TinyValue(SerializationInfo info, StreamingContext context)
        {
            var value = info.GetValue(nameof(Value), typeof(T));
            Value = value == default ? default : (T)value;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { Value };

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Value), Value, typeof(T));
        }
    }

    public sealed class TinyValue<T1, T2> : Value<TinyValue<T1, T2>>, ISerializable
    {
        public T1 Value1 { get; }
        public T2 Value2 { get; }

        public TinyValue(T1 value1, T2 value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public TinyValue(SerializationInfo info, StreamingContext context)
        {
            var value1 = info.GetValue(nameof(Value1), typeof(T1));
            var value2 = info.GetValue(nameof(Value2), typeof(T2));
            
            Value1 = value1 == default ? default : (T1)value1;
            Value2 = value2 == default ? default : (T2)value2;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { Value1, Value2 };

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Value1), Value1, typeof(T1));
            info.AddValue(nameof(Value2), Value2, typeof(T2));
        }
    }

    public sealed class TinyValue<T1, T2, T3> : Value<TinyValue<T1, T2, T3>>, ISerializable
    {
        public T1 Value1 { get; }
        public T2 Value2 { get; }
        public T3 Value3 { get; }

        public TinyValue(T1 value1, T2 value2, T3 value3)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }

        public TinyValue(SerializationInfo info, StreamingContext context)
        {
            var value1 = info.GetValue(nameof(Value1), typeof(T1));
            var value2 = info.GetValue(nameof(Value2), typeof(T2));
            var value3 = info.GetValue(nameof(Value3), typeof(T3));

            Value1 = value1 == default ? default : (T1)value1;
            Value2 = value2 == default ? default : (T2)value2;
            Value3 = value3 == default ? default : (T3)value3;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { Value1, Value2, Value3 };

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Value1), Value1, typeof(T1));
            info.AddValue(nameof(Value2), Value2, typeof(T2));
            info.AddValue(nameof(Value3), Value3, typeof(T3));
        }
    }

    public sealed class TinyValue<T1, T2, T3, T4> : Value<TinyValue<T1, T2, T3, T4>>, ISerializable
    {
        public T1 Value1 { get; }
        public T2 Value2 { get; }
        public T3 Value3 { get; }
        public T4 Value4 { get; }

        public TinyValue(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
        }

        public TinyValue(SerializationInfo info, StreamingContext context)
        {
            var value1 = info.GetValue(nameof(Value1), typeof(T1));
            var value2 = info.GetValue(nameof(Value2), typeof(T2));
            var value3 = info.GetValue(nameof(Value3), typeof(T3));
            var value4 = info.GetValue(nameof(Value4), typeof(T4));

            Value1 = value1 == default ? default : (T1)value1;
            Value2 = value2 == default ? default : (T2)value2;
            Value3 = value3 == default ? default : (T3)value3;
            Value4 = value4 == default ? default : (T4)value4;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { Value1, Value2, Value3, Value4 };

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Value1), Value1, typeof(T1));
            info.AddValue(nameof(Value2), Value2, typeof(T2));
            info.AddValue(nameof(Value3), Value3, typeof(T3));
            info.AddValue(nameof(Value4), Value4, typeof(T4));
        }
    }

    public sealed class TinyValue<T1, T2, T3, T4, T5> : Value<TinyValue<T1, T2, T3, T4, T5>>, ISerializable
    {
        public T1 Value1 { get; }
        public T2 Value2 { get; }
        public T3 Value3 { get; }
        public T4 Value4 { get; }
        public T5 Value5 { get; }

        public TinyValue(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
            Value5 = value5;
        }

        public TinyValue(SerializationInfo info, StreamingContext context)
        {
            var value1 = info.GetValue(nameof(Value1), typeof(T1));
            var value2 = info.GetValue(nameof(Value2), typeof(T2));
            var value3 = info.GetValue(nameof(Value3), typeof(T3));
            var value4 = info.GetValue(nameof(Value4), typeof(T4));
            var value5 = info.GetValue(nameof(Value5), typeof(T5));

            Value1 = value1 == default ? default : (T1)value1;
            Value2 = value2 == default ? default : (T2)value2;
            Value3 = value3 == default ? default : (T3)value3;
            Value4 = value4 == default ? default : (T4)value4;
            Value5 = value5 == default ? default : (T5)value5;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { Value1, Value2, Value3, Value4, Value5 };

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Value1), Value1, typeof(T1));
            info.AddValue(nameof(Value2), Value2, typeof(T2));
            info.AddValue(nameof(Value3), Value3, typeof(T3));
            info.AddValue(nameof(Value4), Value4, typeof(T4));
            info.AddValue(nameof(Value5), Value5, typeof(T5));
        }
    }
}