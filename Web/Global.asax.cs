using System.Net;
using Elmah;
using Microsoft.Practices.ServiceLocation;

namespace Trader.Web
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using log4net.Config;

    using Ninject;
    using Ninject.Extensions.Logging;

    using Trader.Web.Helpers;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        [Inject]
        public ILogger Logger { get; set; }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("ga.aspx");

            RegisterOldRoutes.RegisterRoute(routes);
            RegisterRPRoutes.RegisterRoute(routes);

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);

            RegisterRoutes(RouteTable.Routes);

            ModelMetadataProviders.Current = new CustomModelMetadataProvider();

            XmlConfigurator.Configure();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Response.Clear();

            if (exception != null)
            {
                Logger.Error("Error cought: " + exception.Message);
                ErrorSignal.FromCurrentContext().Raise(exception);

                // clear error on server
                Server.ClearError();

                Response.StatusCode = (int)HttpStatusCode.OK; // Don't throw 500 couse varnish will display service unavailable page.
                Response.Redirect(string.Format("{0}?action={1}&message={2}","~/Home/Index", "Exception", "Error"));
            }
        }
    }
}