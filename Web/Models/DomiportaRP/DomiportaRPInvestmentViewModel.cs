namespace Trader.Web.Models.DomiportaRP
{
    public class DomiportaRPInvestmentViewModel
    {
        /// <summary>
        /// InvestmentId
        /// </summary>
        public string Id { get; set; }

        // We don't use this field
        // public string Name { get; set; }

        /// <summary>
        /// It i used, co don't comment it
        /// </summary>
        public string Location { get; set; }

        public string City { get; set; }

        public string District { get; set; }
    }
}