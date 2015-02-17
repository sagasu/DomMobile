namespace Trader.Web.Helpers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Trader.Web.Attributes;

    public static class RegisterOldRoutes
    {
        /// <summary>
        /// Map routes from old web Domiporta.pl
        /// </summary>
        /// <param name="routes">The RouteCollection.</param>
        public static void RegisterRoute(RouteCollection routes)
        {
            var homePageRedirect = new List<RouteElement>
                {
                    new RouteElement("WebDomiportaJob", "praca.asp/{id}"),
                    new RouteElement("WebDomiportaPremiumInfo", "premium-info2.asp/{id}"),
                    new RouteElement("WebDomiportaPrimaryMarket", "rynek-pierwotny.asp/{id}"),
                    new RouteElement("WebDomiportaComercialMarket","rynek-komercyjny.asp/{id}"),
                    new RouteElement("WebDomiportaAdvancedSearch", "search-form.asp/{id}"),
                    new RouteElement("WebDomiportaSearchFormPostMap", "search-form-post-map.asp/{id}"),
                    new RouteElement("WebDomiportaSendUserQuestion", "send-user-question.asp/{id}"),
                    new RouteElement("WebDomiportaSendWithEmailFormPost", "send-with-email-form-post.asp/{id}"),
                    new RouteElement("WebDomiportaStartCookieCheckInfo", "start-cookie-check-info.asp/{id}"),
                    new RouteElement("WebDomiportaUserRemaindLoginAndPasswordForm", "user-remaind-login-and-password-form.asp/{id}"),
                    new RouteElement("WebDomiportaPremiumPackage", "pakiet-premium.asp/{id}"),
                    new RouteElement("WebDomiportaOptionAdverts","opcje-ogloszenia.asp/{id}"),
                    new RouteElement("WebDomiportaMyAdsPodbij","my-ads-podbij.asp/{id}"),
                    new RouteElement("WebDomiportaMapa","mapa/{id}"),
                    new RouteElement("WebDomiportaOfficeMyAdds", "biuro-my-ads.asp/{id}"),
                    new RouteElement("WebDomiportaOfficeProblem","biuro-problem.asp/{id}"),
                    new RouteElement("WebDomiportaCNSave", "cn_save.asp/{id}"),
                };

            foreach (var routeElement in homePageRedirect)
            {
                routes.MapRoute(
                    routeElement.RouteName,
                    routeElement.Route,
                    new { controller = "Domiporta", action = "RedirectToHP", id = UrlParameter.Optional });
            }

            var webPageRedirect = new List<RouteElement>
            {
                new RouteElement("WebDomiportaEditAction","edit-action.asp/{parameters}"),
                new RouteElement("WebDomiportaEditFormPictures","edit-form2-pictures.asp/{parameters}"),
                new RouteElement("WebDomiportaEditFormStart","edit-form2-start.asp/{parameters}"),
                new RouteElement("WebDomiportaKsClipboard", "ks-clipboard-2.asp/{parameters}"),
                new RouteElement("WebDomiportaMyAds", "my-ads.asp/{parameters}"),
                new RouteElement("WebDomiportaPartnersList","partnerzy-lista.asp/{parameters}"),
                new RouteElement("WebDomiportaCatalogSubCatalogArticleTitle", "pl/{*parameters}"),
                new RouteElement("WebDomiportaUserAuthorizationForm","user-authorization-form.asp/{parameters}"),
                new RouteElement("WebDomiportaPPOwnersList", "pp-owners-list,E,all,{parameters}"),
                new RouteElement("WebDomiportaPPOwnersListIISMapping", "pp-owners-list.asp/{parameters}"),
            };

            foreach (var routeElement in webPageRedirect)
            {
                routes.MapRoute(
                    routeElement.RouteName,
                    routeElement.Route,
                    new { controller = "Domiporta", action = "WebRedirect", parameters = UrlParameter.Optional });
            }

            routes.MapRoute(
                "WebDomiportaDetails", // Details for Web domiporta
                "details.asp/{id}", // URL with parameters
                new { controller = "Domiporta", action = "Details", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "WebDomiportaInvestor",
                "inwestor,{fiveNumberId},{nineNumberId}.asp/{parameters}",
                new { controller = "Domiporta", action = "WebRedirect", parameters = UrlParameter.Optional },
                new { fiveNumberId = @"[0-9]{5}", nineNumberId = @"[0-9]{9}" }
            );

            routes.MapRoute(
                "WebDomiportaInvestorIISMapping",
                "inwestor.asp/{parameters}",
                new { controller = "Domiporta", action = "WebRedirect", parameters = UrlParameter.Optional }
            );

            routes.MapRoute(
                "WebDomiportaInwestycja",
                "inwestycja,{firstId},{nineNumberId}.asp/{parameters}",
                new { controller = "Domiporta", action = "Investment", parameters = UrlParameter.Optional },
                new { firstId = WebInvestmentBinder.InvestmentIdShortRegex, nineNumberId = WebInvestmentBinder.AdvertIdShortRegex }
            );

            routes.MapRoute(
                "WebDomiportaInwestycjaIISMapping",
                "inwestycja.asp/{parameters}",
                new { controller = "Domiporta", action = "InvestmentIISMapping", parameters = UrlParameter.Optional }
            );

            routes.MapRoute(
                "WebDomiportaAdvertCategoryCityDistrict",
                "ogloszenia,{categoryId},{city},{district}.asp/{parameters}",
                new { controller = "Domiporta", action = "SearchResult", parameters = UrlParameter.Optional },
                new { categoryId = @"\d+", city = @"\w+", district = @"\w+" }
            );

            routes.MapRoute(
                "WebDomiportaSearchResultsPrimaryMarket",
                "oferty/P/{transactionType}/{categoryName}/{location}/{district}/{parameters}",

                new { controller = "Domiporta", action = "SearchResultPrimaryMarket", parameters = UrlParameter.Optional }
            );

            routes.MapRoute(
                "WebDomiportaSearchResultsSecondaryMarket",
                "oferty/{transactionType}/{categoryName}/{location}/{district}/{street}/{parameters}",
                new { controller = "Domiporta", action = "SearchResultSecondaryMarket", parameters = UrlParameter.Optional }
            );

            // This type of url is incorect due to ASP.NET, see:
            // http://www.hanselman.com/blog/ExperimentsInWackinessAllowingPercentsAnglebracketsAndOtherNaughtyThingsInTheASPNETIISRequestURL.aspx
            // MVC can not handle // so if any of parameters is equal to string.Empty then above rules won't work
            // So system needs to handle parameters manually
            routes.MapRoute(
                "WebDomiportaSearchResultsGuessMarket",
                "oferty/{*parameters}",
                new { controller = "Domiporta", action = "SearchResultGuessMarket", parameters = UrlParameter.Optional }
            );

            // Routes from oferty* are redirected to this link
            routes.MapRoute(
                "WebDomiportaSearchResultsGuessMarketIISRedirect",
                 "search-form-post.asp/{parameters}",
                new { controller = "Domiporta", action = "SearchResultGuessMarketIISRedirect", parameters = UrlParameter.Optional }
            );

            routes.MapRoute(
                "WebDomiportaDetailsWithTitle",
                "details,{categoryId},{advertIdAndAdvertTitle}.asp/{parameters}",
                new { controller = "Domiporta", action = "DetailsWithCategory", parameters = UrlParameter.Optional }
            );

            routes.MapRoute(
                "WebDomiportaGallery",
                "galeria/{advertTitle}/{marketTypeAndAdvertId}/{parameters}",
                new { controller = "Domiporta", action = "Gallery", parameters = UrlParameter.Optional }
            );
        }
    }


    internal class RouteElement
    {
        public RouteElement(string routeName, string route)
        {
            Route = route;
            RouteName = routeName;
        }

        public string RouteName { get; set; }

        public string Route { get; set; }
    }
}