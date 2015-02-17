namespace Trader.Web.Attributes
{
    using System;
    using System.Web.Mvc;

    using Trader.Web.Helpers;
    using Trader.Web.Models.Domiporta;

    public class WebSearchResultBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new WebSearchResultBinder();
        }
    }

    public class WebSearchResultBinder : IModelBinder
    {
        private const string CantParseUrl = "Nie udało się przemapować url z webowej wersji domiporty.";

        // Mappings for "ogloszenia,{categoryId},{city},{district}.asp/{parameters}"
        private const string CategoryIdLongRegex = @"ogloszenia,\d+,";
        private const string CityLongRegex = @"ogloszenia,\d+,\w+";
        private const string CategoryIdShortRegex = @"\d+";
        private const string CityShortRegex = @"\w+$";

        // Mappings for "oferty/{marketSegment}/{transactionType}/{comercialType}/{location}/{district}/{parameters}"


        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                return TryBindModel(controllerContext);
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError("Global", CantParseUrl);
                return new WebSearchResultViewModel();
            }
        }

        private static WebSearchResultViewModel TryBindModel(ControllerContext controllerContext)
        {
            return MapViewModelWithCategoryAndCity(controllerContext);
        }

        private static WebSearchResultViewModel MapViewModelWithCategoryAndCity(ControllerContext controllerContext)
        {
            var categoryId =
                RegexHelper.Map(controllerContext.HttpContext.Request.RawUrl, CategoryIdLongRegex, CategoryIdShortRegex);

            var city =
                RegexHelper.Map(controllerContext.HttpContext.Request.RawUrl, CityLongRegex, CityShortRegex);

            return new WebSearchResultViewModel { CategoryId = int.Parse(categoryId), City = city, };
        }
    }
}