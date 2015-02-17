// -----------------------------------------------------------------------
// <copyright file="SimpleSolrAdvert.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Solr
{
    using SolrNet.Attributes;

    using Trader.Model.Solr;

    /// <summary>
    /// This is a subset of SolrService, with only data that is used by this application - 
    /// no need to map entire SolrService if no one uses majority of mapped properties
    /// </summary>
    public class SimpleSolrAdvert : ISimpleSolrAdvert
    {
        /// <summary>
        ///   Gets or sets Id -  odpowiednik pola Id z allads - id ogłoszenia.
        /// </summary>
        [SolrUniqueKey("Id")]
        public virtual string Id { get; set; }

        private string _privSerializedAdvertData;

        [SolrField("SerializedAdvertData")]
        public virtual string SerializedAdvertData
        {
            get
            {
                return this._privSerializedAdvertData;
            }

            set
            {
                this._privSerializedAdvertData = value;
                if (!string.IsNullOrEmpty(this._privSerializedAdvertData))
                {
                    this.PrivAdvertData = DomiportaAdvertDetailsData.Deserialize(this._privSerializedAdvertData);
                }
                else
                {
                    this.PrivAdvertData = null;
                }
            }
        }

        public virtual DomiportaAdvertDetailsData AdvertData
        {
            get
            {
                return this.PrivAdvertData;
            }
        }

        /// <summary>
        /// Investment picture.
        /// </summary>
        [SolrField("Picture")]
        public string Picture { get; set; }

        private DomiportaAdvertDetailsData PrivAdvertData { get; set; }
    }
}
