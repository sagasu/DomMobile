namespace Trader.Web.Attributes
{
    using System;
    using System.Web.Mvc;

    using Trader.Web.Helpers;
    using Trader.Web.Models.Domiporta;

    public class WebInvestmentBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new WebInvestmentBinder();
        }
    }

    public class WebInvestmentBinder : IModelBinder
    {
        public const string InvestmentIdShortRegex = "[0-9]{24,26}";
        public const string AdvertIdShortRegex = "[0-9]{9}";

        private const string InvestmentIdLongRegex = "inwestycja," + InvestmentIdShortRegex + ",";
        private const string AdvertIdLongRegex = "," + AdvertIdShortRegex + ".asp";

        private const string CantParseUrl = "Nie udało się przemapować url z webowej wersji domiporty.";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                return TryBindModel(controllerContext, bindingContext);
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError("Global", CantParseUrl);
                return new WebInvestmentViewModel();
            }
        }

        private static WebInvestmentViewModel TryBindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var rawUrl = controllerContext.HttpContext.Request.RawUrl;

            return new WebInvestmentViewModel
                {
                    InvestmentId = RegexHelper.Map(rawUrl, InvestmentIdLongRegex, InvestmentIdShortRegex),
                    AdvertId = RegexHelper.Map(rawUrl, AdvertIdLongRegex, AdvertIdShortRegex)
                };
        }
    }
}