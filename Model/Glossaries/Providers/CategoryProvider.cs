namespace Trader.Model.Glossaries.Providers
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Returns categories
    /// </summary>
    public class CategoryProvider : IGlossaryProvider<Category>
    {
        public const int GarageId = 1907;
        public const int RoomId = 1906;
        public const int ComercialId = 199; // Acctually 199 is a category for Comercial Market, and we want to keep it the way it is set now
        public const int LandId = 193;
        public const int HouseId = 192;
        public const int FlatId = 191;

        public const int DefaultCategoryId = FlatId;

        public static readonly IEnumerable<int> Garages = new List<int> { 1907 };
        public static readonly IEnumerable<int> Rooms = new List<int> { 1906 };
        public static readonly IEnumerable<int> Comercials = new List<int> { 199, 197, 196 };
        public static readonly IEnumerable<int> Lands = new List<int> { 193, 30812, 30813, 30814, 30815, 30816, 30817, 30818, 30819, 30820, 30821, 31583 };
        public static readonly IEnumerable<int> Houses = new List<int> { 192, 30802, 30803, 30804, 30805, 30806, 30807, 30808, 30809, 30810, 30811 };
        public static readonly IEnumerable<int> Flats = new List<int> { 191, 30796, 30797, 30798, 30799, 30800, 30801 };

        public static IEnumerable<int> GetAllCategoryIds
        {
            get
            {
                return Garages.Concat(Rooms).Concat(Comercials).Concat(Lands).Concat(Houses).Concat(Flats);
            }
        }

        private static readonly IEnumerable<Category> categories = new List<Category>
            {
                new Category { Id = FlatId, Name = "Mieszkania", AlternateName = "mieszkań", CategoryIds = Flats },
                new Category { Id = HouseId, Name = "Domy", AlternateName = "domów", CategoryIds = Houses },
                new Category { Id = LandId, Name = "Działki", CategoryIds = Lands },
                new Category { Id = ComercialId, Name = "Lokale użytkowe", CategoryIds = Comercials },
                new Category { Id = RoomId, Name = "Pokoje", CategoryIds = Rooms },
                new Category { Id = GarageId, Name = "Garaże", CategoryIds = Garages },
            };

        public static IEnumerable<Category> Categories
        {
            get { return categories; }
        }

        public IEnumerable<Category> GetValues()
        {
            return categories;
        }

        /// <summary>
        /// New RP Domiporta, has some wierd categories, with different ids then old domiporta
        /// </summary>
        /// <returns>Categories from Domiporta RP</returns>
        public static IEnumerable<CategoryRP> GetCategoriesFromNewRP()
        {
            yield return new CategoryRP { Id = -1, Name = "Nieruchomości", MobileCategoryId = FlatId };
            yield return new CategoryRP { Id = 50002, Name = "Mieszkania", MobileCategoryId = FlatId };
            yield return new CategoryRP { Id = 50011, Name = "Apartamenty", MobileCategoryId = FlatId };
            yield return new CategoryRP { Id = 50012, Name = "Lofty", MobileCategoryId = FlatId };
            yield return new CategoryRP { Id = 50001, Name = "Domy", MobileCategoryId = HouseId };
        }
    }
}
