namespace Trader.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Ninject.Extensions.Logging;

    using Trader.Common;
    using Trader.Model.Glossaries.Providers;
    using Trader.Model.Solr;
    using Trader.Services;
    using Trader.Web.Attributes;
    using Trader.Web.Helpers;
    using Trader.Web.Models.Search;

    public partial class SearchController : Controller
    {
        private const string ErrorThrown = "Nastąpił błąd przetwarzania danych. Spróbuj ponownie później.";

        private readonly ISolrService _solrService;

        private readonly IDiacriticService _diacriticService;

        private readonly ILogger _logger;

        public SearchController(
            ISolrService solrService,
            IDiacriticService diacriticService,
            ILogger logger)
        {
            _logger = logger;
            _diacriticService = diacriticService;
            _solrService = solrService;
        }

        [SimpleValidation]
        [SimpleErrorHandleAttribute(Message = ErrorThrown)]
        public virtual ActionResult Search(SearchViewModel searchViewModel)
        {
            if (searchViewModel.DistrictSelect.SelectedId != default(int) && !string.IsNullOrEmpty(searchViewModel.City))
            {
                // If DistrictSelect is set create a list of districts to be showed in a view
                searchViewModel.DistrictSelect.ListOfListElement = DistrictProvider.Districts
                    .Where(x => x.Sanitize.Equals(_diacriticService.RemoveDiacriticsAndCastToLower(searchViewModel.City)))
                    .Select(x => new ListElement{Id = x.Id, Name = x.Name}).ToList();
            }

            return View(searchViewModel);
        }

        public virtual ActionResult SearchResult([SearchViewModelBinder] SearchViewModel searchViewModel)
        {
            try
            {
                return TrySearchResult(searchViewModel);
            }
            catch (Exception e)
            {
                this._logger.Error(e.Message);
                MessageHelper.SendErrorMessage(this.ViewBag, ErrorThrown);
                return this.View("Search", searchViewModel); 
            }
        }

        private ActionResult TrySearchResult(SearchViewModel searchViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                MessageHelper.SendErrorMessage(this.ViewBag, "Formularz zawiera nieprawidłowe dane.");
                return this.View("Search", searchViewModel);
            }

            var foundAdverts = _solrService.SearchWithGrouping(
                Mapper.Map<SearchViewModel,SolrAdvertDto>(searchViewModel), searchViewModel.SearchOptions);

            if (foundAdverts.Matches > 0)
            {
                searchViewModel.GroupedSearchResults = foundAdverts;
            }

            return View("SearchResult", searchViewModel);
        }
    }
}