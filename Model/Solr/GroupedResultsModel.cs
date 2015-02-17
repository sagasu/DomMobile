// -----------------------------------------------------------------------
// <copyright file="GroupedResultsModel.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Solr
{
    using System.Collections.Generic;

    using Trader.Common.Attributes;

    /// <summary>
    /// The idea is to be agnostic against solrnet librairy, so only SOLR project is aware of SOLR.NET, to achive that a DTO pattern is used
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class GroupedResultsModel<T> where T : class
    {
        public ICollection<GroupModel<T>> Groups { get; set; }

        /// <summary>
        /// Number of adverts found matching the criteria - overall
        /// </summary>
        [IgnoreUrlSerializationWhen]
        public int Matches { get; set; }

        [IgnoreUrlSerializationWhen]
        public int? Ngroups { get; set; }
    }
}
