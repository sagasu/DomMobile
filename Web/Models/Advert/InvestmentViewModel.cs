namespace Trader.Web.Models.Advert
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Trader.Common;
    using Trader.Model;
    using Trader.Model.Common;
    using Trader.Model.Solr;
    using Trader.Web.Models.Search;

    public class InvestmentViewModel
    {
        public InvestmentViewModel()
        {
            InvestmentSearchOptions = new SearchOptions { PaginationNumerOfRows = SearchOptions.InvestmentNumerOfRows };
            SearchResultViewModel = new SolrResultModel<SearchResultViewModel>();
            SearchViewModel = new SearchViewModel();
        }

        public string Id { get; set; }

        public string City { get; set; }

        public string Name { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public int? NumberOfFloors { get; set; }

        public int? NumberOfAppartments { get; set; }

        [UIHint("Date")]
        public DateTime? RealizationTime { get; set; }

        public RangeCriteria Area { get; set; }

        public RangeCriteria Price { get; set; }

        public string Picture { get; set; }

        [UIHint("Phone")]
        public PhoneViewModel Phone { get; set; }

        [UIHint("Email")]
        public EmailViewModel Email { get; set; }

        public SolrResultModel<SearchResultViewModel> SearchResultViewModel { get; set; }

        /// <summary>
        /// Used for pagination for investment view, and investment inside details view
        /// </summary>
        public SearchOptions InvestmentSearchOptions { get; set; }

        /// <summary>
        /// To keep knowledge about search criteria, so we can navigate back and keep it
        /// </summary>
        public SearchViewModel SearchViewModel { get; set; }

        /// <summary>
        /// Fluent interface for pagination
        /// </summary>
        /// <returns>Clone of a current object with a next options</returns>
        public InvestmentViewModel NextPaginationBuilder()
        {
            var viewModel = GetPaginationData();
            viewModel.InvestmentSearchOptions = InvestmentSearchOptions.NextPaginationBuilder();
            return viewModel;
        }

        /// <summary>
        /// Fluent interface for pagination
        /// </summary>
        /// <returns>Clone of a current object with a previous options</returns>
        public InvestmentViewModel PreviousPaginationBuilder()
        {
            var viewModel = GetPaginationData();
            viewModel.InvestmentSearchOptions = InvestmentSearchOptions.PreviousPaginationBuilder();
            return viewModel;
        }

        public AdvertViewModel BuildAdvertViewModel()
        {
            return new AdvertViewModel
                {
                    InvestmentId = Id,
                    SearchViewModel = this.SearchViewModel,
                    InnerSearchOptions = this.InvestmentSearchOptions,
                    IsInvestment = true,
                };
        }

        private InvestmentViewModel GetPaginationData()
        {
            return new InvestmentViewModel() { Id = this.Id, SearchViewModel = this.SearchViewModel };
        }
    }
}