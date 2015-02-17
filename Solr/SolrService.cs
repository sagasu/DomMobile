namespace Trader.Solr
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using AutoMapper;

    using Microsoft.Practices.ServiceLocation;

    using Ninject;
    using Ninject.Extensions.Logging;

    using SolrNet;
    using SolrNet.Commands.Parameters;
    using SolrNet.Impl;

    using Trader.Model;
    using Trader.Model.Glossaries.Providers;
    using Trader.Model.Solr;
    using Trader.Services;

    public class SolrService : ISolrService
    {
        private readonly ISolrOperations<SimpleSolrAdvert> _solr;

        private static readonly string DefaultOrderPropertyName =
            Common.ReflectionHelper.GetProperty<SolrAdvert>(x => x.InsertionDate).Name;

        private static readonly SortOrder[] DefaultGroupSortParameter =
            new[] { new SortOrder(Common.ReflectionHelper.GetProperty<SolrAdvert>(x => x.LocalPrice).Name) };

        private static readonly string[] DefaultGroupByParameter =
            new[] { Common.ReflectionHelper.GetProperty<SolrAdvert>(x => x.InvestmentGroupField).Name };

        private const int _MaxNumberOfElementsInGroup = 500; // It has to be set, otherwise SolrNet defaults it to 1

        private const string WildeCardQuery = "*:*";

        public SolrService(ILogger logger, IConfigurationService configurationService)
        {
            var connection = new SolrConnection(configurationService.GetConfiguration(x => x.SolrConnectionString));
            var loggingConnection = new LoggingConnection(connection, logger);
            Startup.Init<SolrAdvert>(loggingConnection);
            Startup.Init<SimpleSolrAdvert>(loggingConnection);

            _solr = ServiceLocator.Current.GetInstance<ISolrOperations<SimpleSolrAdvert>>();
        }

        public ICollection<KeyValuePair<string, int>> SearchCities(SearchOptions searchOptions = null)
        {
            ISolrQuery[] solrQueries = new[] { new SolrQuery(WildeCardQuery), };

            if (searchOptions == null)
            {
                searchOptions = new SearchOptions();
            }

            var facet = new FacetParameters { Queries = new[] { new SolrFacetFieldQuery("City") } };


            var solrAdverts = _solr.Query(
                SolrMultipleCriteriaQuery.Create(solrQueries),
                new QueryOptions
                {
                    Rows = searchOptions.PaginationNumerOfRows,
                    Start = searchOptions.PaginationStart,
                    Facet = facet,
                });

            return solrAdverts.FacetFields.First().Value;
        }

        public StandardKernel GetModules()
        {
            //var solr = new Ninject.Integration.SolrNet.SolrNetModule(_ConnectionString);
            //var modules = new INinjectModule[] { solr };
            //return new StandardKernel(modules); 
            return null;
        }

        public SolrResultModel<ISimpleSolrAdvert> Search(string query)
        {
            var solrAdverts = _solr.Query(new SolrQuery(query));

            return solrAdverts == null ? null : Mapper.Map<SolrQueryResults<SimpleSolrAdvert>, SolrResultModel<ISimpleSolrAdvert>>(solrAdverts);
        }

        public SolrResultModel<ISimpleSolrAdvert> Search(SolrAdvertDto solrAdvertDto, SearchOptions searchOptions = null)
        {
            var solrQueries = solrAdvertDto.ToSolrQueries();
            if (solrQueries.Any())
            {
                if(searchOptions == null)
                {
                    searchOptions = new SearchOptions();
                }

                var solrAdverts = _solr.Query(
                    SolrMultipleCriteriaQuery.Create(solrQueries),
                    new QueryOptions
                    {
                        Rows = searchOptions.PaginationNumerOfRows,
                        Start = searchOptions.PaginationStart,
                    });

                var solrResultsViewModel = Mapper.Map<SolrQueryResults<SimpleSolrAdvert>, SolrResultModel<ISimpleSolrAdvert>>(solrAdverts);

                return solrResultsViewModel;
            }

            return null;
        }

        /// <summary>
        /// Map just one element per group, for optimalization reasons
        /// </summary>
        /// <param name="solrAdvertDto"></param>
        /// <param name="searchOptions"></param>
        /// <param name="groupByParameterName"></param>
        /// <returns></returns>
        public GroupedResultsModel<SearchResultViewModel> SearchWithGrouping(
            SolrAdvertDto solrAdvertDto,
            SearchOptions searchOptions = null,
            Expression<Func<ISolrAdvert, string>> groupByParameterName = null)
        {
            var solrQueries = solrAdvertDto.ToSolrQueries();
            // Build wilde card to return all records
            if (!solrQueries.Any())
            {
                solrQueries = new[] { new SolrQuery(WildeCardQuery), };
            }

            if (searchOptions == null)
            {
                searchOptions = new SearchOptions();
            }

            var groupingParameters = new GroupingParameters
            {
                Fields = groupByParameterName == null ? 
                    DefaultGroupByParameter :
                    new[] { Common.ReflectionHelper.GetMember<ISolrAdvert, string>(groupByParameterName).Name },
                Format = GroupingFormat.Grouped,
                Limit = _MaxNumberOfElementsInGroup,
                OrderBy = DefaultGroupSortParameter, // This way the first element has the lowest price, and it's easy to display it in a search results
            };

            var sortProperty = new MobileSearchCriteriaProvider().GetValues().SingleOrDefault(x => x.Id == searchOptions.OrderBy.SelectedId);
            var sortPropertyName = sortProperty == null ? DefaultOrderPropertyName : sortProperty.OrderByFieldName;
            // Sort only InsertionDate from the newst to oldest, other criteria sort from lowest to biggest
            var sortOrders = new[] { new SortOrder(sortPropertyName, sortPropertyName == DefaultOrderPropertyName ? Order.DESC : Order.ASC), }; 

            var solrAdverts = _solr.Query(
                SolrMultipleCriteriaQuery.Create(solrQueries),
                new QueryOptions
                {
                    Rows = searchOptions.PaginationNumerOfRows,
                    Start = searchOptions.PaginationStart,
                    Grouping = groupingParameters,
                    OrderBy = sortOrders
                });

            // The idea is to not require projects that want to use this method to reference Solr.NET assembly,
            // unfortunatelly mapping to a local data type is needed.
            // Map just one element per group, for optimalization reasons
            var groupedResults = Mapper.Map<GroupedResults<SimpleSolrAdvert>, GroupedResultsModel<SearchResultViewModel>>(
                solrAdverts.Grouping.First().Value);

            return groupedResults;
        }
    }
}
