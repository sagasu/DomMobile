// -----------------------------------------------------------------------
// <copyright file="SolrFromAttribute.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Solr.Attributes
{
    using System;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property , AllowMultiple = false, Inherited = true)]
    public class SolrFromAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public SolrFromAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
