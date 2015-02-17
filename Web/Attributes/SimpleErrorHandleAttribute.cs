using Elmah;

namespace Trader.Web.Attributes
{
    using System.Net;
    using System.Web.Mvc;

    using Ninject;
    using Ninject.Extensions.Logging;

    using Trader.Web.Helpers;

    public class SimpleErrorHandleAttribute : HandleErrorAttribute
    {
        [Inject]
        public ILogger Logger { get; set; }

        private const string InvorrectParameters = "Nieprawidłowe parametry.";

        public string Message { get; set; }

        public override void OnException(ExceptionContext filterContext)
        {
            var viewData = filterContext.Controller.ViewData;

            Logger.Error(filterContext.Exception.Message);
            ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);

            MessageHelper.SendErrorMessage(viewData, string.IsNullOrEmpty(Message) ? InvorrectParameters : Message);

            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK; // Don't throw 500 couse varnish will display service unavailable page.
            filterContext.Result = new ViewResult() { ViewName = MVC.Home.Views.Index_Mobile, ViewData = viewData };
            filterContext.ExceptionHandled = true;
        }
    }
}