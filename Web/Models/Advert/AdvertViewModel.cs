namespace Trader.Web.Models.Advert
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Trader.Common.Attributes;
    using Trader.Model;
    using Trader.Model.Common;
    using Trader.Model.Glossaries.Providers;
    using Trader.Web.Models.Search;

    public class AdvertViewModel : IFluentDecorator, IAdvertIdRequired
    {
        /// <summary>
        /// To keep knowledge about search criteria, so we can navigate back and keep it
        /// </summary>
        public SearchViewModel SearchViewModel { get; set; }

        /// <summary>
        /// Search results that are displayed in a list (similar adverts, that fulfills search criteria) are ketp here
        /// </summary>
        public SearchViewModel DetailsSearchViewModel { get; set; }

        /// <summary>
        /// If it is a detail from a primary market that belongs to an investment
        /// a list of adverts from an investment is build based on this view
        /// </summary>
        public InvestmentViewModel InvestmentViewModel { get; set; }

        public SearchOptions InnerSearchOptions { get; set; }

        [StaticReflection]
        public string Id { get; set; }

        public string Name { get; set; }

        public Money Price { get; set; }

        [StaticReflection]
        public Money PricePerMeter { get; set; }

        public string District { get; set; }

        public string InvestmentId { get; set; }

        public bool IsInvestment { get; set; }

        [IgnoreUrlSerializationWhen]
        public string InvestmentPicture { get; set; }

        public int CategoryId { get; set; }

        /// <summary>
        /// Usually it is equal to transaction type but not allways
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// ie. Apartamentowiec
        /// </summary>
        [StaticReflection]
        public string BuildingCategory { get; set; }

        /// <summary>
        /// On whitch floor the flat is placed
        /// </summary>
        [StaticReflection]
        public int? FloorNumber { get; set; }

        /// <summary>
        /// Number of Floor in entire building
        /// </summary>
        [StaticReflection]
        public int? NumberOfFloors { get; set; }

        /// <summary>
        /// How many rooms has a flat
        /// </summary>
        [StaticReflection]
        public int? NumberOfRooms { get; set; }

        [StaticReflection]
        public int? CreationYear { get; set; }

        [StaticReflection]
        public string Material { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public decimal? Surface { get; set; }

        /// <summary>
        /// It might be this same as Subject in SolrAdvert
        /// </summary>
        public string Subject { get; set; }

        public List<string> Pictures { get; set; }

        public int DisplayedPictureIndex { get; set; }

        public UserViewModel UserViewModel { get; set; }

        [StaticReflection]
        [ScaffoldColumn(false)]
        public decimal? LandSurface { get; set; }

        /// <summary>
        /// Typ działki
        /// </summary>
        [StaticReflection]
        [ScaffoldColumn(false)]
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

        /// <summary>
        /// Fluent interface to based on a current object build a new one with only important parameters to display gallery - navigation
        /// </summary>
        /// <returns></returns>
        public AdvertViewModel BuildSmallVersion()
        {
            return new AdvertViewModel
                {
                    Id = Id, 
                    SearchViewModel = SearchViewModel == null ? null : SearchViewModel.ShallowCloneWoSearchResults(),
                    DisplayedPictureIndex = this.DisplayedPictureIndex,
                    IsInvestment = IsInvestment,
                    InvestmentId = InvestmentId,
                    InnerSearchOptions = InnerSearchOptions,
                };
        }

        public InvestmentViewModel BuildInvestment()
        {
            return new InvestmentViewModel
                {
                    Id = InvestmentId,
                    SearchViewModel = SearchViewModel == null ? null : SearchViewModel.ShallowCloneWoSearchResults(),
                    InvestmentSearchOptions = this.InnerSearchOptions,
                };
        }

        public AdvertViewModel BuildNextPicture()
        {
            var smallVersion = BuildSmallVersion();
            if ((this.Pictures != null) && (this.Pictures.Count - 1 > smallVersion.DisplayedPictureIndex))
            {
                smallVersion.DisplayedPictureIndex += 1;
            }

            return smallVersion;
        }

        public AdvertViewModel BuildPreviousPicture()
        {
            var smallVersion = BuildSmallVersion();
            smallVersion.DisplayedPictureIndex = smallVersion.DisplayedPictureIndex > 1 ? smallVersion.DisplayedPictureIndex -1: 0;
            return smallVersion;
        }

        public IEnumerable<ModelMetadata> Decorate(IList<ModelMetadata> modelMetadata)
        {
            new CreateRule<AdvertViewModel>(x => x.LandSurface, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.HouseId).Show();
            new CreateRule<AdvertViewModel>(x => x.FloorNumber, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.HouseId).Hide();

            new CreateRule<AdvertViewModel>(x => x.NumberOfRooms, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.LandId).Hide();
            new CreateRule<AdvertViewModel>(x => x.FloorNumber, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.LandId).Hide();
            new CreateRule<AdvertViewModel>(x => x.NumberOfFloors, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.LandId).Hide();
            new CreateRule<AdvertViewModel>(x => x.CreationYear, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.LandId).Hide();
            new CreateRule<AdvertViewModel>(x => x.BuildingCategory, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.LandId).Hide();
            new CreateRule<AdvertViewModel>(x => x.Material, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.LandId).Hide();
            new CreateRule<AdvertViewModel>(x => x.LandType, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.LandId).Show();

            new CreateRule<AdvertViewModel>(x => x.BuildingCategory, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.ComercialId).Hide();
            new CreateRule<AdvertViewModel>(x => x.Material, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.ComercialId).Hide();
            new CreateRule<AdvertViewModel>(x => x.ComercialType, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.ComercialId).Show();

            new CreateRule<AdvertViewModel>(x => x.NumberOfRooms, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.RoomId).Hide();
            new CreateRule<AdvertViewModel>(x => x.NumberOfFloors, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.RoomId).Hide();
            new CreateRule<AdvertViewModel>(x => x.CreationYear, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.RoomId).Hide();
            new CreateRule<AdvertViewModel>(x => x.Material, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.RoomId).Hide();

            new CreateRule<AdvertViewModel>(x => x.NumberOfRooms, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.GarageId).Hide();
            new CreateRule<AdvertViewModel>(x => x.FloorNumber, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.GarageId).Hide();
            new CreateRule<AdvertViewModel>(x => x.NumberOfFloors, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.GarageId).Hide();
            new CreateRule<AdvertViewModel>(x => x.BuildingCategory, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.GarageId).Hide();
            new CreateRule<AdvertViewModel>(x => x.Material, modelMetadata, this).When(x => x.CategoryId == CategoryProvider.GarageId).Hide();

            return modelMetadata;
        }
    }

    /// <summary>
    /// SimpleDetails action only requires AdvertId, to create Advert
    /// </summary>
    public interface IAdvertIdRequired
    {
        string Id { get; set; }
    }
}