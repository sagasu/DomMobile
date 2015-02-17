namespace Trader.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Trader.Model.Glossaries;
    using Trader.Services;
    using Trader.Web.Models.Autocomplete;

    public partial class AutocompleteController : Controller
    {
        private readonly IDiacriticService _diacriticService;

        private readonly ICityProvider _cityProvider;

        public AutocompleteController(
            IDiacriticService diacriticService,
            ICityProvider cityProvider)
        {
            _cityProvider = cityProvider;
            _diacriticService = diacriticService;
        }

        public virtual JsonResult City(string city)
        {
            var cityDform = _diacriticService.RemoveDiacriticsAndCastToLower(city);

            if(string.IsNullOrEmpty(city))
            {
                // Return 5 cities with bigest ammount of Adverts
                return Json(_cityProvider.GetCityNamesSortedByNumberOfAdverts().Take(5), JsonRequestBehavior.AllowGet);
            }

            var communities = _cityProvider.GetCityNamesSortedByNumberOfAdverts()
                                             .Where(x => x.Sanitize.StartsWith(cityDform)).Take(10)
                                             .Select(x => new AutocompleteViewModel{ Name = x.Name }).ToList();

            return Json(
                communities,
                JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult District(string city)
        {
            if(string.IsNullOrEmpty(city))
            {
                return Json(Enumerable.Empty<AutocompleteViewModel>(), JsonRequestBehavior.AllowGet);
            }

            var cityDform = _diacriticService.RemoveDiacriticsAndCastToLower(city);

            // TODO: Create a sanitize list, so thereis no need to call diacritic and to lover each time.
            var communities = new District().GetValues()
                                             .Where(x => x.Sanitize.Equals(cityDform))
                                             .Select(x => new AutocompleteViewModel { Name = x.Name, Id = x.Id}).ToList();
            if (communities.Any())
            {
                communities.Insert(0, new AutocompleteViewModel { Name = "Wybierz", Id = 0 });
            }

            return Json(
                communities,
                JsonRequestBehavior.AllowGet);
        }
    }
}