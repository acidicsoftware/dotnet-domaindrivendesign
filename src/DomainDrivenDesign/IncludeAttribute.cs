using System;

namespace Acidic.DomainDrivenDesign
{
   
    [AttributeUsage(validOn: AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class IncludeAttribute : Attribute
    {
    }
}