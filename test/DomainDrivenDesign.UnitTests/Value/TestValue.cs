namespace Acidic.DomainDrivenDesign.UnitTests.Value
{
    internal sealed class NoFieldsValue : Value<NoFieldsValue>
    {
        protected override object[] PropertiesForEqualityCheck => new object[] { };
    }

    internal sealed class SingleFieldValue : Value<SingleFieldValue>
    {
        public string Field1 { get; }

        public SingleFieldValue(string field1)
        {
            Field1 = field1;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { Field1 };
    }

    internal sealed class MultipleFieldsValue : Value<MultipleFieldsValue>
    {
        public string Field1 { get; }
        public string Field2 { get; }

        public MultipleFieldsValue(string field1, string field2)
        {
            Field1 = field1;
            Field2 = field2;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { Field1, Field2 };
    }
}