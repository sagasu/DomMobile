using System.Linq;

namespace Trader.Web.Helpers
{
    using System.Web.Mvc;

    using Trader.Common;
    using Trader.Common.Attributes;
    using Trader.Web.Attributes;
    using Trader.Web.Global;

    public static class HtmlPropertiesProvider
    {
        // Set default HtmlProperties
        // Then look for HtmlProperties in Attributes
        // Then overrdie them with HtmlProperties in AdditionalViewData
        public static IHtmlProperties GetHtmlProperties(
            ViewDataDictionary viewData,
            ModelMetadata prop)
        {
            var mappedProperties = new HtmlProperties();

            // Map HtmlProperitesAttribute to AdditionalValue object, so it can be passed to inner templates
            var htmlPropertiesFromAttributes =
                (IHtmlProperties)prop.AdditionalValues.Values.SingleOrDefault(x => x is HtmlPropertiesAttribute);

            var preventOverrideByViewData = false;

            // Override default properties wiht ones in attribute
            if (htmlPropertiesFromAttributes != null)
            {
                mappedProperties.LabelContainerCss = string.IsNullOrEmpty(htmlPropertiesFromAttributes.LabelContainerCss) ? Consts.Templates.DefaultLabelContainerCss : htmlPropertiesFromAttributes.LabelContainerCss;
                mappedProperties.FieldContainerCss = string.IsNullOrEmpty(htmlPropertiesFromAttributes.FieldContainerCss) ? Consts.Templates.DefaultFieldContainerCss : htmlPropertiesFromAttributes.FieldContainerCss;
                mappedProperties.ContainerCss = string.IsNullOrEmpty(htmlPropertiesFromAttributes.ContainerCss) ? Consts.Templates.DefaultContainerCss : htmlPropertiesFromAttributes.ContainerCss;
                mappedProperties.FieldCss = string.IsNullOrEmpty(htmlPropertiesFromAttributes.FieldCss) ? Consts.Templates.DefaultContainerCss : htmlPropertiesFromAttributes.FieldCss;
                mappedProperties.LabelCss = string.IsNullOrEmpty(htmlPropertiesFromAttributes.LabelCss) ? Consts.Templates.DefaultContainerCss : htmlPropertiesFromAttributes.LabelCss;
                mappedProperties.ShowCharsLeft = htmlPropertiesFromAttributes.ShowCharsLeft;
                mappedProperties.Hint = string.IsNullOrEmpty(htmlPropertiesFromAttributes.Hint) ? null : htmlPropertiesFromAttributes.Hint;
                mappedProperties.OmitInnerGlobalClearBoth = htmlPropertiesFromAttributes.OmitInnerGlobalClearBoth;
                mappedProperties.OmitOuterGlobalClearBoth = htmlPropertiesFromAttributes.OmitOuterGlobalClearBoth;
                mappedProperties.ErrorFieldCss = htmlPropertiesFromAttributes.ErrorFieldCss;
                mappedProperties.IsInvalid = htmlPropertiesFromAttributes.IsInvalid;
                preventOverrideByViewData = htmlPropertiesFromAttributes.PreventOverrideByViewData;
                mappedProperties.MaxLength = htmlPropertiesFromAttributes.MaxLength;
            }

            if (!preventOverrideByViewData)
            {
                // Override properties with ones specified in AdditionaViewData
                // I don't want to cast it to string, and check if it's string.NullOrEmpty couse I want to allowed user to specify a css as string.empty
                var labelContainerCssOverride =
                    viewData[ReflectionHelper.GetProperty<IHtmlProperties>(x => x.FieldCss).Name];
                var fieldContainerCssOverride =
                    viewData[ReflectionHelper.GetProperty<IHtmlProperties>(x => x.FieldContainerCss).Name];
                var containerCssOverride =
                    viewData[ReflectionHelper.GetProperty<IHtmlProperties>(x => x.ContainerCss).Name];
                var fieldCssOverride = viewData[ReflectionHelper.GetProperty<IHtmlProperties>(x => x.FieldCss).Name];
                var labelCssOverride = viewData[ReflectionHelper.GetProperty<IHtmlProperties>(x => x.LabelCss).Name];
                var omitInnerGlobalClearBothOverride =
                    viewData[ReflectionHelper.GetProperty<IHtmlProperties>(x => x.OmitInnerGlobalClearBoth).Name];
                var omitOuterGlobalClearBothOverride =
                                    viewData[ReflectionHelper.GetProperty<IHtmlProperties>(x => x.OmitOuterGlobalClearBoth).Name];
                var errorFieldCss = viewData[ReflectionHelper.GetProperty<IHtmlProperties>(x => x.ErrorFieldCss).Name];
                var isInvalid = viewData[ReflectionHelper.GetProperty<IHtmlProperties>(x => x.IsInvalid).Name];
                var maxLength = viewData[ReflectionHelper.GetProperty<IHtmlProperties>(x => x.MaxLength).Name];

                if (labelContainerCssOverride != null)
                    mappedProperties.LabelContainerCss = (string)labelContainerCssOverride;
                if (fieldContainerCssOverride != null)
                    mappedProperties.FieldContainerCss = (string)fieldContainerCssOverride;
                if (containerCssOverride != null) mappedProperties.ContainerCss = (string)containerCssOverride;
                if (fieldCssOverride != null) mappedProperties.FieldCss = (string)fieldCssOverride;
                if (labelCssOverride != null) mappedProperties.LabelCss = (string)labelCssOverride;
                if (omitInnerGlobalClearBothOverride != null)
                    mappedProperties.OmitInnerGlobalClearBoth = (bool)omitInnerGlobalClearBothOverride;
                if (omitOuterGlobalClearBothOverride != null)
                    mappedProperties.OmitOuterGlobalClearBoth = (bool)omitOuterGlobalClearBothOverride;
                if (errorFieldCss != null) mappedProperties.ErrorFieldCss = (string)errorFieldCss;
                if (isInvalid != null) mappedProperties.IsInvalid = (bool)isInvalid;
                if (maxLength != null) mappedProperties.MaxLength = (int)maxLength;
            }
            return mappedProperties;
        }
    }
}