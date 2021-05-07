namespace Acidic.DomainDrivenDesign.UnitTests.Value
{
    internal class TestValue : Value<TestValue>
    {
        public int Field1 { get; }
        public double Field2 { get; }

        public TestValue(int field1, double field2)
        {
            Field1 = field1;
            Field2 = field2;
        }

        protected override object[] PropertiesForEqualityCheck => new object[] { Field1, Field2 };
    }
}