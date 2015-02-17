// -----------------------------------------------------------------------
// <copyright file="ISolrMap.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Common
{
    /// <summary>
    /// Use when an object want to implement mapping to sorl on its own
    /// </summary>
    public interface ISolrMap
    {
        /// <summary>
        /// Maps an instance of an object to a string that will be attached to a solr query
        /// </summary>
        /// <param name="key">
        /// Property name of a calling object.
        /// </param>
        /// <returns>
        /// A string that will be attached to a solr query. If null or empty returned, nothing will be added to a query
        /// </returns>
        string Map(string key);
    }
}
