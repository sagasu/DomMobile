// -----------------------------------------------------------------------
// <copyright file="SolrMapperHelper.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Common
{
    using System.Web;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class SolrMapperHelper
    {
        public static string MapToDprp(string id, bool encodeUrl = true)
        {
            if (string.IsNullOrEmpty(id)) return id;

            var mappedId = string.Format("/DPRP/{0}", id);

            return encodeUrl ? HttpUtility.UrlEncode(mappedId) : mappedId;
        }
    }
}
