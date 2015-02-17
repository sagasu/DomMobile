// -----------------------------------------------------------------------
// <copyright file="GroupModel.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Solr
{
    using System.Collections.Generic;

    public class GroupModel<T> 
    {
        public IEnumerable<T> Documents { get; set; }

        public string GroupValue { get; set; }

        public int NumFound { get; set; }

        public string InvestmentName { get; set; }

        /// <summary>
        /// If null it means that this advert does not belongs to an investment
        /// </summary>
        public string InvestmentId { get; set; }
    }
}
