namespace Trader.Web.Helpers
{
    using System;
    using System.Linq;

    using AutoMapper;

    using Trader.AdvertUrlService;
    using Trader.Model.Solr;
    using Trader.Services;
    using Trader.Web.Models.Advert;
    using Trader.Web.Models.Search;

    public static class AdvertHelper
    {
        /// <exception cref="NullReferenceException">When this advertId does not exist or is not valid</exception>
        public static AdvertViewModel GetSlimAdvertViewModelByAdvertId(string advertId, ISolrService solrService, IDbService dbService)
        {
            var foundAdvertViewModel = GetViewModelByAdvertId(advertId, solrService, dbService);

            var transactionTypeId = DomiportaHelper.GetTransactionTypeId(foundAdvertViewModel);

            return new AdvertViewModel
            {
                Id = foundAdvertViewModel.Id,
                InvestmentId = foundAdvertViewModel.InvestmentId,
                SearchViewModel = new SearchViewModel
                {
                    CategoryId = foundAdvertViewModel.CategoryId,
                    TransactionTypeId = transactionTypeId
                },
                IsInvestment = foundAdvertViewModel.IsInvestment
            };
        }

        /// <exception cref="NullReferenceException">When this advertId does not exist or is not valid</exception>
        public static AdvertViewModel GetViewModelByAdvertId(string advertId, ISolrService solrService, IDbService dbService)
        {
            var solrResultModel = solrService.Search(new SolrAdvertDto { Id = advertId });

            var advertElement = solrResultModel.SearchResults.SingleOrDefault();

            // advertId may be from an old domiporta, or from domiporta RP
            // above system tries to find an advert from old domiporta id (allads id)
            // below tries to find using domiporta RP id
            if(advertElement == null)
            {
                int advertIdAsInt = int.Parse(advertId);

                advertId = dbService.GetAlladsAdvertIdFromDomiportaRPId(advertIdAsInt);

                solrResultModel = solrService.Search(new SolrAdvertDto { Id = advertId });
                advertElement = solrResultModel.SearchResults.SingleOrDefault();
            }

            return Mapper.Map<ISimpleSolrAdvert, AdvertViewModel>(advertElement);
        }
    }
}