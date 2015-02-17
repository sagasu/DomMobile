// -----------------------------------------------------------------------
// <copyright file="MvcGetParamsSerializer.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;

    using Trader.Common.Attributes;

    /// <summary>
    /// Serialize complex object to a string that default mvc model binder can deal with
    /// The idea is to create a generic serializer, so there is no need any more to use flat DTO objects or
    /// to add hidden fields for each object in a hidden form to submit it (sometimes there is a need for more then one such a hidden form)
    /// </summary>
    public static class MvcGetParamsSerializer
    {

        public static string Serialize<T>(T t) where T:class
        {
            return ToString(Serialize(t, string.Empty));
        }

        /// <summary>
        /// This serialization is really naive, improve it if you may, 
        /// it checks if its a complex object only by checking against being a value type
        /// Also collections are not handled
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static IDictionary<string, string> Serialize<T>(T t, string prefix) where T : class
        {
            var properties = TypeDescriptor.GetProperties(t);

            var hash = new Dictionary<string, string>(properties.Count);

            foreach (PropertyDescriptor descriptor in properties)
            {
                var key = string.IsNullOrEmpty(prefix)
                              ? descriptor.Name
                              : string.Format("{0}.{1}", prefix, descriptor.Name);

                var value = descriptor.GetValue(t);
                if (value == null)
                {
                    continue;
                }

                var urlSerializationattribute = descriptor.Attributes[typeof(IgnoreUrlSerializationWhenAttribute)];

                if ((urlSerializationattribute != null) &&
                    (
                    (((IgnoreUrlSerializationWhenAttribute)urlSerializationattribute)
                          .ValueToIgnore == null) ||
                    ((IgnoreUrlSerializationWhenAttribute)urlSerializationattribute)
                          .ValueToIgnore.Equals(value.ToString(), StringComparison.InvariantCultureIgnoreCase)
                    ))
                {
                    continue;
                }

                if (descriptor.PropertyType.IsValueType || descriptor.PropertyType.Equals(typeof(string)))
                {
                    
                    if ((value is int && int.Parse(value.ToString()).Equals(default(int))) || value is IListElements || value is DateTime)
                    {
                        // there is no need to serialize default values, that either way are going to be set during object creation
                        // It is also helpful, cause it is easier to set this value via javascript 
                        // (because it is not serialized one can concatenate additional value)
                        continue;
                    }
                    hash.Add(key, value.ToString());
                }
                else
                {
                    // Don't deal with collections.
                    if (!(value is ICollection))
                    {
                        foreach (var innerHash in Serialize(value, key))
                        {
                            hash.Add(innerHash.Key, innerHash.Value);
                        }
                    }
                }
            }
            return hash;
        }

        public static string ToString(IDictionary<string, string> dictionary)
        {
            var result = new StringBuilder();
            foreach (var element in dictionary)
            {
                if (result.Length != 0) result.Append("&");

                result.Append(string.Format("{0}={1}", element.Key, element.Value));
            }
            return result.ToString();
        }
    }
}
