// -----------------------------------------------------------------------
// <copyright file="SolrResultModel.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Solr
{
    using System.Collections.Generic;

    /// <summary>
    /// The idea is to be agnostic against solrnet librairy, so only SOLR project is aware of SOLR.NET, to achive that a DTO pattern is used.
    /// </summary>
    /// <typeparam name="T">
    /// Type to keep in collection of search results.
    /// </typeparam>
    public class SolrResultModel<T>
    {
        /// <summary>
        /// The number of elements of this collection is constant - SOLR supports pagination, and returns only T in number it was asked
        /// </summary>
        public IEnumerable<T> SearchResults { get; set; }

        /// <summary>
        /// Overall, how many T matches criteria
        /// </summary>
        public int NumFound { get; set; }
    }
}
