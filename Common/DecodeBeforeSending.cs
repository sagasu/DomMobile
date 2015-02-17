// -----------------------------------------------------------------------
// <copyright file="DecodeBeforeSending.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Common
{
    using System.Web;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DecodeBeforeSending : ISolrMap
    {
        public string Id { get; set; }


        /// <summary>
        /// Id sometimes has value similar to '/DPRP/17355' becauese it is illegar as URL
        /// It is kept as a en encoded value '%2fDPRP%2f17355' before sending to SOLR one has to decode it
        /// </summary>
        /// <param name="key">name of a field.</param>
        /// <returns>Decoded id.</returns>
        public string Map(string key)
        {
            return HttpUtility.UrlDecode(Id);
        }
    }
}
