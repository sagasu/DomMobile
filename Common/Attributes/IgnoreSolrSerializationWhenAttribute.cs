// -----------------------------------------------------------------------
// <copyright file="IgnoreSolrSerializationWhenAttribute.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Common.Attributes
{
    using System;

    /// <summary>
    /// When property has a value equal to valueToIgnor this property will not be serialized to a SOLR query
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IgnoreSolrSerializationWhenAttribute : Attribute
    {
        /// <summary>
        /// When ValueToIgnore is null then decorated parameter is always ignored
        /// </summary>
        public string ValueToIgnore { get; set; }

        public IgnoreSolrSerializationWhenAttribute(){}

        public IgnoreSolrSerializationWhenAttribute(string valueToIgnore)
        {
            ValueToIgnore = valueToIgnore;
        }
    }
}
