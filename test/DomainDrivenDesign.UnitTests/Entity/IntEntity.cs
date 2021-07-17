namespace Acidic.DomainDrivenDesign.UnitTests.Entity
{
    internal sealed class IntEntity : Entity<int>
    {
        public IntEntity(int identifier) : base(identifier)
        {
        }
    }
}