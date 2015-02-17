// -----------------------------------------------------------------------
// <copyright file="CityProvider.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Trader.Common;

    using Trader.Model;

    public interface ICityProvider
    {
        IEnumerable<City> GetCityNamesSortedByNumberOfAdverts();

        void RebuildCashedResults();
    }

    /// <summary>
    /// Provide a city, based on a numer of adverts
    /// </summary>
    public class CityProvider : ICityProvider
    {
        private readonly ISolrService _solrService;

        private readonly IDiacriticService _diacriticService;

        private static readonly object SyncRoot = new object();

        private static IEnumerable<City> citiesGroupedByAdverts;

        // I am trying to retrive from solr all cities (distinct), so this numer is really large
        private const int MaxNumerOfRows = 1000; 

        public CityProvider(
            ISolrService solrService,
            IDiacriticService diacriticService
            )
        {
            _solrService = solrService;
            _diacriticService = diacriticService;
        }

        public IEnumerable<City> GetCityNamesSortedByNumberOfAdverts()
        {
            if (citiesGroupedByAdverts != null)
            {
                return citiesGroupedByAdverts;
            }

            // No need to try cath. It is already inside lock method.
            lock (SyncRoot) 
            {
                // Lock is to run RebuildCashedResults only once after application startup
                // Otherwise each application that will call GetCityNamesSortedByNumberOfAdverts before citiesGroupedByAdverts 
                // (it takes time to rebuild it) is generated will start
                // generation proces over again.
                if (citiesGroupedByAdverts == null)
                {
                    RebuildCashedResults();
                }
            }

            return citiesGroupedByAdverts;
        }

        public void RebuildCashedResults()
        {
            var searchResults = _solrService.SearchCities(new SearchOptions() { PaginationNumerOfRows = MaxNumerOfRows });

            citiesGroupedByAdverts = searchResults.Select(x => new City(
                name: x.Key.Capitalize(),
                sanitize: _diacriticService.RemoveDiacriticsAndCastToLower(x.Key)));
        }
    }
}
