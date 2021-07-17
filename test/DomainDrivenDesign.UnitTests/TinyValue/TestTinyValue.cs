namespace Acidic.DomainDrivenDesign.UnitTests.TinyValue
{
    internal sealed class OneFieldTinyValue : TinyValue<int>
    {
        public OneFieldTinyValue(int value) : base(value)
        {

        }
    }

    internal sealed class TwoFieldsTinyValue : TinyValue<int, string>
    {
        public TwoFieldsTinyValue(int value1, string value2) : base(value1, value2)
        {

        }
    }

    internal sealed class ThreeFieldsTinyValue : TinyValue<int, string, double>
    {
        public ThreeFieldsTinyValue(int value1, string value2, double value3) : base(value1, value2, value3)
        {

        }
    }

    internal sealed class FourFieldsTinyValue : TinyValue<int, string, double, float>
    {
        public FourFieldsTinyValue(int value1, string value2, double value3, float value4) : base(value1, value2, value3, value4)
        {

        }
    }

    internal sealed class FiveFieldsTinyValue : TinyValue<int, string, double, float, int>
    {
        public FiveFieldsTinyValue(int value1, string value2, double value3, float value4, int value5) : base(value1, value2, value3, value4, value5)
        {

        }
    }
}