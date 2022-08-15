namespace Acidic.DomainDrivenDesign
{
    /// <summary>
    /// Ready-to-use value base class with one value. 
    /// </summary>
    /// <remarks>
    /// Extend this class and provide the proper value through the constructor.
    /// </remarks>
    /// <typeparam name="T">The type of the value</typeparam>
    public abstract class TinyValue<T> : ManualValue<TinyValue<T>>
    {
        /// <summary>
        /// The value.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Construct and instance of a tiny value with a single value.
        /// </summary>
        /// <param name="value">The value of the first member</param>
        public TinyValue(T value)
        {
            Value = value;
        }
        
        /// <inheritdoc />
        protected sealed override object[] PropertiesForEqualityCheck => new object[] { Value };
    }

    /// <summary>
    /// Ready-to-use value base class with two values. 
    /// </summary>
    /// <remarks>
    /// Extend this class and provide the proper values through the constructor.
    /// </remarks>
    /// <typeparam name="T1">The type of the first value</typeparam>
    /// <typeparam name="T2">The type of the second value</typeparam>
    public abstract class TinyValue<T1, T2> : ManualValue<TinyValue<T1, T2>>
    {
        /// <summary>
        /// The value of the first member.
        /// </summary>
        public T1 Value1 { get; }
        
        /// <summary>
        /// The value of the second member.
        /// </summary>
        public T2 Value2 { get; }

        /// <summary>
        /// Construct and instance of a tiny value with two values.
        /// </summary>
        /// <param name="value1">The value of the first member</param>
        /// <param name="value2">The value of the second member</param>
        public TinyValue(T1 value1, T2 value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
        
        /// <inheritdoc />
        protected sealed override object[] PropertiesForEqualityCheck => new object[] { Value1, Value2 };
    }

    /// <summary>
    /// Ready-to-use value base class with three values. 
    /// </summary>
    /// <remarks>
    /// Extend this class and provide the proper values through the constructor.
    /// </remarks>
    /// <typeparam name="T1">The type of the first value</typeparam>
    /// <typeparam name="T2">The type of the second value</typeparam>
    /// <typeparam name="T3">The type of the third value</typeparam>
    public abstract class TinyValue<T1, T2, T3> : ManualValue<TinyValue<T1, T2, T3>>
    {
        /// <summary>
        /// The value of the first member.
        /// </summary>
        public T1 Value1 { get; }
        
        /// <summary>
        /// The value of the second member.
        /// </summary>
        public T2 Value2 { get; }
        
        /// <summary>
        /// The value of the third member.
        /// </summary>
        public T3 Value3 { get; }

        /// <summary>
        /// Construct and instance of a tiny value with three values.
        /// </summary>
        /// <param name="value1">The value of the first member</param>
        /// <param name="value2">The value of the second member</param>
        /// <param name="value3">The value of the third member</param>
        public TinyValue(T1 value1, T2 value2, T3 value3)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }
        
        /// <inheritdoc />
        protected sealed override object[] PropertiesForEqualityCheck => new object[] { Value1, Value2, Value3 };
    }

    /// <summary>
    /// Ready-to-use value base class with four values. 
    /// </summary>
    /// <remarks>
    /// Extend this class and provide the proper values through the constructor.
    /// </remarks>
    /// <typeparam name="T1">The type of the first value</typeparam>
    /// <typeparam name="T2">The type of the second value</typeparam>
    /// <typeparam name="T3">The type of the third value</typeparam>
    /// <typeparam name="T4">The type of the four value</typeparam>
    public abstract class TinyValue<T1, T2, T3, T4> : ManualValue<TinyValue<T1, T2, T3, T4>>
    {
        /// <summary>
        /// The value of the first member.
        /// </summary>
        public T1 Value1 { get; }
        
        /// <summary>
        /// The value of the second member.
        /// </summary>
        public T2 Value2 { get; }
        
        /// <summary>
        /// The value of the third member.
        /// </summary>
        public T3 Value3 { get; }
        
        /// <summary>
        /// The value of the fourth member.
        /// </summary>
        public T4 Value4 { get; }

        /// <summary>
        /// Construct and instance of a tiny value with four values.
        /// </summary>
        /// <param name="value1">The value of the first member</param>
        /// <param name="value2">The value of the second member</param>
        /// <param name="value3">The value of the third member</param>
        /// <param name="value4">The value of the fourth member</param>
        public TinyValue(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
        }
        
        /// <inheritdoc />
        protected sealed override object[] PropertiesForEqualityCheck => new object[] { Value1, Value2, Value3, Value4 };
    }

    /// <summary>
    /// Ready-to-use value base class with five values. 
    /// </summary>
    /// <remarks>
    /// Extend this class and provide the proper values through the constructor.
    /// </remarks>
    /// <typeparam name="T1">The type of the first value</typeparam>
    /// <typeparam name="T2">The type of the second value</typeparam>
    /// <typeparam name="T3">The type of the third value</typeparam>
    /// <typeparam name="T4">The type of the four value</typeparam>
    /// <typeparam name="T5">The type of the five value</typeparam>
    public abstract class TinyValue<T1, T2, T3, T4, T5> : ManualValue<TinyValue<T1, T2, T3, T4, T5>>
    {
        /// <summary>
        /// The value of the first member.
        /// </summary>
        public T1 Value1 { get; }
        
        /// <summary>
        /// The value of the second member.
        /// </summary>
        public T2 Value2 { get; }
        
        /// <summary>
        /// The value of the third member.
        /// </summary>
        public T3 Value3 { get; }
        
        /// <summary>
        /// The value of the fourth member.
        /// </summary>
        public T4 Value4 { get; }
        
        /// <summary>
        /// The value of the fifth member.
        /// </summary>
        public T5 Value5 { get; }

        /// <summary>
        /// Construct and instance of a tiny value with five values.
        /// </summary>
        /// <param name="value1">The value of the first member</param>
        /// <param name="value2">The value of the second member</param>
        /// <param name="value3">The value of the third member</param>
        /// <param name="value4">The value of the fourth member</param>
        /// <param name="value5">The value of the fifth member</param>
        public TinyValue(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
            Value5 = value5;
        }
        
        /// <inheritdoc />
        protected sealed override object[] PropertiesForEqualityCheck => new object[] { Value1, Value2, Value3, Value4, Value5 };
    }
}