namespace Trader.Model.Solr
{
    public interface ISimpleSolrAdvert
    {
        /// <summary>
        ///   Gets or sets Id -  odpowiednik pola Id z allads - id og³oszenia.
        /// </summary>
        string Id { get; set; }

        string SerializedAdvertData { get; set; }

        DomiportaAdvertDetailsData AdvertData { get; }
    }
}