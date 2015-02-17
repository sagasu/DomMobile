// -----------------------------------------------------------------------
// <copyright file="HtmlProperties.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Common
{
    /// <summary>
    /// The idea behind this interface is to create a common way to decorate templates with html style tags
    /// It is designed to be used as attribute and as a class if needed
    /// </summary>
    public interface IHtmlProperties
    {
        string LabelCss { get; set; }
        string LabelContainerCss { get; set; }

        string FieldCss { get; set; }
        string FieldContainerCss { get; set; }

        string ContainerCss { get; set; }
        string LabelInnerTag { get; set; }

        bool HideLabel { get; set; }

        bool ShowCharsLeft { get; set; }

        string Hint { get; set; }

        /// <summary>
        /// In some cases attribute data gets overridden by ViewData, however it is hard to say why.
        /// This property is subject to remove after resolving the original problem.
        /// </summary>
        bool PreventOverrideByViewData { get; set; }

        bool OmitInnerGlobalClearBoth { get; set; }

        bool OmitOuterGlobalClearBoth { get; set; }

        string ErrorFieldCss { get; set; }

        bool IsInvalid { get; set; }

        int MaxLength { get; set; }
    }

    public class HtmlProperties : IHtmlProperties
    {
        public string LabelCss { get; set; }

        public string LabelContainerCss { get; set; }

        public string FieldCss { get; set; }

        public string FieldContainerCss { get; set; }

        public string ContainerCss { get; set; }

        public string LabelInnerTag { get; set; }

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
    }
}
