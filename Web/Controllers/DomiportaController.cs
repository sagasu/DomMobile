namespace Trader.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Trader.AdvertUrlService;
    using Trader.Common;
    using Trader.Model.Glossaries.Providers;
    using Trader.Model.Solr;
    using Trader.Services;
    using Trader.Web.Attributes;
    using Trader.Web.Helpers;
    using Trader.Web.Models.Advert;
    using Trader.Web.Models.Domiporta;
    using Trader.Web.Models.Search;

    public partial class DomiportaController : Controller
    {
        private const string IncorrectAdvertId = "Nie istnieje ogłoszenie o podanym Id.";
        private const string IncorrectInvestmentId = "Nie istnieje inwestycja o podanym Id.";

        private const string UrlHasIncorrectData = "Url zawiera nieprawidłowe dane.";
        private const string CantRemapUrl = "Nie udało się przemapować url.";
        private readonly IConfigurationService _configurationService;

        private readonly ISolrService _solrService;

        private readonly IDbService _dbService;

        public DomiportaController(
            IConfigurationService configurationService,
            ISolrService solrService,
            IDbService dbService)
        {
            this._dbService = dbService;
            this._solrService = solrService;
            this._configurationService = configurationService;
        }

        [SimpleValidation(Message = UrlHasIncorrectData)]
        [SimpleErrorHandle(Message = IncorrectAdvertId)]
        public virtual ActionResult Details(WebDetailsViewModel viewModel)
        {
            var advertViewModel = AdvertHelper.GetSlimAdvertViewModelByAdvertId(viewModel.Id, this._solrService, _dbService);

            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("Details", "Advert"),
                    advertViewModel));
        }

        public virtual ActionResult RedirectToHP()
        {
            return RedirectToAction("Index", "Home");
        }

        [SimpleErrorHandle(Message = IncorrectAdvertId)]
        public virtual ActionResult DetailsWithCategory([WebAdvertBinder] WebAdvertViewModel viewModel)
        {
            var advertViewModel = AdvertHelper.GetSlimAdvertViewModelByAdvertId(viewModel.AdvertId, this._solrService, _dbService);

            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("Details", "Advert"),
                    advertViewModel));
        }

        public virtual ActionResult WebRedirect()
        {
            return View(new WebRedirectViewModel(_configurationService, Request.RawUrl));
        }

        public virtual ActionResult InvestmentIISMapping(WebInvestmentIISMappingViewModel viewModel)
        {
            return RedirectInvestment(Mapper.Map<WebInvestmentIISMappingViewModel, WebInvestmentViewModel>(viewModel));
        }

        [SimpleValidation(Message = UrlHasIncorrectData)]
        public virtual ActionResult Investment([WebInvestmentBinder] WebInvestmentViewModel viewModel)
        {
            // Ignore an advertId information, this is an investment mapping
            return RedirectInvestment(viewModel);
        }

        [SimpleValidation(Message = UrlHasIncorrectData)]
        public virtual ActionResult SearchResult([WebSearchResultBinder] WebSearchResultViewModel viewModel)
        {
            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("SearchResult", "Search"),
                    new SearchViewModel
                        {
                            CategoryId = viewModel.CategoryId,
                            City = viewModel.City,
                            TransactionTypeId = TransactionTypeProvider.SellId, // Default parameter
                        }));
        }

        [SimpleValidation(Message = UrlHasIncorrectData)]
        public virtual ActionResult SearchResultPrimaryMarket([WebSearchResultPrimaryMarketBinder] WebSearchResultViewModelPrimaryMarket viewModel)
        {
            return RedirectToPrimaryMarket(viewModel);
        }

        [SimpleValidation(Message = UrlHasIncorrectData)]
        public virtual ActionResult SearchResultSecondaryMarket([WebSearchResultSecondaryMarketBinder] WebSearchResultViewModelSecondaryMarket viewModel)
        {
            return RedirectToSecondaryMarket(viewModel);
        }

        [SimpleValidation(Message = UrlHasIncorrectData)]
        public virtual ActionResult SearchResultGuessMarketIISRedirect(GuessMarketViewModel viewModel)
        {
            // There are 3 different URL's that are handled here

            if (string.IsNullOrEmpty(viewModel.Rynek))
            {
                viewModel.Developer = GuessMarketViewModel.SearchAlsoPrimaryMarket;
                return
                    this.RedirectToSecondaryMarket(
                        Mapper.Map<GuessMarketViewModel, WebSearchResultViewModelSecondaryMarket>(viewModel));
            }

            return viewModel.Rynek.Equals(GuessMarketViewModel.PrimaryMarket, StringComparison.InvariantCultureIgnoreCase) ?
                this.RedirectToPrimaryMarket(Mapper.Map<GuessMarketViewModel, WebSearchResultViewModelPrimaryMarket>(viewModel)) :
                this.RedirectToSecondaryMarket(Mapper.Map<GuessMarketViewModel, WebSearchResultViewModelSecondaryMarket>(viewModel));
        }

        public virtual ActionResult SearchResultGuessMarket([WebSearchResultPrimaryOrSecondaryMarketBinder] object viewModel)
        {
            if (viewModel is WebSearchResultViewModelPrimaryMarket)
            {
                return this.RedirectToPrimaryMarket((WebSearchResultViewModelPrimaryMarket)viewModel);
            }

            if (viewModel is WebSearchResultViewModelSecondaryMarket)
            {
                return this.RedirectToSecondaryMarket((WebSearchResultViewModelSecondaryMarket)viewModel);
            }

            MessageHelper.SendErrorMessage(ViewBag, CantRemapUrl);
            return View(MVC.Home.Views.Index_Mobile);
        }

        [SimpleErrorHandle(Message = IncorrectAdvertId)]
        [SimpleValidation(Message = UrlHasIncorrectData)]
        public virtual ActionResult Gallery([WebGalleryBinder] WebGalleryViewModel viewModel)
        {
            var advertViewModel = AdvertHelper.GetSlimAdvertViewModelByAdvertId(viewModel.AdvertId, _solrService, _dbService);

            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("Gallery", "Advert"),
                    advertViewModel));
        }

        private ActionResult RedirectToPrimaryMarket(WebSearchResultViewModelPrimaryMarket viewModel)
        {
            var district = ExtractDistrict(viewModel.District);

            var searchViewModel = new SearchViewModel
            {
                City = viewModel.City,
                District = district,
                TransactionTypeId = viewModel.TransactionTypeId,
                CategoryId = viewModel.CategoryId,
            };
            searchViewModel.MarketSegment.SelectedId = viewModel.MarketSegmentSelectedId;

            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    this.Url.Action("SearchResult", "Search"),
                    searchViewModel));
        }

        /// <summary>
        /// Extract just first district and pass it
        /// </summary>
        /// <param name="district"></param>
        /// <returns></returns>
        private string ExtractDistrict(string district)
        {
            string extractedDistrict = null;
            if (string.IsNullOrEmpty(district)) return extractedDistrict;

            return district.Split(',').FirstOrDefault();
        }

        private ActionResult RedirectToSecondaryMarket(WebSearchResultViewModelSecondaryMarket viewModel)
        {
            var district = ExtractDistrict(viewModel.District);

            var searchViewModel = new SearchViewModel
            {
                CategoryId = viewModel.CategoryId,
                City = viewModel.City,
                District = district,
                TransactionTypeId = viewModel.TransactionTypeId,
                Price = viewModel.Price,
                Surface = viewModel.Area,
                NumberOfRooms = viewModel.NumberOfRooms,
            };
            searchViewModel.MarketSegment.SelectedId = viewModel.MarketSegmentSelectedId;

            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    this.Url.Action("SearchResult", "Search"),
                    searchViewModel));
        }

        private ActionResult RedirectInvestment(WebInvestmentViewModel viewModel)
        {
            var solrResultModel = this._solrService.Search(new SolrAdvertDto { Id = viewModel.AdvertId });

            if (solrResultModel == null || solrResultModel.NumFound == 0)
            {
                int advertIdAsInt = int.Parse(viewModel.AdvertId);

                var advertId = _dbService.GetAlladsAdvertIdFromDomiportaRPId(advertIdAsInt);

                // The Id does not exists, so check if it is not an old id that needs to be map to a new id
                solrResultModel = this._solrService.Search(new SolrAdvertDto { Id = advertId });
            }

            var advertElement = solrResultModel.SearchResults.FirstOrDefault();

            var foundAdvertViewModel = Mapper.Map<ISimpleSolrAdvert, AdvertViewModel>(advertElement);
            
            if (foundAdvertViewModel == null)
            {
                MessageHelper.SendInfoMessage(this.ViewBag, IncorrectInvestmentId);
                return this.View(MVC.Home.Views.Index_Mobile);
            }

            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    this.Url.Action("InvestmentDetails", "Advert"),
                    new InvestmentViewModel
                    {
                        Id = foundAdvertViewModel.InvestmentId,
                        SearchViewModel = new SearchViewModel
                        {
                            CategoryId = foundAdvertViewModel.CategoryId,
                            TransactionTypeId = DomiportaHelper.GetTransactionTypeId(foundAdvertViewModel)
                        },
                    }));
        }
    }
}