namespace Trader.Web.Helpers
{
    using Trader.Common;
    using Trader.Web.Models.Advert;

    public static class DomiportaHelper
    {
        public static int GetTransactionTypeId(AdvertViewModel advertViewModel)
        {
            return AutoMapperConfig.MapTransactionType(advertViewModel.OperationType);
        }

        public static string CreateRedirectUrl<T>(string actionUrl, T viewModel) where T : class 
        {
            return string.Concat(actionUrl, "?", MvcGetParamsSerializer.Serialize(viewModel));
        }

        /// <summary>
        /// Some versions of IIS have problem with dealing with /? so additional value is added
        /// </summary>
        /// <param name="rawUrl"></param>
        /// <returns></returns>
        public static string PrepareRawUrlForOldIIS(string rawUrl)
        {
            return rawUrl.Replace("/?", "/foo?");
        }
    }
}