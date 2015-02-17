namespace Trader.Web.Models.Domiporta
{
    public class WebInvestmentViewModel
    {
        public string InvestmentId { get; set; }

        public string AdvertId { get; set; }
    }

    /// <summary>
    /// This class represent parameters that are created by IIS rewrite rule, do not change them.
    /// </summary>
    public class WebInvestmentIISMappingViewModel
    {
        public string InwestycjaId { get; set; }

        public string AdId { get; set; }
    }
}