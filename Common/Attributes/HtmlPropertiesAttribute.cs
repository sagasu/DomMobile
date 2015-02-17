namespace Trader.Common.Attributes
{
    using System;

    using Trader.Common;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class HtmlPropertiesAttribute : AdditionalValueBaseAttribute, IHtmlProperties
    {
        public const string AdditionalValueKey = "__PresentAsHtmlPropertiesAttribute";

        public string ContainerCss { get; set; }
        public string LabelInnerTag { get; set; }

        public string LabelCss { get; set; }
        public string LabelContainerCss { get; set; }

        public string FieldCss { get; set; }
        public string FieldContainerCss { get; set; }

        public bool HideLabel { get; set; }

        public bool ShowCharsLeft { get; set; }

        public string Hint { get; set; }

        /// <summary>
        /// In some cases attribute data gets overridden by ViewData, however it is hard to say why.
        /// This property is subject to remove after resolving the original problem.
        /// </summary>
        public bool PreventOverrideByViewData { get; set; }

        public bool OmitInnerGlobalClearBoth { get; set; }

        public bool OmitOuterGlobalClearBoth { get; set; }

        public string ErrorFieldCss { get; set; }

        public bool IsInvalid { get; set; }

        public int MaxLength { get; set; }

        public override string GetKey()
        {
            return AdditionalValueKey;
        }

        public override object GetValue()
        {
            throw new NotImplementedException();
        }
    }
}