namespace Trader.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Trader.Web.Helpers;
    using Trader.Web.Models.Advert;
    using Trader.Web.Models.DomiportaRP;
    using Trader.Web.Models.Search;

    public partial class DomiportaRPUrlMapController : Controller
    {
        public virtual ActionResult PerformSearch(DomiportaRPSearchViewModel viewModel)
        {
            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("SearchResult", "Search"),
                    Mapper.Map<DomiportaRPSearchViewModel, SearchViewModel>(viewModel)));
        }

        public virtual ActionResult PerformSearchSeo(DomiportaRPSearchViewModel viewModel)
        {
            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("SearchResult", "Search"),
                    Mapper.Map<DomiportaRPSearchViewModel, SearchViewModel>(viewModel)));
        }

        public virtual ActionResult SearchRss(DomiportaRPSearchViewModel viewModel)
        {
            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("SearchResult", "Search"),
                    Mapper.Map<DomiportaRPSearchViewModel, SearchViewModel>(viewModel)));
        }

        public virtual ActionResult ShowMap(DomiportaRPInvestmentViewModel viewModel)
        {
            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("Details", "Advert"),
                    Mapper.Map<DomiportaRPInvestmentViewModel, SearchViewModel>(viewModel)));
        }

        public virtual ActionResult ShowOnOnePage(DomiportaRPInvestmentViewModel viewModel)
        {
            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("Details", "Advert"),
                    Mapper.Map<DomiportaRPInvestmentViewModel, SearchViewModel>(viewModel)));
        }

        public virtual ActionResult Show(DomiportaRPInvestmentViewModel viewModel)
        {
            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("InvestmentDetails", "Advert"),
                    Mapper.Map<DomiportaRPInvestmentViewModel, InvestmentViewModel>(viewModel)));
        }

        public virtual ActionResult ShowPrint(DomiportaRPInvestmentViewModel viewModel)
        {
            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("Details", "Advert"),
                    Mapper.Map<DomiportaRPInvestmentViewModel, SearchViewModel>(viewModel)));
        }

        public virtual ActionResult ShowInvestments(DomiportaRPInvestmentViewModel viewModel)
        {
            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("SearchResult", "Search"),
                    Mapper.Map<DomiportaRPInvestmentViewModel, SearchViewModel>(viewModel)));
        }

        public virtual ActionResult SearchCategories(DomiportaRPCategorySearchViewModel viewModel)
        {
            return this.Redirect(
                DomiportaHelper.CreateRedirectUrl(
                    Url.Action("SearchResult", "Search"),
                    Mapper.Map<DomiportaRPCategorySearchViewModel, SearchViewModel>(viewModel)));
        }
    }
}