namespace Trader.Web.Attributes
{
    using System;
    using System.Web.Mvc;

    using Trader.Model.Glossaries;
    using Trader.Model.Glossaries.Providers;
    using Trader.Web.Helpers;
    using Trader.Web.Models.Domiporta;

    public class WebSearchResultPrimaryMarketBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new WebSearchResultPrimaryMarketBinder();
        }
    }

    public class WebSearchResultPrimaryMarketBinder : IModelBinder
    {
        private const int DefaultCategoryId = CategoryProvider.FlatId;

        private const string CantParseUrl = "Nie udało się przemapować url z webowej wersji domiporty.";

        private const string OldDomiportaAllSearchName = "Nieruchomosci";

        // Mappings for "oferty/{marketSegment}/{categoryName}/{localization}/{district}/{street}/{parameters}"
        public const string LocationLongRegex = @"oferty/\w*/\w*/\w*";
        public const string CategoryLongRegex = @"oferty/\w*/\w*";
        public const string DistrictLongRegex = @"oferty/\w*/\w*/\w*/\w*";

        public const string LocationShortRegex = @"[\w]*$";
        public const string CategoryShortRegex = @"[\w]*$";
        public const string DistrictShortRegex = @"[\w]*$";

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

        internal static WebSearchResultViewModelPrimaryMarket TryBindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string rawUrl = controllerContext.HttpContext.Request.RawUrl;

            rawUrl = DomiportaHelper.PrepareRawUrlForOldIIS(rawUrl);

            var webSearchResultViewModelPrimaryMarket = new WebSearchResultViewModelPrimaryMarket
                {
                    TransactionTypeId = TransactionTypeProvider.SellId, 
                };

            try
            {
                webSearchResultViewModelPrimaryMarket.City = RegexHelper.Map(
                    rawUrl, LocationLongRegex, LocationShortRegex);
            }
            catch{}

            try
            {
                webSearchResultViewModelPrimaryMarket.District = RegexHelper.Map(
                    rawUrl, DistrictLongRegex, DistrictShortRegex);
            }
            catch{}

            try
            {
                var categoryName = RegexHelper.Map(rawUrl, CategoryLongRegex, CategoryShortRegex);

                webSearchResultViewModelPrimaryMarket.CategoryId = categoryName.Equals(
                    OldDomiportaAllSearchName, StringComparison.InvariantCultureIgnoreCase)
                                                                       ? DefaultCategoryId
                                                                       : BindersHelper.GetGlossaryElementIdByName
                                                                             <Category>(categoryName, DefaultCategoryId);
            }
            catch
            {
                webSearchResultViewModelPrimaryMarket.CategoryId = DefaultCategoryId;
            }

            return webSearchResultViewModelPrimaryMarket;
        }
    }
}