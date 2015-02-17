namespace Trader.Common.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GlossaryBaseAttribute : AdditionalValueBaseAttribute
    {
        public const string AdditionalValueKey = "__PresentAsGlossaryBaseAttribute";

        public override string GetKey()
        {
            return AdditionalValueKey;
        }

        public override object GetValue()
        {
            return ShowChooseOption;
        }

        /// <summary>
        /// By default true
        /// </summary>
        public bool ShowChooseOption { get; set; }

        /// <summary>
        /// By default "Wybierz"
        /// </summary>
        public string LabelText { get; set; }
    }
}