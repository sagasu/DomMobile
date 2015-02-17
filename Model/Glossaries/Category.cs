// -----------------------------------------------------------------------
// <copyright file="Glossaries.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries
{
    using System.Collections.Generic;

    using Trader.Model.Glossaries.Providers;

    public class Category : AbstractGlossary<Category>, IKeptInCodeGlossary<Category>
    {
        public override IEnumerable<Category> GetValues()
        {
            return new CategoryProvider().GetValues();
        }

        public string AlternateName { get; set; }

        public IEnumerable<int> CategoryIds { get; set; }
    }

    public class CategoryRP : Category
    {
        /// <summary>
        /// represents id of a rp category in mobile version - for mapping urls
        /// </summary>
        public int MobileCategoryId { get; set; }
    }
}
