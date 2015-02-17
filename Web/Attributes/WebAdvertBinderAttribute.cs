using System;

namespace Trader.Web.Attributes
{
    using System.Web.Mvc;

    using Trader.Model.Glossaries.Providers;
    using Trader.Web.Helpers;
    using Trader.Web.Models.Domiporta;

    public class WebAdvertBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new WebAdvertBinder();
        }
    }

    public class WebAdvertBinder : IModelBinder
    {
        private const string CantParseUrl = "Nie udało się przemapować url z webowej wersji domiporty.";

        public const string AdvertIdPrimaryMarketLongRegex = @"details,[\d]+,[\d]+";
        public const string AdvertIdPrimaryMarketShortRegex = @"[\d]+$";

        //public const string AdvertIdSecondaryMarketLongRegex = @"/[\d]*";
        //public const string AdvertIdSecondaryMarketShortRegex = @"[\d]*$";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                return TryBindModel(controllerContext, bindingContext);
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError("Global", CantParseUrl);
                return new WebSearchResultViewModelPrimaryMarket();
            }
        }

        private object TryBindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string rawUrl = controllerContext.HttpContext.Request.RawUrl;

            var advertId = GetAdvertId(rawUrl);

            return new WebAdvertViewModel
            {
                AdvertId = advertId,
            };
        }

        private string GetAdvertId(string rawUrl)
        {
            return RegexHelper.Map(rawUrl, AdvertIdPrimaryMarketLongRegex, AdvertIdPrimaryMarketShortRegex);
        }
    }
}