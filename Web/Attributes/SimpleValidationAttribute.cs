namespace Trader.Web.Attributes
{
    using System.Web.Mvc;

    using Trader.Web.Controllers;
    using Trader.Web.Extensions;
    using Trader.Web.Helpers;

    public class SimpleValidationAttribute : ActionFilterAttribute
    {
        public const string InvorrectParameters = "Nieprawidłowe parametry.";

        private const string ErrorJsonMessage = "Formularz zawiera nieprawidłowe dane.";

        public string Message { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid)
            {
                return;
            }

            dynamic viewData = filterContext.Controller.ViewData;

            MessageHelper.SendErrorMessage(viewData, string.IsNullOrEmpty(Message) ? InvorrectParameters : Message);


            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                    {
                        Data = new JsonMessage { Message = filterContext.Controller.ViewData.ModelState.ExtractErrorMessage(ErrorJsonMessage), Status = JsonMessageEnum.Error },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    };
            }
            else
            {
                filterContext.Result = new ViewResult() { ViewName = MVC.Home.Views.Index_Mobile, ViewData = viewData };
            }
        }
    }
}