using System;
using System.Collections.Generic;
using System.Linq;

namespace Trader.Web.Helpers
{
    using System.Web.Mvc;

    using Trader.Common.Attributes;
    using Trader.Model.Common;
    using Trader.Web.Global;

    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        public override IEnumerable<ModelMetadata> GetMetadataForProperties(object container, Type containerType)
        {
             var vanilaMetadata = base.GetMetadataForProperties(container, containerType);

             if (container != null && typeof(IFluentDecorator).IsAssignableFrom(containerType))
             {
                 var met = (IFluentDecorator)container;
                 vanilaMetadata = met.Decorate(vanilaMetadata.ToList());
             }

            return vanilaMetadata;
        }

        public override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, string propertyName)
        {
            return base.GetMetadataForProperty(modelAccessor, containerType, propertyName);
        }

        public override ModelMetadata GetMetadataForType(Func<object> modelAccessor, Type modelType)
        {
            var vanilaMetadata = base.GetMetadataForType(modelAccessor, modelType);

            return vanilaMetadata;
        }

        protected override ModelMetadata CreateMetadata(
                             IEnumerable<Attribute> attributes,
                             Type containerType,
                             Func<object> modelAccessor,
                             Type modelType,
                             string propertyName)
        {
            ModelMetadata vanilaMetadata = null;

            vanilaMetadata = base.CreateMetadata(attributes,
                                          containerType,
                                         modelAccessor,
                                         modelType,
                                         propertyName);

            var attributesList = attributes.ToList();

            var htmlProperties = attributesList.OfType<HtmlPropertiesAttribute>().FirstOrDefault();
            if (htmlProperties != null)
            {
                vanilaMetadata.AdditionalValues.Add(HtmlPropertiesAttribute.AdditionalValueKey, htmlProperties);
            }

            //var boolDisplay = attributesList.SingleOrDefault(a => a is BoolDisplayAttribute);
            //if (boolDisplay != null)
            //{
            //    data.AdditionalValues.Add(BoolDisplayAttribute.AdditionalValueKey, boolDisplay);
            //    data.TemplateHint = Consts.Templates.BoolDisplay;
            //}

            var glossaryBaseDisplay = attributesList.SingleOrDefault(a => a is GlossaryBaseAttribute);
            if (glossaryBaseDisplay != null)
            {
                vanilaMetadata.AdditionalValues.Add(GlossaryBaseAttribute.AdditionalValueKey, glossaryBaseDisplay);
                vanilaMetadata.TemplateHint = Consts.Templates.GlossaryBase;
            }

            //var phoneAttribute = attributesList.SingleOrDefault(x => x is PhoneAttribute);
            //if (phoneAttribute != null)
            //{
            //    data.TemplateHint = Consts.Templates.Phone;
            //    data.AdditionalValues.Add(PhoneAttribute.AdditionalValueKey, phoneAttribute);
            //}

            //var requiredStarAttribute = attributesList.SingleOrDefault(x => x is RequiredStarAttribute);
            //if (requiredStarAttribute != null)
            //{
            //    data.AdditionalValues.Add(RequiredStarAttribute.AdditionalValueKey, requiredStarAttribute);
            //}

            //var groupingPresentation = attributesList
            //            .SingleOrDefault(a => typeof(GroupingPresentationAttribute) == a.GetType());
            //if (groupingPresentation != null) data.AdditionalValues
            //            .Add(GroupingPresentationAttribute.AdditionalValueKey, true);

            //var hiddenInput = attributesList
            //            .SingleOrDefault(a => a is HiddenInputAttribute);
            //if (hiddenInput != null)
            //{
            //    //Don't show label if displayvalue is false
            //    if (!((HiddenInputAttribute)hiddenInput).DisplayValue) data.HideSurroundingHtml = true;
            //    data.TemplateHint = Consts.Templates.HiddenInputMvcReservedTemplate;
            //}

            //var description = attributesList
            //            .SingleOrDefault(a => a is DescriptionAttribute);
            //if (description != null)
            //{
            //    //unfortunately MVC doesn't bind description :) It is for a class description, not sure how it will work for a property yet.
            //    data.Description = ((DescriptionAttribute)description).DescriptionValue;
            //})

            return vanilaMetadata;
        }
    }
}