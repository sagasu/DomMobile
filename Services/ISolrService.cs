// -----------------------------------------------------------------------
// <copyright file="ISolrService.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Trader.Model;
    using Trader.Model.Solr;

    /// <summary>
    /// An interface to query solr
    /// </summary>
    public interface ISolrService
    {
        SolrResultModel<ISimpleSolrAdvert> Search(string query);

        SolrResultModel<ISimpleSolrAdvert> Search(SolrAdvertDto solrAdvertDto, SearchOptions searchOptions = null);

        ICollection<KeyValuePair<string, int>> SearchCities(SearchOptions searchOptions = null);

        GroupedResultsModel<SearchResultViewModel> SearchWithGrouping(
            SolrAdvertDto solrAdvertDto,
            SearchOptions searchOptions = null,
            Expression<Func<ISolrAdvert, string>> groupByParameterName = null);
    }
}
