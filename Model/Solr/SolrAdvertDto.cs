// -----------------------------------------------------------------------
// <copyright file="SolrAdvertDto.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Solr
{
    using Trader.Common;
    using Trader.Common.Attributes;

    /// <summary>
    /// Those properites names (not types :)) needs to be named as in SOLR schema, because they are auto mapped to a SOLR query
    /// </summary>
    public class SolrAdvertDto
    {
        /// <summary>
        /// It is kept as an encoded value, and SOLR expects it to be send as an encoded value
        /// </summary>
        public string Id { get; set; }

        public SolrSearchCategoryAndParent CategoryId { get; set; }

        /// <summary>
        /// SolrSearchCity
        /// </summary>
        public SolrSearchValueWithWildecard City { get; set; }

        /// <summary>
        /// Dzielnica.
        /// SolrSearchDistrict
        /// </summary>
        public SolrSearchValueWithWildecard Quarter { get; set; }

        public int? TransactionType { get; set; }

        /// <summary>
        /// Województwo.
        /// </summary>
        public string Region { get; set; }

        public RangeCriteria LocalPrice { get; set; }

        public RangeCriteria RoomsCount { get; set; }

        public RangeCriteria SqMetAreal { get; set; }

        /// <summary>
        /// Set to null, if not specified
        /// Specifies if a user want to search directly from owners (not from broker)
        /// </summary>
        [IgnoreSolrSerializationWhen("false")]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Unfortunately this field was named in Polish in SOLR schema :(
        /// </summary>
        [IgnoreSolrSerializationWhen("nieustawiony")]
        public MarketEnum Rynek { get; set; }

        public string InvestmentId { get; set; }

        /// <summary>
        /// Unfortunatelly in SOLR schema there is a misteake Cateory instead of Category :)
        /// </summary>
        public string PropertyCateory { get; set; }
    }

    public enum MarketEnum
    {
        nieustawiony,
        pierwotny,
        wtorny,
        komercyjny
    }
}
