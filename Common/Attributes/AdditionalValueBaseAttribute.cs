namespace Trader.Common.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public abstract class AdditionalValueBaseAttribute : Attribute
    {
        public abstract string GetKey();

        public abstract object GetValue();
    }
}