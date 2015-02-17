using System;
using System.Linq;

namespace Trader.Web.Helpers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Trader.Model.Solr;
    using Trader.Services;
    using Trader.Web.Models.Advert;

    public static class SearchHelper
    {
        private const string IncorrectAdvertId = "Nie istnieje ogłoszenie o podanym Id.";

        public static ActionResult SetAdvertViewModelByAdvertId(
            string advertId, 
            out AdvertViewModel advertViewModel,
            ISolrService solrService, 
            dynamic viewBag,
            Func<string,string, RedirectToRouteResult> redirectToAction)
        {
            var solrResultModel = solrService.Search(new SolrAdvertDto { Id = advertId });

            if (solrResultModel == null)
            {
                MessageHelper.SendInfoMessage(viewBag, IncorrectAdvertId);
                advertViewModel = null;
                return redirectToAction("Index", "Home");
            }

            var advertElement = solrResultModel.SearchResults.SingleOrDefault();

            advertViewModel = Mapper.Map<ISimpleSolrAdvert, AdvertViewModel>(advertElement);

            return null;
        }
    }
}