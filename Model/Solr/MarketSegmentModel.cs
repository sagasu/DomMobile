// -----------------------------------------------------------------------
// <copyright file="MarketSegmentModel.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Solr
{
    using Trader.Common;

    /// <summary>
    /// Specifies what markets to search
    /// </summary>
    public class MarketSegmentModel : ISolrMap
    {
        /// <summary>
        /// By default search both markets
        /// </summary>
        public MarketSegmentModel()
        {
            PrimaryMarket = true;
            SecondaryMarket = true;
        }

        public bool PrimaryMarket { get; set; }

        public bool SecondaryMarket { get; set; }

        public string Map(string key)
        {
            // No need to add it to a query, if results from both markets are going to be returned
            if(PrimaryMarket && SecondaryMarket) return null;

            if (PrimaryMarket) return "InvestmentId:['' TO *]";

            return "-InvestmentId:['' TO *]";
        }
    }
}
