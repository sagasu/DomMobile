using Trader.Solr;

namespace Trader.Web.Helpers
{
    using System;
    using System.Linq;
    using System.Web;

    using AutoMapper;

    using Trader.Common;
    using Trader.Model.Common;
    using Trader.Model.Glossaries;
    using Trader.Model.Glossaries.Providers;
    using Trader.Model.Solr;
    using Trader.Services;
    using Trader.Web.Automapper;
    using Trader.Web.Models;
    using Trader.Web.Models.Advert;
    using Trader.Web.Models.Search;

    public interface IAutoMapperConfig
    {
        void ConfigureAutoMapper();
    }

    public class AutoMapperConfig : AutoMapperBase
    {
        public AutoMapperConfig(IPictureService pictureService, IPhoneService phoneService, ISolrService solrService, ICityProvider cityProvider)
            : base(pictureService, phoneService, solrService, cityProvider)
        {
        }

        public override void ConfigureAutoMapper()
        {
            Mapper.CreateMap<ISimpleSolrAdvert, AdvertViewModel>()
                .ForMember(x => x.Price, x => x.MapFrom(y => 
                    y.AdvertData.Allads_Cena.HasValue ? 
                    new Money{ Amount = y.AdvertData.Allads_Cena.Value, Currency = y.AdvertData.Allads_Cena_Currency} :
                    null))
                .ForMember(x => x.PricePerMeter, x => x.MapFrom(y =>
                    y.AdvertData.Allads_cena_metra.HasValue ?
                        new Money
                            {
                                Amount = y.AdvertData.Allads_cena_metra.Value, 
                                Currency = string.IsNullOrEmpty(y.AdvertData.Allads_cena_metra_Currency) ? y.AdvertData.Allads_Cena_Currency : y.AdvertData.Allads_cena_metra_Currency
                            } :
                        null))
                .ForMember(x => x.District, x => x.MapFrom(y => y.AdvertData.Allads_Dzielnica))
                .ForMember(x => x.BuildingCategory, x => x.MapFrom(y => y.AdvertData.Allads_kategoria))
                .ForMember(x => x.InvestmentId, x => x.MapFrom(y => HttpUtility.UrlEncode(y.AdvertData.Allads_InwestycjaID)))
                .ForMember(x => x.IsInvestment, x => x.MapFrom(y => IsInvestment(y)))
                .ForMember(x => x.NumberOfFloors, x => x.MapFrom(y => y.AdvertData.Allads_Liczba_pieter))
                .ForMember(x => x.NumberOfRooms, x => x.MapFrom(y => y.AdvertData.Allads_Liczba_pokoi))
                .ForMember(x => x.Material, x => x.MapFrom(y => y.AdvertData.Allads_material))
                .ForMember(x => x.Description, x => x.MapFrom(y => y.AdvertData.Allads_Opis))
                .ForMember(x => x.ShortDescription, x => x.MapFrom(y => y.AdvertData.Allads_KrotkiOpis))
                .ForMember(x => x.FloorNumber, x => x.MapFrom(y => y.AdvertData.Allads_pietro))
                .ForMember(x => x.Surface, x => x.MapFrom(y => y.AdvertData.Allads_powierzchnia))
                .ForMember(x => x.CreationYear, x => x.MapFrom(y => y.AdvertData.Allads_Rocznik))
                .ForMember(x => x.Subject, x => x.MapFrom(y => y.AdvertData.Allads_Temat))
                .ForMember(x => x.Id, x => x.MapFrom(y => HttpUtility.UrlEncode(y.Id)))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.AdvertData.Allads_Name))
                .ForMember(x => x.LandSurface, x => x.MapFrom(y => y.AdvertData.Allads_Pow_dzial)) // Allads_dzialka_powierzchnia
                .ForMember(x => x.LandType, x => x.MapFrom(y => SimpleMapCategory(y.AdvertData.Allads_kategoria)))
                .ForMember(x => x.ComercialType, x => x.MapFrom(y => SimpleMapCategory(y.AdvertData.Allads_kategoria)))
                .ForMember(x => x.CategoryId, x => x.MapFrom(y => y.AdvertData.Allads_CategoryId))
                .ForMember(x => x.Pictures, x => x.MapFrom(y => y.AdvertData.Pictures.Where(z => !string.IsNullOrEmpty(z)).Select(picture => 
                    _pictureService.BuildPicturePath(picture, PictureService.PictureSize.Medium))))
                .ForMember(x => x.InvestmentPicture, x => x.MapFrom(y => _pictureService.BuildPicturePath(y.AdvertData.Allads_InwestycjaPicture, PictureService.PictureSize.Medium)))
                .ForMember(x => x.UserViewModel, x => x.MapFrom(y => Mapper.Map<ISimpleSolrAdvert, UserViewModel>(y)))
                .ForMember(x => x.OperationType, x => x.MapFrom(y =>y.AdvertData.Allads_Operacja))
                .ForMember(x => x.DontShowPrice, x => x.MapFrom(y => y.AdvertData.DontShowPrice))
                ;

            Mapper.CreateMap<ISimpleSolrAdvert, SearchViewModel>()
                .ForMember(x => x.CategoryId, x => x.MapFrom(y => MapCategoryFromRP(y.AdvertData.Allads_CategoryId)))
                .ForMember(x => x.TransactionTypeId, x => x.MapFrom(y => MapTransactionType(y.AdvertData.Allads_Operacja)))
                ;

            Mapper.CreateMap<ISimpleSolrAdvert, UserViewModel>()
                .ForMember(x => x.Address, x => x.MapFrom(y => y.AdvertData.UsersAddress))
                .ForMember(x => x.City, x => x.MapFrom(y => y.AdvertData.UsersCity))
                .ForMember(x => x.Email, x => x.MapFrom(y => Mapper.Map<ISimpleSolrAdvert, EmailViewModel>(y)))
                .ForMember(x => x.Phone, x => x.MapFrom(y => Mapper.Map<ISimpleSolrAdvert, PhoneViewModel>(y)))
                .ForMember(x => x.ZipCode, x => x.MapFrom(y => y.AdvertData.UsersZipCode));

            Mapper.CreateMap<ISimpleSolrAdvert, EmailViewModel>()
                .ForMember(x => x.DestinationEmail, x => x.MapFrom(y => y.AdvertData.UsersEmail))
                .ForMember(x => x.IsDestinationEmailValid, x => x.MapFrom(y => EmailValidator.IsValid(y.AdvertData.UsersEmail)))
                .ForMember(x => x.AdvertId, x => x.MapFrom(y => HttpUtility.UrlEncode(y.Id)));

            Mapper.CreateMap<ISimpleSolrAdvert, PhoneViewModel>()
                .ForMember(x => x.FirstPhone, x => x.MapFrom(y => _phoneService.GetNumber(y.AdvertData.UsersFirstPhone)))
                .ForMember(x => x.MobilePhone, x => x.MapFrom(y => _phoneService.GetNumber(y.AdvertData.UsersMobilPhone)))
                .ForMember(x => x.SecondPhone, x => x.MapFrom(y => _phoneService.GetNumber(y.AdvertData.UsersSecondPhone)));

            Mapper.CreateMap<SolrResultModel<ISimpleSolrAdvert>, InvestmentViewModel>()
                .ConstructUsing(s =>
                    {
                        if (s == null)
                        {
                            return null;
                        }

                        var firstElement = s.SearchResults.FirstOrDefault();    
                        if (firstElement == null)
                        {
                            return null;
                        }

                        return new InvestmentViewModel
                            {
                                Picture = _pictureService.BuildPicturePath(firstElement.AdvertData.Allads_InwestycjaPicture, PictureService.PictureSize.Medium),
                                Name = firstElement.AdvertData.Allads_Name,
                                Id = HttpUtility.UrlEncode(firstElement.AdvertData.Allads_InwestycjaID),
                                City = firstElement.AdvertData.UsersCity,
                                District = firstElement.AdvertData.Allads_Dzielnica,
                                Street = firstElement.AdvertData.Allads_Ulica,
                                RealizationTime = firstElement.AdvertData.Allads_TerminRealizacji,
                                Email = Mapper.Map<ISimpleSolrAdvert, EmailViewModel>(firstElement),
                                Phone = Mapper.Map<ISimpleSolrAdvert, PhoneViewModel>(firstElement),
                                SearchResultViewModel = Mapper.Map<SolrResultModel<ISimpleSolrAdvert>, SolrResultModel<SearchResultViewModel>>(s),
                            };
                    })
                ;

            Mapper.CreateMap<SolrResultModel<ISimpleSolrAdvert>, SolrResultModel<SearchResultViewModel>>()
                .ForMember(x => x.NumFound, x => x.MapFrom(y => y.NumFound))
                .ForMember(x => x.SearchResults, x => x.MapFrom(y => y.SearchResults.Select(Mapper.Map<ISimpleSolrAdvert,SearchResultViewModel>)))
                ;

            Mapper.CreateMap<ISimpleSolrAdvert, Money>()
                .ForMember(x => x.Amount, x => x.MapFrom(y => y.AdvertData.Allads_Cena))
                .ForMember(x => x.Currency, x => x.MapFrom(y => y.AdvertData.Allads_Cena_Currency))
                ;

            Mapper.CreateMap<ISimpleSolrAdvert, SearchResultViewModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => HttpUtility.UrlEncode(y.Id)))
                .ForMember(x => x.City, x => x.MapFrom(y => y.AdvertData.Allads_Miasto))
                .ForMember(x => x.Price, x => x.MapFrom(y => y.AdvertData.Allads_Cena.HasValue ? 
                    new Money(){Amount = y.AdvertData.Allads_Cena.Value, Currency = y.AdvertData.Allads_Cena_Currency} :
                    null))
                .ForMember(x => x.Street, x => x.MapFrom(y => y.AdvertData.Allads_Ulica))
                .ForMember(x => x.SurfaceArea, x => x.MapFrom(y => y.AdvertData.Allads_powierzchnia))
                .ForMember(x => x.PricePerMeter, x => x.MapFrom(y => y.AdvertData.Allads_cena_metra.HasValue ?
                    new Money()
                        {
                            Amount = y.AdvertData.Allads_cena_metra.Value,
                            Currency = string.IsNullOrEmpty(y.AdvertData.Allads_cena_metra_Currency) ? y.AdvertData.Allads_Cena_Currency : y.AdvertData.Allads_cena_metra_Currency
                        } :
                    null))
                .ForMember(x => x.NumberOfRooms, x => x.MapFrom(y => y.AdvertData.Allads_Liczba_pokoi))
                .ForMember(x => x.District, x => x.MapFrom(y => y.AdvertData.Allads_Dzielnica))
                .ForMember(x => x.CreationDate, x => x.MapFrom(y => y.AdvertData.Allads_InsertIonDate))
                .ForMember(x => x.FloorNumber, x => x.MapFrom(y => y.AdvertData.Allads_pietro))
                .ForMember(x => x.Picture, x => x.MapFrom(y => GetPicture(y)))
                .ForMember(x => x.InvestmentPicture, x => x.MapFrom(y => _pictureService.BuildPicturePath(y.AdvertData.Allads_InwestycjaPicture, PictureService.PictureSize.Min)))
                .ForMember(x => x.LandType, x => x.MapFrom(y => MapCategory<LandType>(y.AdvertData.Allads_kategoria)))
                .ForMember(x => x.LandSurface, x => x.MapFrom(y => y.AdvertData.Allads_Pow_dzial)) // Allads_dzialka_powierzchnia`
                .ForMember(x => x.ComercialType, x => x.MapFrom(y => MapCategory<ComercialType>(y.AdvertData.Allads_kategoria)))
                .ForMember(x => x.CategoryId, x => x.MapFrom(y => y.AdvertData.Allads_CategoryId))
                .ForMember(x => x.NumberOfFloors, x => x.MapFrom(y => y.AdvertData.Allads_Liczba_pieter))
                .ForMember(x => x.DontShowPrice, x => x.MapFrom(y => y.AdvertData.DontShowPrice))
                ;

            Mapper.CreateMap<SearchViewModel, SolrAdvertDto>()
                .ForMember(x => x.LocalPrice, x => x.MapFrom(y => y.Price))
                .ForMember(x => x.SqMetAreal, x => x.MapFrom(y => y.Surface))
                .ForMember(x => x.RoomsCount, x => x.MapFrom(y => y.NumberOfRooms))
                .ForMember(x => x.TransactionType, x => x.MapFrom(y => y.TransactionTypeId))
                .ForMember(x => x.Quarter, x => x.MapFrom(y => MapDistrict(y)))
                .ForMember(x => x.Region, x => x.MapFrom(y => MapFromProvider<Province>(y.Province, true))) // Solr keeps polish names for this field
                .ForMember(x => x.PropertyCateory, x => x.MapFrom(y => MapStr(MapFromProvider<LandType>(y.LandType, false),MapFromProvider<ComercialType>(y.ComercialType, false))))
                .ForMember(x => x.Rynek, x => x.MapFrom(y =>
                                    y.IsPrivatePerson ? MarketEnum.wtorny : // If from private person, then only secondary market is searched
                                        y.TransactionTypeId == TransactionTypeProvider.DefaultTransactionTypeId ? // Only for a 'sold' transaction type.
                                            y.MarketSegment.SelectedId == MarketSegmentProvider.PrimaryMarketId ? // If 'primary market' was selected.
                                                MarketEnum.pierwotny :
                                                y.MarketSegment.SelectedId == MarketSegmentProvider.SecondaryMarketId ? // If 'secondary market' was selected.
                                                       MarketEnum.wtorny :
                                                       MarketEnum.nieustawiony :
                                            MarketEnum.nieustawiony))
                .ForMember(x => x.IsPrivate, x => x.MapFrom(y => y.IsPrivatePerson))
                .ForMember(x => x.City, x => x.MapFrom(y => new SolrSearchCity(y.City)))
                .ForMember(x => x.CategoryId, x => x.MapFrom(y => new SolrSearchCategoryAndParent(y.CategoryId)))
                ;
        }

        public static int MapTransactionType(string transactionName)
        {
            var transactionTypeId = TransactionTypeProvider.DefaultTransactionTypeId;
            var transactionType =
                TransactionTypeProvider.TransactionTypes.SingleOrDefault(
                    x => x.Name.Equals(transactionName, StringComparison.InvariantCultureIgnoreCase));
            if (transactionType != null)
            {
                transactionTypeId = transactionType.Id;
            }

            return transactionTypeId;
        }

        private static bool IsInvestment(ISimpleSolrAdvert y)
        {
            return string.IsNullOrEmpty(y.AdvertData.Allads_InwestycjaID) ? false : true;
        }

        private string GetPicture(ISimpleSolrAdvert simpleSolrAdvert)
        {
            // if (IsInvestment(simpleSolrAdvert)) return simpleSolrAdvert.AdvertData.Allads_InwestycjaPicture;

            return simpleSolrAdvert.AdvertData.Pictures.Where(z => !string.IsNullOrEmpty(z)).Select(
                picture => _pictureService.BuildPicturePath(picture, PictureService.PictureSize.Min)).FirstOrDefault();
        }

        private string MapStr(string mapFromProvider, string s)
        {
            var concated = string.Concat(mapFromProvider, s);
            if(string.IsNullOrEmpty(concated))
            {
                return null;
            }
            return concated;
        }

        protected string SimpleMapCategory(string category)
        {
            var categories = category.Trim().Trim(';').Split(';');

            return string.Join(", ", categories.Where(x => !string.IsNullOrEmpty(x)));
        }

        protected string MapCategory<T>(string category) where T : IKeptInCodeGlossaryWSanitize<T>
        {
            if (string.IsNullOrEmpty(category))
            {
                return category;
            }

            var cleanCategories = category.Trim().Trim(';').ToLower().Split(';');

            if (!cleanCategories.Any())
            {
                return string.Empty; // Garbage.
            }

            var provider = (T)Activator.CreateInstance(typeof(T));

            // It keeps an order of provider not a category string, due to that categories are displayed always in this same order.
            var displayValuesForCategories = provider.GetValues().Where(x => cleanCategories.Any(y => x.Sanitize == y));

            return string.Join(", ", displayValuesForCategories.Select(x => x.Name));
        }

        private static string MapFromProvider<T>(IListElements listElements, bool useSanitizedName = true) where T : IKeptInCodeGlossaryWSanitize<T>
        {
            if (listElements == null)
            {
                return null;
            }

            var provider = (T)Activator.CreateInstance(typeof(T));
            var selectedElement = provider.GetValues().SingleOrDefault(x => x.Id == listElements.SelectedId);

            if (selectedElement != null)
            {
                if (useSanitizedName)
                {
                    return selectedElement.Sanitize;
                }

                return selectedElement.Name;
            }

            return null;
        }

        /// <summary>
        /// This is extracted as method so it doesn't need to be called each time
        /// </summary>
        /// <param name="searchViewModel">Search view model</param>
        /// <returns>District based on a criteria in searchViewModel</returns>
        private static SolrSearchDistrict GetDistrictFromSelect(SearchViewModel searchViewModel)
        {
            var selectedDistrict =
                            DistrictProvider.Districts.SingleOrDefault(district => district.Id == searchViewModel.DistrictSelect.SelectedId);
            return (searchViewModel.DistrictSelect == null || selectedDistrict == null)
                                          ? null
                                          : new SolrSearchDistrict(selectedDistrict.Name);
        }

        /// <summary>
        /// There are two properties that may keep district: District and DistrictSelect
        /// Idea is to return value from a District, and if it is not set use DistrictSelect
        /// </summary>
        /// <param name="searchViewModel">Search view model</param>
        /// <returns>District based on a criteria in searchViewModel</returns>
        private static SolrSearchDistrict MapDistrict(SearchViewModel searchViewModel)
        {
            return !string.IsNullOrEmpty(searchViewModel.District) ?
                new SolrSearchDistrict(searchViewModel.District) : 
                GetDistrictFromSelect(searchViewModel);
        }
    }
}