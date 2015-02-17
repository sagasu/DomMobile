// -----------------------------------------------------------------------
// <copyright file="AutoMapperConfigSolr.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Solr
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using AutoMapper;

    using SolrNet;

    using Trader.Model;
    using Trader.Model.Solr;

    public class AutoMapperConfigSolr : IAutoMapperModule
    {
        public void Configure()
        {
            Mapper.CreateMap<GroupedResults<SimpleSolrAdvert>, GroupedResultsModel<SearchResultViewModel>>()
                .ForMember(x => x.Groups, x => x.MapFrom(y => y.Groups.Select(Mapper.Map<Group<SimpleSolrAdvert>, GroupModel<SearchResultViewModel>>)))
                .ForMember(x => x.Matches, x => x.MapFrom(y => y.Matches))
                .ForMember(x => x.Ngroups, x => x.MapFrom(y => y.Ngroups))
                ;

            Mapper.CreateMap<Group<SimpleSolrAdvert>, GroupModel<SearchResultViewModel>>()
                .ForMember(x => x.Documents, x => x.MapFrom(y => MapOneElement(Mapper.Map<ISimpleSolrAdvert, SearchResultViewModel>(y.Documents.FirstOrDefault())))) // Map just one element (first one) for optimalization reasons
                .ForMember(x => x.GroupValue, x => x.MapFrom(y => y.GroupValue))
                .ForMember(x => x.NumFound, x => x.MapFrom(y => y.NumFound))
                .ForMember(x => x.InvestmentId, x => x.MapFrom(y => HttpUtility.UrlEncode(GetInvestmentId(y))))
                .ForMember(x => x.InvestmentName, x => x.MapFrom(y => GetInvestmentName(y)))
                ;

            Mapper.CreateMap<SolrQueryResults<SimpleSolrAdvert>, SolrResultModel<ISimpleSolrAdvert>>()
                .ForMember(x => x.NumFound, x => x.MapFrom(y => y.NumFound))
                .ForMember(x => x.SearchResults, x => x.MapFrom(y => y.AsEnumerable()))
                ;
        }

        private static IEnumerable<SearchResultViewModel> MapOneElement(SearchResultViewModel map)
        {
            if (map == null)
            {
                return Enumerable.Empty<SearchResultViewModel>();
            }

            return new List<SearchResultViewModel> { map };
        }

        private static string GetInvestmentName(Group<SimpleSolrAdvert> @group)
        {
            if (@group != null)
            {
                var firstDoc = @group.Documents.FirstOrDefault();
                if (firstDoc != null)
                {
                    return firstDoc.AdvertData.Allads_Name;
                }
            }

            return null;
        }

        private static string GetInvestmentId(Group<SimpleSolrAdvert> @group)
        {
            if (@group != null)
            {
                var firstDoc = @group.Documents.FirstOrDefault();
                if(firstDoc != null)
                {
                    return firstDoc.AdvertData.Allads_InwestycjaID;
                }
            }

            return null;
        }
    }
}
