namespace Trader.Web.Automapper
{
    using AutoMapper;

    using Trader.Common;
    using Trader.Model.Glossaries.Providers;
    using Trader.Services;
    using Trader.Web.Models.Advert;
    using Trader.Web.Models.Domiporta;
    using Trader.Web.Models.DomiportaRP;
    using Trader.Web.Models.Search;

    public class AutoMapperUrlMaps : AutoMapperBase
    {
        public AutoMapperUrlMaps(IPictureService pictureService, IPhoneService phoneService, ISolrService solrService, ICityProvider cityProvider)
            : base(pictureService, phoneService, solrService, cityProvider)
        {
        }

        public override void ConfigureAutoMapper()
        {
            Mapper.CreateMap<DomiportaRPInvestmentViewModel, SearchViewModel>()
                .ForMember(x => x.City, x => x.MapFrom(y => MapCityFromLocation(y)))
                .ForMember(x => x.District, x => x.MapFrom(y => y.District))
                .ForMember(x => x.MarketSegment, x => x.MapFrom(y => MapMarketSegment()))
                ;

            Mapper.CreateMap<DomiportaRPCategorySearchViewModel, SearchViewModel>()
                .ForMember(x => x.City, x => x.MapFrom(y => MapCity(y.City)))
                .ForMember(x => x.CategoryId, x => x.MapFrom(y => y.CategoryId.HasValue ? y.CategoryId.Value : CategoryProvider.DefaultCategoryId))
                .ForMember(x => x.District, x => x.MapFrom(y => y.District))
                .ForMember(x => x.MarketSegment, x => x.MapFrom(y => MapMarketSegment()))
                ;

            // This is just a basic all to all mapping,
            // If one want's to do it right, he should include categoryId in mapping
            // For some categories some search fields are not available
            Mapper.CreateMap<DomiportaRPSearchViewModel, SearchViewModel>()
                .ForMember(x => x.CategoryId, x => x.MapFrom(y => MapCategoryFromRP(y.CategoryId)))
                .ForMember(x => x.Surface, x => x.MapFrom(y => MapRangeCriteria(y.AreaFrom, y.AreaTo)))
                .ForMember(x => x.Price, x => x.MapFrom(y => MapRangeCriteria(y.PriceFrom, y.PriceTo)))
                .ForMember(x => x.NumberOfRooms, x => x.MapFrom(y => MapRangeCriteria(y.RoomCountFrom, y.RoomCountTo)))
                .ForMember(x => x.MarketSegment, x => x.MapFrom(y => MapMarketSegment()))
                ;

            Mapper.CreateMap<DomiportaRPInvestmentViewModel, InvestmentViewModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => SolrMapperHelper.MapToDprp(y.Id, true)))
                .ForMember(x => x.SearchViewModel, x => x.MapFrom(y => new SearchViewModel()))
                ;

            Mapper.CreateMap<WebInvestmentIISMappingViewModel, WebInvestmentViewModel>()
                .ForMember(x => x.AdvertId, x => x.MapFrom(y => y.AdId))
                .ForMember(x => x.InvestmentId, x => x.MapFrom(y => y.InwestycjaId));

            Mapper.CreateMap<GuessMarketViewModel, WebSearchResultViewModelPrimaryMarket>()
                .ForMember(x => x.CategoryId, x => x.MapFrom(y => MapCategoryOrUseDefault(y)))
                .ForMember(x => x.City, x => x.MapFrom(y => y.Miasto))
                .ForMember(x => x.District, x => x.MapFrom(y => GetDistrictFromGuessMarketViewModel(y)))
                .ForMember(x => x.TransactionTypeId, x => x.MapFrom(y => MapTransactionOrUseDefault(y)))
                .ForMember(x => x.Price, x => x.MapFrom(y => y.Price))
                .ForMember(x => x.Area, x => x.MapFrom(y => y.Area))
                .ForMember(x => x.NumberOfRooms, x => x.MapFrom(y => y.NumberOfRooms))
                ;

            Mapper.CreateMap<GuessMarketViewModel, WebSearchResultViewModelSecondaryMarket>()
                .ForMember(x => x.CategoryId, x => x.MapFrom(y => MapCategoryOrUseDefault(y)))
                .ForMember(x => x.City, x => x.MapFrom(y => y.Miasto))
                .ForMember(x => x.District, x => x.MapFrom(y => GetDistrictFromGuessMarketViewModel(y)))
                .ForMember(x => x.TransactionTypeId, x => x.MapFrom(y => y.Trn.HasValue ? y.Trn.Value : TransactionTypeProvider.DefaultTransactionTypeId))
                .ForMember(x => x.Price, x => x.MapFrom(y => y.Price))
                .ForMember(x => x.Area, x => x.MapFrom(y => y.Area))
                .ForMember(x => x.NumberOfRooms, x => x.MapFrom(y => y.NumberOfRooms))
                .ForMember(x => x.MarketSegmentSelectedId, x => x.MapFrom(y =>
                    y.Developer.HasValue && (y.Developer.Value == GuessMarketViewModel.SearchAlsoPrimaryMarket) ?
                    MarketSegmentProvider.AllId :
                    MarketSegmentProvider.SecondaryMarketId
                    ));
        }
    }
}