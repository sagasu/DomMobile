using System.Collections.Generic;

namespace Trader.Web.Helpers
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using Trader.Model.Glossaries.Providers;

    public static class RegisterRPRoutes
    {
        public const string RootSection = "nowe/";
        public const string AllLocalizationsToken = "wszystkie";

        /// <summary>
        /// Register routes from new RP domiporta
        /// This is adapted code taken from domiporta RP project
        /// </summary>
        /// <param name="routes">The RouteCollection.</param>
        public static void RegisterRoute(RouteCollection routes)
        {
            var categories = CategoryProvider.GetCategoriesFromNewRP();

            foreach (var prefix in new Dictionary<string, string> { { string.Empty, "PerformSearch" }, { "rss/", "SearchRss" } })
            {
                foreach (var category in categories)
                {
                    routes.MapRoute(string.Format("{0}search-{1}-with-paging", prefix.Key, category.Name),
                                    string.Format("{0}{1}{2}/{{pageNumber}}", RootSection, prefix.Key, category.Name),
                                    new { controller = "DomiportaRPUrlMap", action = prefix.Value, categoryId = category.Id, pageNumber = 1 },
                                    new { pageNumber = @"\d+" });
                }

                routes.MapRoute(
                    string.Format("search-PerformSearch-{0}", prefix.Value),
                    string.Format("{0}{1}{2}", RootSection, string.IsNullOrEmpty(prefix.Key) ? "search/" : prefix.Key, prefix.Value),
                    new { controller = "DomiportaRPUrlMap", action = prefix.Value}
                );
            }

            foreach (var prefix in new Dictionary<string, string> { { string.Empty, "PerformSearchSeo" }, { "rss/", "SearchRss" } })
            {
                foreach (var category in categories)
                {
                    routes.MapRoute(string.Format("{0}search-{1}-with-localization-and-paging", prefix.Key, category.Name),
                                    string.Format("{0}{1}{2}/{{localization}}/{{pageNumber}}", RootSection, prefix.Key, category.Name),
                                    new { controller = "DomiportaRPUrlMap", action = prefix.Value, categoryId = category.Id, pageNumber = 1 },
                                    new { pageNumber = @"\d+", localization = @"[a-zA-Z]+" });

                    routes.MapRoute(string.Format("{0}search-{1}-with-localization", prefix.Key, category.Name),
                                    string.Format("{0}{1}{2}/{{localization}}", RootSection, prefix.Key, category.Name),
                                    new { controller = "DomiportaRPUrlMap", action = prefix.Value, categoryId = category.Id, localization = AllLocalizationsToken },
                                    new { localization = @"[a-zA-Z]+" });
                }

                routes.MapRoute(
                    string.Format("search-PerformSearchSeo-{0}", prefix.Value),
                    string.Format("{0}{1}{2}", RootSection, string.IsNullOrEmpty(prefix.Key) ? "search/" : prefix.Key, prefix.Value),
                    new { controller = "DomiportaRPUrlMap", action = prefix.Value}
                );
            }

            foreach (var category in categories)
            {
                routes.MapRoute(string.Format("category-{0}-wihth-localization",category.Name),
                                string.Format("{0}{1}/{{province}}_{{city}}_{{district}}/{{parameters}}", RootSection, category.Name),
                                new { controller = "DomiportaRPUrlMap", action = "SearchCategories", categoryId = category.MobileCategoryId, parameters = UrlParameter.Optional });
            }

            routes.MapRoute(
                "investmentsMap",
                string.Format("{0}mapa-inwestycji/{{region}}", RootSection),
                new { controller = "DomiportaRPUrlMap", action = "ShowMap", region = string.Empty });

            // Investment routes
            routes.MapRoute("investment-details-all-ads",
                                    string.Format("{0}inwestycja/{{name}}_{{location}}_{{id}}/all", RootSection),
                                    new { controller = "DomiportaRPUrlMap", action = "ShowOnOnePage" });

            routes.MapRoute("investment-details",
                                     string.Format("{0}inwestycja/{{name}}_{{location}}_{{id}}/{{criteriaId}}", RootSection),
                                     new { controller = "DomiportaRPUrlMap", action = "Show", criteriaId = UrlParameter.Optional });

            routes.MapRoute("investment-details-print",
                                     string.Format("{0}inwestycja/drukuj/{{name}}_{{location}}_{{id}}/{{criteriaId}}", RootSection),
                                     new { controller = "DomiportaRPUrlMap", action = "ShowPrint", criteriaId = UrlParameter.Optional });

            routes.MapRoute(
                "new-investments",
                string.Format("{0}inwestycje/{{city}}_{{district}}/{{parameters}}", RootSection),
                new { controller = "DomiportaRPUrlMap", action = "ShowInvestments", parameters = UrlParameter.Optional });

            routes.MapRoute(
                "new-investments-with-localtion-andpagination",
                string.Format("{0}inwestycje/{{location}}/{{parameters}}", RootSection), // Location can be city or district
                new { controller = "DomiportaRPUrlMap", action = "ShowInvestments", parameters = UrlParameter.Optional });

            routes.MapRoute(
                "new-investments-with-localtion",
                string.Format("{0}inwestycje/{{location}}", RootSection), // Location can be city or district
                new { controller = "DomiportaRPUrlMap", action = "ShowInvestments", location = UrlParameter.Optional });

            routes.MapRoute(
                "new-everything",
                string.Format("{0}", RootSection),
                new { controller = "DomiportaRPUrlMap", action = "ShowInvestments" });
        }
    }
}