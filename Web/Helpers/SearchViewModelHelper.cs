namespace Trader.Web.Helpers
{
    using System.Linq;

    using AutoMapper;

    using Trader.Model.Solr;
    using Trader.Services;
    using Trader.Web.Models.Search;

    public static class SearchViewModelHelper
    {
        /// <summary>
        /// Sets CategoryId, and TransactionTypeId from SOLR
        /// </summary>
        /// <returns></returns>
        public static SearchViewModel GetSearchViewModelByInvestmentId(string investmentId, ISolrService solrService)
        {
            var adverts = solrService.Search(new SolrAdvertDto { InvestmentId = investmentId });
            
            if(adverts != null && adverts.SearchResults.Any())
            {
                var firstAdvert = adverts.SearchResults.First();
                return Mapper.Map<ISimpleSolrAdvert, SearchViewModel>(firstAdvert);
            }

            return new SearchViewModel();
        }
    }
}