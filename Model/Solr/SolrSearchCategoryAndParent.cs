// -----------------------------------------------------------------------
// <copyright file="SolrSearchCategoryAndParent.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Solr
{
    using Trader.Common;

    public class SolrSearchCategoryAndParent : ISolrMap
    {
        private const string Format = "{0}:{1}";

        public int Value { get; set; }

        public SolrSearchCategoryAndParent(int value)
        {
            this.Value = value;
        }

        public string Map(string key)
        {
            return string.Format(Format, "CategoryPath", Value);
        }
    }
}
