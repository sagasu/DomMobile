namespace Trader.Model.Solr
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Trader.Common.Attributes;
    using Trader.Model.Common;
    using Trader.Model.Glossaries.Providers;

    public class SearchResultViewModel : IFluentDecorator
    {
        [ScaffoldColumn(false)]
        [StaticReflection]
        public int? NumberOfRooms { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public Money Price { get; set; }

        [StaticReflection]
        public Money PricePerMeter { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int CategoryId { get; set; }

        [UIHint("Decimal")]
        public decimal? SurfaceArea { get; set; }

        [UIHint("CreationDate")]
        public DateTime? CreationDate { get; set; }

        public string Picture { get; set; }

        public string InvestmentPicture { get; set; }

        public string District { get; set; }

        /// <summary>
        /// On whitch floor the flat is located
        /// </summary>
        [ScaffoldColumn(false)]
        [StaticReflection]
        public int? FloorNumber { get; set; }

        /// <summary>
        /// Number of floors in entire building
        /// </summary>
        [ScaffoldColumn(false)]
        [StaticReflection]
        public int? NumberOfFloors { get; set; }

        /// <summary>
        /// Powierzchnia działki
        /// </summary>
        [ScaffoldColumn(false)]
        [StaticReflection]
        public decimal? LandSurface { get; set; }

        /// <summary>
        /// Typ działki
        /// </summary>
        [ScaffoldColumn(false)]
        [StaticReflection]
        public string LandType { get; set; }

        /// <summary>
        /// Rodzaj lokalu
        /// </summary>
        [ScaffoldColumn(false)]
        [StaticReflection]
        public string ComercialType { get; set; }

        /// <summary>
        /// Business wants a control over showing a price or not displaying it
        /// </summary>
        [ScaffoldColumn(false)]
        [StaticReflection]
        public bool? DontShowPrice { get; set; }

        public IEnumerable<ModelMetadata> Decorate(IList<ModelMetadata> modelMetadata)
        {
            new CreateRule<SearchResultViewModel>(x => x.NumberOfRooms, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.FlatId).Show();

            new CreateRule<SearchResultViewModel>(x => x.PricePerMeter, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.RoomId).Hide();
            //new CreateRule<SearchResultViewModel>(x => x.NumberOfFloors, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.RoomId).Show();
            new CreateRule<SearchResultViewModel>(x => x.FloorNumber, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.RoomId).Show();

            new CreateRule<SearchResultViewModel>(x => x.PricePerMeter, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.GarageId).Hide();

            new CreateRule<SearchResultViewModel>(x => x.LandSurface, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.HouseId).Show();
            new CreateRule<SearchResultViewModel>(x => x.NumberOfFloors, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.HouseId).Show();

            new CreateRule<SearchResultViewModel>(x => x.LandType, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.LandId).Show();

            new CreateRule<SearchResultViewModel>(x => x.ComercialType, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.ComercialId).Show();
            new CreateRule<SearchResultViewModel>(x => x.NumberOfFloors, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.ComercialId).Show();

            return modelMetadata;
        }
    }
}