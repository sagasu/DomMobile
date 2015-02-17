namespace Trader.Web.Extensions
{
    using System.Web.Mvc;

    using Trader.Common;

    public static class UrlHelperExtensions
    {
        public static string Url<T>(this UrlHelper urlHelper, ActionResult actionResult, T viewModel) where T : class
        {
            return string.Format(
                "{0}?{1}", urlHelper.Action(actionResult), MvcGetParamsSerializer.Serialize<T>(viewModel));
        }
    }
}