namespace Trader.Web.Attributes
{
    using System;
    using System.Web.Mvc;

    using Trader.Common;
    using Trader.Model.Glossaries;
    using Trader.Model.Glossaries.Providers;
    using Trader.Web.Helpers;
    using Trader.Web.Models.Domiporta;

    public class WebSearchResultSecondaryMarketBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new WebSearchResultSecondaryMarketBinder();
        }
    }

    public class WebSearchResultSecondaryMarketBinder : IModelBinder
    {
        // Mappings for "oferty/{transactionType}/{categoryName}/{location}/{district}/{street}/{parameters}"
        public const string TransactionTypeLongRegex = @"oferty/\w*";
        public const string LocationLongRegex = @"oferty/\w*/\w*/\w*";
        public const string CategoryLongRegex = @"oferty/\w*/\w*";
        public const string DistrictLongRegex = @"oferty/\w*/\w*/\w*/\w*";

        public const string TransactionTypeShortRegex = @"[\w]*$";
        public const string LocationShortRegex = @"[\w]*$";
        public const string CategoryShortRegex = @"[\w]*$";
        public const string DistrictShortRegex = @"[\w]*$";

        // URL Parameters 
        private const string AreaFromLong = @"Powierzchnia_from=\d+";
        private const string AreaFromShort = @"\d+";
        private const string AreaToLong = @"Powierzchnia_to=\d+";
        private const string AreaToShort = @"\d+";
        private const string NumberOfRoomsFromLong = @"Liczba_pokoi_from=\d+";
        private const string NumberOfRoomsFromShort = @"\d+";
        private const string NumberOfRoomsToLong = @"Liczba_pokoi_to=\d+";
        private const string NumberOfRoomsToShort = @"\d+";
        private const string PriceFromLong = @"Cena_from=\d+";
        private const string PriceFromShort = @"\d+";
        private const string PriceToLong = @"Cena_to=\d+";
        private const string PriceToShort = @"\d+";

        private const string AllTransactionTypes = "wszystkie";
        private const string AllCategories = "nieruchomosci";
        private const string CantParseUrl = "Nie udało się przemapować url z webowej wersji domiporty.";

        private const int DefaultCategoryForMapping = CategoryProvider.FlatId;

        private const int DefaultTransactionTypeForMapping = TransactionTypeProvider.SellId;

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

        internal static WebSearchResultViewModelSecondaryMarket TryBindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string rawUrl = controllerContext.HttpContext.Request.RawUrl;

            rawUrl = DomiportaHelper.PrepareRawUrlForOldIIS(rawUrl);

            var viewModel = new WebSearchResultViewModelSecondaryMarket();

            try
            {
                var transactionTypeName = RegexHelper.Map(rawUrl, TransactionTypeLongRegex, TransactionTypeShortRegex);
                if (string.IsNullOrEmpty(transactionTypeName) || transactionTypeName.Equals(AllTransactionTypes, StringComparison.InvariantCultureIgnoreCase))
                {
                    viewModel.TransactionTypeId = DefaultTransactionTypeForMapping; // Default for mapping
                }
                else
                {
                    viewModel.TransactionTypeId = BindersHelper.GetTransactionTypeIdByName(
                        transactionTypeName, DefaultTransactionTypeForMapping);
                }
            }catch
            {
                viewModel.TransactionTypeId = DefaultTransactionTypeForMapping;
            }

            try
            {
                var categoryName = RegexHelper.Map(rawUrl, CategoryLongRegex, CategoryShortRegex);
                if (string.IsNullOrEmpty(categoryName) || categoryName.Equals(AllCategories, StringComparison.InvariantCultureIgnoreCase))
                {
                    viewModel.CategoryId = DefaultCategoryForMapping;
                }
                else
                {
                    viewModel.CategoryId = BindersHelper.GetGlossaryElementIdByName<Category>(
                        categoryName, DefaultCategoryForMapping);
                }
            }
            catch
            {
                viewModel.CategoryId = DefaultCategoryForMapping;
            }


            try
            {
                viewModel.City = RegexHelper.Map(rawUrl, LocationLongRegex, LocationShortRegex);
            }
            catch{}

            try
            {
                viewModel.District = RegexHelper.Map(rawUrl, DistrictLongRegex, DistrictShortRegex);
            }
            catch{}


            viewModel.NumberOfRooms = TryMatch(NumberOfRoomsFromLong, NumberOfRoomsFromShort, NumberOfRoomsToLong, NumberOfRoomsToShort, rawUrl);
            viewModel.Area = TryMatch(AreaFromLong, AreaFromShort, AreaToLong, AreaToShort, rawUrl);
            viewModel.Price = TryMatch(PriceFromLong, PriceFromShort, PriceToLong, PriceToShort, rawUrl);

            return viewModel;
        }

        private static RangeCriteria TryMatch(
            string fromLongRegex, string fromShortRegex,
            string toLongRegex, string toShortRegex,
            string rawUrl)
        {
            RangeCriteria mappedRangeCriteria = new RangeCriteria();

            try
            {
                mappedRangeCriteria.From = new GlossaryFilter<int>
                    {
                        SelectedValue = int.Parse(RegexHelper.Map(rawUrl, fromLongRegex, fromShortRegex)) 
                    };
            }
            catch {}

            try
            {
                mappedRangeCriteria.To = new GlossaryFilter<int>
                    {
                        SelectedValue = int.Parse(RegexHelper.Map(rawUrl, toLongRegex, toShortRegex)) 
                    };
            }
            catch { }

            return mappedRangeCriteria;
        }
    }
}