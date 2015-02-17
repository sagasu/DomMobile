namespace Trader.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Ninject.Extensions.Logging;

    using Trader.AdvertUrlService;
    using Trader.Model;
    using Trader.Model.Solr;
    using Trader.Services;
    using Trader.Web.Attributes;
    using Trader.Web.Helpers;
    using Trader.Web.Models.Advert;
    using Trader.Web.Models.Search;

    public partial class AdvertController : Controller
    {
        private readonly ISolrService _solrService;

        private readonly IDbService _dbService;

        private const string IncorrectResults = "Kryteria wyszukiwania są niepoprawne, spróbuj zadać inne zapytanie.";

        private const string SolrDidNotFoundAnythingInvestment = "Nie znaleziono inwestycji spełniającej kryteria wyszukiwania.";

        private const string SolrDidNotFoundAnythingAdvert = "Nie znaleziono ogłoszenia spełniającego kryteria wyszukiwania.";

        private const string ErrorThrown = "Nastąpił błąd przetwarzania danych. Spróbuj ponownie później.";

        private const string AdvertDoesNotExists = "Ogłoszenie o podanych kryteriach nie istnieje.";

        public AdvertController(
            ISolrService solrService,
            ILogger logger,
            IDbService dbService)
        {
            this._dbService = dbService;
            _solrService = solrService;
        }

        [SimpleValidation]
        [SimpleErrorHandleAttribute(Message = ErrorThrown)]
        public virtual ActionResult Details(AdvertViewModel viewModel)
        {
            return TryDetails(viewModel);

        }

        [SimpleValidation]
        [SimpleErrorHandleAttribute(Message = ErrorThrown)]
        public virtual ActionResult InvestmentDetails(InvestmentViewModel viewModel)
        {
            return TryInvestmentDetails(viewModel);
        }

        /// <summary>
        /// This is a details view, but only AdvertId is required
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [SimpleValidation]
        [SimpleErrorHandleAttribute(Message = AdvertDoesNotExists)]
        public virtual ActionResult SimpleDetails([AdvertIdRequiredBinder]IAdvertIdRequired viewModel)
        {
            var advertViewModel = AdvertHelper.GetViewModelByAdvertId(viewModel.Id, _solrService, _dbService);
            advertViewModel.SearchViewModel = new SearchViewModel
                {
                    CategoryId = CategoryHelper.MapToBaseCategory(advertViewModel.CategoryId)
                };
            advertViewModel.InnerSearchOptions = new SearchOptions{PaginationNumerOfRows = SearchOptions.DetailsNumberOfRows};

            return this.View("Details", advertViewModel);
        }

        [SimpleValidation]
        [SimpleErrorHandleAttribute(Message = ErrorThrown)]
        public virtual ActionResult Gallery(AdvertViewModel viewModel)
        {
            return GetGalleryView(viewModel, "Gallery", new SolrAdvertDto { Id = viewModel.Id });
        }

        [SimpleValidation]
        [SimpleErrorHandleAttribute(Message = ErrorThrown)]
        public virtual ActionResult InvestmentGallery(AdvertViewModel viewModel)
        {
            return GetGalleryView(viewModel, "InvestmentGallery", new SolrAdvertDto { InvestmentId = viewModel.InvestmentId });
        }

        private ActionResult GetGalleryView(AdvertViewModel viewModel, string viewName, SolrAdvertDto solrAdvertDto)
        {
            var advert = this._solrService.Search(solrAdvertDto);

            if (advert == null)
            {
                return this.View(viewName, viewModel);
            }

            var advertElement = advert.SearchResults.FirstOrDefault();

            if (advertElement == null)
            {
                return this.View(viewName, viewModel);
            }

            var advertViewModel = Mapper.Map<ISimpleSolrAdvert, AdvertViewModel>(advertElement);
            advertViewModel.SearchViewModel = viewModel.SearchViewModel; // Search criteria are kept here
            advertViewModel.DisplayedPictureIndex = viewModel.DisplayedPictureIndex;
            advertViewModel.InnerSearchOptions = viewModel.InnerSearchOptions;

            return this.View(viewName, advertViewModel);
        }

        private ActionResult TryInvestmentDetails(InvestmentViewModel viewModel)
        {
            var solrAdvertDto = Mapper.Map<SearchViewModel, SolrAdvertDto>(viewModel.SearchViewModel);
            solrAdvertDto.InvestmentId = viewModel.Id;

            // In an addition search by an InvestmentId
            // var solrAdvertDto = new SolrAdvertDto { InvestmentId = viewModel.Id };

            var searchResults = _solrService.Search(solrAdvertDto, viewModel.InvestmentSearchOptions);

            if (searchResults == null)
            {
                MessageHelper.SendErrorMessage(ViewBag, SolrDidNotFoundAnythingInvestment);
                return View(MVC.Home.Views.Index_Mobile);
            }

            var investmentViewModel = Mapper.Map<SolrResultModel<ISimpleSolrAdvert>, InvestmentViewModel>(searchResults);
            if (investmentViewModel == null)
            {
                MessageHelper.SendErrorMessage(ViewBag, IncorrectResults);
                return View(MVC.Home.Views.Index_Mobile);
            }

            investmentViewModel.SearchViewModel = viewModel.SearchViewModel; // Search criteria are kept here
            investmentViewModel.InvestmentSearchOptions = viewModel.InvestmentSearchOptions; // Search criteria are kept here

            return View("InvestmentDetails", investmentViewModel);
        }

        private ActionResult TryDetails(AdvertViewModel viewModel)
        {
            var advert = this._solrService.Search(new SolrAdvertDto { Id = viewModel.Id });

            if (advert == null)
            {
                MessageHelper.SendErrorMessage(this.ViewBag, SolrDidNotFoundAnythingAdvert);
                return View(MVC.Home.Views.Index_Mobile);
            }

            var advertElement = advert.SearchResults.SingleOrDefault();

            if (advertElement == null)
            {
                MessageHelper.SendErrorMessage(this.ViewBag, SolrDidNotFoundAnythingAdvert);
                return View(MVC.Home.Views.Index_Mobile);
            }

            var advertViewModel = Mapper.Map<ISimpleSolrAdvert, AdvertViewModel>(advertElement);
            if (advertViewModel == null)
            {
                MessageHelper.SendErrorMessage(this.ViewBag, IncorrectResults);
                return View(MVC.Home.Views.Index_Mobile);
            }

            advertViewModel.SearchViewModel = viewModel.SearchViewModel; // Search criteria are kept here

            if (viewModel.IsInvestment)
            {
                advertViewModel.InvestmentViewModel = MapInvestment(
                    viewModel.SearchViewModel, 
                    viewModel.InvestmentId,
                    viewModel.InnerSearchOptions) ?? new InvestmentViewModel();
                advertViewModel.InvestmentViewModel.InvestmentSearchOptions = viewModel.InnerSearchOptions ?? new SearchOptions{PaginationNumerOfRows = SearchOptions.InvestmentNumerOfRows};
                advertViewModel.InvestmentViewModel.SearchViewModel = viewModel.SearchViewModel;
                advertViewModel.InnerSearchOptions = viewModel.InnerSearchOptions;
            }
            else
            {
                var searchOptions = viewModel.InnerSearchOptions ?? new SearchOptions
                    {
                        PaginationNumerOfRows = SearchOptions.DetailsNumberOfRows,
                        PaginationStart = viewModel.SearchViewModel.SearchOptions.PaginationStart
                    };

                advertViewModel.DetailsSearchViewModel = MapDetailsSearchViewModel(
                    viewModel.SearchViewModel, searchOptions);
                advertViewModel.DetailsSearchViewModel.InnerPaginationSearchOptions = searchOptions;
            }

            return View("Details", advertViewModel);
        }

        private SearchViewModel MapDetailsSearchViewModel(SearchViewModel searchViewModel, SearchOptions searchOptions)
        {
            var foundAdverts = _solrService.SearchWithGrouping(
                Mapper.Map<SearchViewModel, SolrAdvertDto>(searchViewModel), searchOptions);

            if (foundAdverts.Matches > 0)
            {
                searchViewModel.GroupedSearchResults = foundAdverts;
            }

            return searchViewModel;
        }

        private InvestmentViewModel MapInvestment(SearchViewModel searchViewModel, string investmentId, SearchOptions searchOptions)
        {
            var solrAdvertDto = Mapper.Map<SearchViewModel, SolrAdvertDto>(searchViewModel);

            if (solrAdvertDto == null)
            {
                return null;
            }

            // In an addition search by an InvestmentId
            solrAdvertDto.InvestmentId = investmentId;

            var searchResults = _solrService.Search(solrAdvertDto, searchOptions);

            if (searchResults == null)
            {
                return null;
            }

            return Mapper.Map<SolrResultModel<ISimpleSolrAdvert>, InvestmentViewModel>(searchResults);
        }
    }
}