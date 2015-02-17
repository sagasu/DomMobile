using System;

namespace Trader.Web.Attributes
{
    using System.Web.Mvc;

    using Trader.Web.Models.Domiporta;

    public class WebSearchResultPrimaryOrSecondaryMarketBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new WebSearchResultPrimaryOrSecondaryMarketBinder();
        }
    }

    public class WebSearchResultPrimaryOrSecondaryMarketBinder : IModelBinder
    {
        private const string CantParseUrl = "Nie udało się przemapować url z webowej wersji domiporty.";

        // By existence of this string in Url we guess that it is a primary market, not a secondary Market
        private const string PrimaryMarketHeuristicString = "oferty/P/"; 

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                return TryBindModel(controllerContext, bindingContext);
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError("Global", CantParseUrl);
                return new WebSearchResultViewModelSecondaryMarket();
            }
        }

        /// <summary>
        /// Tries to guess if it's a primary or a secondary market
        /// First check if it is a primary market, otherwise treat it as a seconary market.
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext"></param>
        /// <returns>View model of a market.</returns>
        private static object TryBindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext.HttpContext.Request.RawUrl.ToLower().Contains(PrimaryMarketHeuristicString.ToLower()))
            {
                var primaryMarket = WebSearchResultPrimaryMarketBinder.TryBindModel(controllerContext, bindingContext);

                if (bindingContext.ModelState.IsValid) return primaryMarket;
            }

            var secondaryMarket = WebSearchResultSecondaryMarketBinder.TryBindModel(controllerContext, bindingContext);

            return secondaryMarket;
        }
    }
}