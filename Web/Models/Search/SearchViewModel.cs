namespace Trader.Web.Models.Search
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using Trader.Common;
    using Trader.Common.Attributes;
    using Trader.Model;
    using Trader.Model.Common;
    using Trader.Model.Glossaries;
    using Trader.Model.Glossaries.Providers;
    using Trader.Model.Solr;

    public class SearchViewModel : IFluentDecorator
    {
        private static readonly IEnumerable<int> FlatAndCommercialSurfaceFilter =
            new List<int> { 100, 120, 150, 25, 250, 280 }.Concat(BuildFullFilteredList(new[] { 30, 35, 38 }, from: 3));

        private static readonly IEnumerable<int> HouseSurfaceFilter =
            new List<int> { 100, 120, 150 }.Concat(BuildFullFilteredList(new[] { 200, 250, 280 }, from: 2));

        private static readonly IEnumerable<int> LandSurfaceFilter =
            new List<int> { 100, 150, 1000 }.Concat(BuildFullFilteredList(new[] { 200, 250, 2000 }, from: 2));

        private static readonly IEnumerable<int> RoomSurfaceFilter = BuildFullFilteredList(new[] { 10, 15, 18 });

        private static readonly IEnumerable<int> FlatHouseLandCommercialBuyFilter =
            BuildFullFilteredList(new[] { 100000, 150000, 1000000 });

        private static readonly IEnumerable<int> GarageBuyPriceFilter = BuildFullFilteredList(new[] { 10000, 15000, 100000 });

        private static readonly IEnumerable<int> GarageRentPriceFilter = BuildFullFilteredList(new[] { 100, 150, 1000 });

        private static readonly IEnumerable<int> FlatHouseLandCommercialRentFilter = BuildFullFilteredList(new[] { 1000, 1500, 10000 });

        private static readonly IEnumerable<int> RoomPriceFilter = BuildFullFilteredList(new[] { 100, 150, 1000 });

        private static readonly IEnumerable<int> RoomRentPriceFilter = BuildFullFilteredList(new[] { 100, 150});

        public SearchViewModel()
        {
            CategoryId = CategoryProvider.DefaultCategoryId;
            SearchOptions = new SearchOptions();
            DistrictSelect = new ListElements();
            LandType = new ListElements();
            Province = new ListElements();
            ComercialType = new ListElements();
            MarketSegment = ListElementsBuilder.BuildWitProvider<MarketSegment>();
            TransactionTypeId = TransactionTypeProvider.DefaultTransactionTypeId; // Default transaction type
        }

        public SearchViewModel ShallowCloneWoSearchResultsAndWoMobileSearchCriteria()
        {
            var clone = (SearchViewModel)this.MemberwiseClone();
            clone.GroupedSearchResults = null;
            clone.SearchOptions = clone.SearchOptions.ShallowCloneWoOrder();
            clone.InnerPaginationSearchOptions = null;
            return clone;
        }

        /// <summary>
        /// To display them in Title, and in search result header
        /// </summary>
        [IgnoreUrlSerializationWhenAttribute]
        public string SearchCriteriaAsString { get; set; }

        public SearchOptions SearchOptions { get; set; }

        public SearchOptions InnerPaginationSearchOptions { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CategoryId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [StaticReflection]
        public int? TransactionTypeId { get; set; }

        [DisplayName("Miasto")]
        [StaticReflection]
        public string City { get; set; }

        /// <summary>
        /// District can be showed as an Input or Select, depending on a provided City.
        /// The properties are kept separetly, so there is no need to play with js much - it's easier to manage in C#
        /// </summary>
        [GlossaryBase(ShowChooseOption = true)]
        [UIHint("GlossaryBase")]
        [DisplayName("Dzielnica")]
        [StaticReflection]
        public IListElements DistrictSelect { get; set; }

        [DisplayName("Dzielnica")]
        [StaticReflection]
        public string District { get; set; }

        [UIHint("RangeCriteria")]
        [DisplayName("Cena")]
        public RangeCriteria Price { get; set; }

        [UIHint("RangeCriteria")]
        [DisplayName("Powierzchnia")]
        [StaticReflection]
        public RangeCriteria Surface { get; set; }

        [UIHint("RangeCriteria")]
        [DisplayName("Liczba pokoi")]
        [StaticReflection]
        public RangeCriteria NumberOfRooms { get; set; }

        [UIHint("GlossaryAsRadio")]
        [StaticReflection]
        public IListElements MarketSegment { get; set; }

        [DisplayName("Tylko od osób prywatnych")]
        [StaticReflection]
        public bool IsPrivatePerson { get; set; }

        [ScaffoldColumn(false)]
        [GlossaryBase(ShowChooseOption = true)]
        [UIHint("GlossaryBase")]
        [Display(Name = "Województwo")]
        [StaticReflection]
        public IListElements Province { get; set; }

        [ScaffoldColumn(false)]
        [GlossaryBase(ShowChooseOption = true)]
        [UIHint("GlossaryBase")]
        [Display(Name = "Typ działki")]
        [StaticReflection]
        public IListElements LandType { get; set; }

        [ScaffoldColumn(false)]
        [GlossaryBase(ShowChooseOption = true)]
        [UIHint("GlossaryBase")]
        [Display(Name = "Rodzaj lokalu")]
        [StaticReflection]
        public IListElements ComercialType { get; set; }

        [UIHint("SearchResult")]
        public GroupedResultsModel<SearchResultViewModel> GroupedSearchResults { get; set; }

        /// <summary>
        /// Coppy without search results - for serialization - navigation
        /// </summary>
        /// <returns>Clone of a current object w/o Search results</returns>
        public SearchViewModel ShallowCloneWoSearchResults()
        {
            var clone = (SearchViewModel)this.MemberwiseClone();
            clone.GroupedSearchResults = null;
            clone.InnerPaginationSearchOptions = null;
            return clone;
        }

        /// <summary>
        /// Fluent interface for pagination
        /// </summary>
        /// <returns>Clone of a current object with a next options</returns>
        public SearchViewModel NextPaginationBuilder()
        {
            var clone = (SearchViewModel)this.MemberwiseClone();
            clone.SearchOptions = clone.SearchOptions.NextPaginationBuilder();
            return clone;
        }

        /// <summary>
        /// Fluent interface for pagination
        /// </summary>
        /// <returns>Clone of a current object with a previous options</returns>
        public SearchViewModel PreviousPaginationBuilder()
        {
            var clone = (SearchViewModel)this.MemberwiseClone();
            clone.SearchOptions = clone.SearchOptions.PreviousPaginationBuilder();
            return clone;
        }

        public IEnumerable<ModelMetadata> Decorate(IList<ModelMetadata> modelMetadata)
        {
            if (CategoryId == default(int)) return modelMetadata; // Speed optimalization, no need to check rules

            // Flat
            new CreateRule<SearchViewModel>(x => x.Price, modelMetadata, this).When(
                x => x.CategoryId == CategoryProvider.FlatId).Fill(
                    x => x.Price = MapRangeCriteria(
                        x.Price, 
                    FlatHouseLandCommercialBuyFilter,
                    FlatHouseLandCommercialRentFilter));
            new CreateRule<SearchViewModel>(x => x.Surface, modelMetadata, this).When(
                x => x.CategoryId == CategoryProvider.FlatId).Fill(
                    x => x.Surface = MapRangeCriteria(
                        x.Surface,
                    FlatAndCommercialSurfaceFilter,
                    FlatAndCommercialSurfaceFilter));

            // House
            new CreateRule<SearchViewModel>(x => x.NumberOfRooms, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.HouseId).Hide();
            new CreateRule<SearchViewModel>(x => x.Price, modelMetadata, this).When(
                x => x.CategoryId == CategoryProvider.HouseId).Fill(
                    x => x.Price = MapRangeCriteria(
                        x.Price, 
                    FlatHouseLandCommercialBuyFilter,
                    FlatHouseLandCommercialRentFilter));
            new CreateRule<SearchViewModel>(x => x.Surface, modelMetadata, this).When(
                x => x.CategoryId == CategoryProvider.HouseId).Fill(
                    x => x.Surface = MapRangeCriteria(
                        x.Surface,
                    HouseSurfaceFilter,
                    HouseSurfaceFilter));

            // Land
            new CreateRule<SearchViewModel>(x => x.NumberOfRooms, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.LandId).Hide();
            new CreateRule<SearchViewModel>(x => x.MarketSegment, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.LandId).Hide();
            new CreateRule<SearchViewModel>(x => x.Province, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.LandId).Show();
            new CreateRule<SearchViewModel>(x => x.Province, modelMetadata, this)
                .When(x => x.CategoryId == CategoryProvider.LandId)
                .Fill(x => x.Province = ListElementsBuilder.BuildWitProvider<Province>(Province.SelectedId));
            new CreateRule<SearchViewModel>(x => x.LandType, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.LandId).Show();
            new CreateRule<SearchViewModel>(x => x.LandType, modelMetadata, this)
                .When(x => x.CategoryId == CategoryProvider.LandId)
                .Fill(x => x.LandType = ListElementsBuilder.BuildWitProvider<LandType>(LandType.SelectedId));
            new CreateRule<SearchViewModel>(x => x.Price, modelMetadata, this).When(
                x => x.CategoryId == CategoryProvider.LandId).Fill(
                    x => x.Price = MapRangeCriteria(
                        x.Price,
                    FlatHouseLandCommercialBuyFilter,
                    FlatHouseLandCommercialRentFilter));
            new CreateRule<SearchViewModel>(x => x.Surface, modelMetadata, this).When(
                x => x.CategoryId == CategoryProvider.LandId).Fill(
                    x => x.Surface = MapRangeCriteria(
                        x.Surface,
                    LandSurfaceFilter,
                    LandSurfaceFilter));

            // Commercial
            new CreateRule<SearchViewModel>(x => x.NumberOfRooms, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.ComercialId).Hide();
            new CreateRule<SearchViewModel>(x => x.MarketSegment, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.ComercialId).Hide();
            new CreateRule<SearchViewModel>(x => x.ComercialType, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.ComercialId).Show();
            new CreateRule<SearchViewModel>(x => x.ComercialType, modelMetadata, this)
                .When(x => x.CategoryId == CategoryProvider.ComercialId)
                .Fill(x => x.ComercialType = ListElementsBuilder.BuildWitProvider<ComercialType>(ComercialType.SelectedId));
            new CreateRule<SearchViewModel>(x => x.Price, modelMetadata, this).When(
                x => x.CategoryId == CategoryProvider.ComercialId).Fill(
                    x => x.Price = MapRangeCriteria(
                        x.Price, 
                    FlatHouseLandCommercialBuyFilter,
                    FlatHouseLandCommercialRentFilter));
            new CreateRule<SearchViewModel>(x => x.Surface, modelMetadata, this).When(
                x => x.CategoryId == CategoryProvider.ComercialId).Fill(
                    x => x.Surface = MapRangeCriteria(
                        x.Surface,
                    FlatAndCommercialSurfaceFilter,
                    FlatAndCommercialSurfaceFilter));

            // Room
            new CreateRule<SearchViewModel>(x => x.NumberOfRooms, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.RoomId).Hide();
            new CreateRule<SearchViewModel>(x => x.MarketSegment, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.RoomId).Hide();
            new CreateRule<SearchViewModel>(x => x.IsPrivatePerson, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.RoomId).Hide();
            new CreateRule<SearchViewModel>(x => x.TransactionTypeId, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.RoomId).Hide();
            new CreateRule<SearchViewModel>(x => x.Price, modelMetadata, this).When(
                x => x.CategoryId == CategoryProvider.RoomId).Fill(
                    x => x.Price = MapRangeCriteria(
                        x.Price,
                    RoomPriceFilter,
                    RoomRentPriceFilter));
            new CreateRule<SearchViewModel>(x => x.Surface, modelMetadata, this).When(
                x => x.CategoryId == CategoryProvider.RoomId).Fill(
                    x => x.Surface = MapRangeCriteria(
                        x.Surface,
                    RoomSurfaceFilter,
                    RoomSurfaceFilter));

            //Garage
            new CreateRule<SearchViewModel>(x => x.Surface, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.GarageId).Hide();
            new CreateRule<SearchViewModel>(x => x.NumberOfRooms, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.GarageId).Hide();
            new CreateRule<SearchViewModel>(x => x.MarketSegment, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.GarageId).Hide();

            new CreateRule<SearchViewModel>(x => x.Price, modelMetadata, this).When(
                x => x.CategoryId == CategoryProvider.GarageId).Fill(
                    x => x.Price = MapRangeCriteria(
                        x.Price,
                    GarageBuyPriceFilter,
                    GarageRentPriceFilter));

            return modelMetadata;
        }

        public static IEnumerable<int> BuildFullFilteredList(
            IEnumerable<int> filteredElements, 
            int from = 1,
            int to = 9)
        {
            return
                Enumerable.Range(from, to + 1 - from).SelectMany(
                    modifier =>
                    filteredElements.Select(element => int.Parse(modifier.ToString() + element.ToString().Remove(0, 1))));
        }

        private static RangeCriteria MapRangeCriteria(RangeCriteria currentRangeCriteriaValues, IEnumerable<int> sellFilters, IEnumerable<int> rentFilters)
        {
            var rangeCriteria = new RangeCriteria();
            if (currentRangeCriteriaValues != null)
            {
                rangeCriteria = currentRangeCriteriaValues;
            }

            if(rangeCriteria.From == null) rangeCriteria.From = new GlossaryFilter<int>();
            if(rangeCriteria.To == null) rangeCriteria.To = new GlossaryFilter<int>();

            rangeCriteria.From.FilteredElements = sellFilters;
            rangeCriteria.To.FilteredElements = sellFilters;

            rangeCriteria.From.OptionalFilteredElements = rentFilters;
            rangeCriteria.To.OptionalFilteredElements = rentFilters;

            return rangeCriteria;
        }
    }
}