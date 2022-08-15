namespace Acidic.DomainDrivenDesign
{
    public abstract class TinyValue<T> : Value<TinyValue<T>>
    {
        private readonly T _value;
        public T Value => _value;

        public TinyValue(T value)
        {
            _value = value;
        }
    }

    public abstract class TinyValue<T1, T2> : Value<TinyValue<T1, T2>>
    {
        public T1 Value1 { get; }
        public T2 Value2 { get; }

        public TinyValue(T1 value1, T2 value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }

    public abstract class TinyValue<T1, T2, T3> : Value<TinyValue<T1, T2, T3>>
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
    }

    public abstract class TinyValue<T1, T2, T3, T4> : Value<TinyValue<T1, T2, T3, T4>>
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
    }

    public abstract class TinyValue<T1, T2, T3, T4, T5> : Value<TinyValue<T1, T2, T3, T4, T5>>
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
    }
}