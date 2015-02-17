using System;
using System.Linq;

namespace Trader.Web.Automapper
{
    using Trader.Common;
    using Trader.Model.Glossaries;
    using Trader.Model.Glossaries.Providers;
    using Trader.Model.Solr;
    using Trader.Services;
    using Trader.Web.Helpers;
    using Trader.Web.Models.Domiporta;
    using Trader.Web.Models.DomiportaRP;

    public abstract class AutoMapperBase : IAutoMapperConfig
    {
        protected internal readonly IPictureService _pictureService;

        protected internal readonly IPhoneService _phoneService;

        protected internal readonly ISolrService _solrService;

        protected internal readonly ICityProvider _cityProvider;

        public AutoMapperBase(IPictureService pictureService, IPhoneService phoneService, ISolrService solrService, ICityProvider cityProvider)
        {
            this._phoneService = phoneService;
            _solrService = solrService;
            _cityProvider = cityProvider;
            _pictureService = pictureService;
        }

        protected internal string MapCityFromLocation(DomiportaRPInvestmentViewModel viewModel)
        {
            var city = MapCity(viewModel.Location);
            if (string.IsNullOrEmpty(city))
            {
                return viewModel.City;
            }

            return city;
        }

        /// <summary>
        /// Parameter may not be a city, check if it exists in a most known city db, and if exists map it
        /// </summary>
        /// <param name="city">string that may be a city name or something else</param>
        /// <returns>null, if not mapped, city otherwise</returns>
        protected internal string MapCity(string city)
        {
            if (string.IsNullOrEmpty(city)) return null;

            return _cityProvider.GetCityNamesSortedByNumberOfAdverts().SingleOrDefault(x => x.Sanitize.Equals(city, StringComparison.OrdinalIgnoreCase)).Name;
        }

        protected internal string GetDistrictFromGuessMarketViewModel(GuessMarketViewModel viewModel)
        {
            var district = viewModel.Dzielnica2.FirstOrDefault(z => !string.IsNullOrEmpty(z));

            // There are 2 different iis redirect that are used here, one both (Dzielnica and Dzielnica2) and one that sets only Dzielnica
            return string.IsNullOrEmpty(district) ? viewModel.Dzielnica : district;
        }

        protected internal int MapTransactionOrUseDefault(GuessMarketViewModel viewModel)
        {
            return viewModel.Trn.HasValue ?
                TransactionTypeProvider.TransactionTypes.Any(x => x.Id == viewModel.Trn.Value) ?
                    viewModel.Trn.Value :
                    TransactionTypeProvider.DefaultTransactionTypeId :
                TransactionTypeProvider.DefaultTransactionTypeId;
        }

        protected internal int MapCategoryOrUseDefault(GuessMarketViewModel viewModel)
        {
            return viewModel.CategoryId.HasValue ?
                CategoryProvider.Categories.Any(x => x.Id == viewModel.CategoryId.Value) ?
                    viewModel.CategoryId.Value :
                    CategoryProvider.DefaultCategoryId :
                CategoryProvider.DefaultCategoryId;
        }

        protected internal static IListElements MapMarketSegment()
        {
            return ListElementsBuilder.BuildWitProvider<MarketSegment>(MarketEnum.pierwotny.GetHashCode());
        }

        protected internal static RangeCriteria MapRangeCriteria(int? from, int? to)
        {
            return new RangeCriteria(from, to);
        }

        protected internal static int MapCategoryFromRP(int rPcategoryId)
        {
            var category = CategoryProvider.GetCategoriesFromNewRP().FirstOrDefault(x => x.Id == rPcategoryId);
            return category == null ? CategoryProvider.DefaultCategoryId : category.MobileCategoryId;
        }

        public abstract void ConfigureAutoMapper();
    }
}