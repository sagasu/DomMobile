// -----------------------------------------------------------------------
// <copyright file="SolrSearchValueWithWildecard.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Trader.Common;

namespace Trader.Model.Solr
{
    /// <summary>
    /// The idea is to search SOLR for a value and value*, 
    /// so if somebody enters Warsz, SOLR will also search for Warsz*, and find Warszawa
    /// </summary>
    public abstract class SolrSearchValueWithWildecard : ISolrMap
    {
        public SolrSearchValueWithWildecard(string value)
        {
            Value = value;
        }

        // It must be [w/o wildecard] OR [with wildecard], otherwise special chars like - will not work
        // It means that this way SOLR anwsers for Konstancin-Jeziorna
        protected internal const string Format = @"({0}:""{1}"" OR {0}:""{2}"")";

        protected internal const string FormatWithCorrection = @"({0}:""{1}"" OR {0}:""{2}"" OR {0}:""{3}"" OR {0}:""{4}"")";

        protected internal const string Wildecard = "*";

        public string Value { get; set; }

        public string Map(string key)
        {
            if (string.IsNullOrEmpty(this.Value))
            {
                return null;
            }

            return AdditionalCorrection(key);
        }

        public abstract string AdditionalCorrection(string key);
    }
}
