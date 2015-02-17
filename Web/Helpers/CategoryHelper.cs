using System.Linq;

namespace Trader.Web.Helpers
{
    using Trader.Model.Glossaries.Providers;

    public static class CategoryHelper
    {
        /// <summary>
        /// System works in a context of base categories, that have subcategories, this method maps sub category to base category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static int MapToBaseCategory(int categoryId)
        {
            foreach (var categoryIds in CategoryProvider.Categories.Where(category => category.CategoryIds.Any(id => id == categoryId)))
            {
                return categoryIds.Id;
            }

            return categoryId;
        }
    }
}