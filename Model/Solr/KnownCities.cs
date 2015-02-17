// -----------------------------------------------------------------------
// <copyright file="KnownCities.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Solr
{
    using System.Linq;

    using Trader.Common;
    using Trader.Model.Glossaries.Providers;

    public class KnownCities : ISolrMap
    {
        //new SolrQueryInList("name", "solr", "samsung", "maxtor");

        public string Map(string key)
        {
            return string.Join(" OR ", CommunityProvider.Communities.Select(x => string.Concat("City:", x.Sanitize)));
        }
    }
}
