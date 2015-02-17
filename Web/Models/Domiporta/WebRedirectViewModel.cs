namespace Trader.Web.Models.Domiporta
{
    using Trader.Services;

    public class WebRedirectViewModel
    {
        private const string NotmobileTrue = "NotMobile=true";

        public string Url { get; set; }

        public WebRedirectViewModel(IConfigurationService configurationService, string parameters)
        {
            Url = string.Concat(configurationService.GetConfiguration(x => x.WebUrl), parameters);
        }
    }
}