// -----------------------------------------------------------------------
// <copyright file="DictionaryExtensions.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Solr
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using SolrNet;
    using SolrNet.DSL;

    using Trader.Common;
    using Trader.Common.Attributes;
    using Trader.Model.Solr;

    /// <summary>
    /// One and only place to create a solr query based on an object
    /// Iterates over all properties from an passed @object property
    /// And for each property, if it has a miningfull value create a query
    /// There are two methods to extend this class - via ISolrMap and IgnoreSolrSerializationWhenAttribute
    /// In other words, if you don't want to use a generic serialization, use those extensions to serialize to SOLR query on your own.
    /// </summary>
    public static class SolrQueryExtension
    {
        /// <summary>
        /// Serialize an object to a SOLR query.
        /// </summary>
        /// <param name="object">An Object to be serialized.</param>
        /// <returns>MultipleSolrQuery - a list of solr queries.</returns>
        public static IEnumerable<ISolrQuery> ToSolrQueries(this object @object)
        {
            if (@object == null)
            {
                return Enumerable.Empty<SolrQueryByField>();
            }

            var properties = TypeDescriptor.GetProperties(@object);

            var multipleSolrQuery = new List<ISolrQuery>(properties.Count);

            foreach (PropertyDescriptor descriptor in properties)
            {
                var key = descriptor.Name;
                var value = descriptor.GetValue(@object);

                if (value == null)
                {
                    continue;
                }

                var solrSerializationattribute = descriptor.Attributes[typeof(IgnoreSolrSerializationWhenAttribute)];

                if (descriptor.PropertyType.Name == typeof(DateTime).Name)
                {
                    if (value.ToString() != DateTime.MinValue.ToString())
                    {
                        // It has to be query simple (NOT a query.form) otherwise grouping will not work
                        multipleSolrQuery.Add(Query.Simple(string.Format("{0}:{1}", key, value)));
                    }
                }
                else if (typeof(ISolrMap).IsAssignableFrom(descriptor.PropertyType))
                {
                    var solrMap = (ISolrMap)value;
                    var map = solrMap.Map(key);

                    if (!string.IsNullOrEmpty(map))
                    {
                        multipleSolrQuery.Add(Query.Simple(map));
                    }
                }
                else if ((solrSerializationattribute != null) && 
                    (((IgnoreSolrSerializationWhenAttribute)solrSerializationattribute)
                          .ValueToIgnore.Equals(value.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
                    (((IgnoreSolrSerializationWhenAttribute)solrSerializationattribute)
                          .ValueToIgnore == null)))
                {
                    continue;
                }
                else
                {
                    value = CorrectionHelper.Correct(value.ToString());
                    multipleSolrQuery.Add(Query.Simple(string.Format("{0}:{1}", key, value)));
                }
            }

            return multipleSolrQuery;
        }
    }
}
