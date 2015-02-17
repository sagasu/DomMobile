// -----------------------------------------------------------------------
// <copyright file="DictionaryExtensions.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public static partial class DictionaryExtensions
    {
        ///<summary>
        /// Convert an object into a dictionary
        ///</summary>
        ///<param name="object">The object</param>
        ///<param name="nullHandler">Handler for null value</param>
        ///<returns></returns>
        public static Dictionary<string, string> ToDictionary(this object @object, Func<string, string> nullHandler = null)
        {
            if (@object == null)
            {
                return new Dictionary<string, string>();
            }

            var properties = TypeDescriptor.GetProperties(@object);

            var hash = new Dictionary<string, string>(properties.Count);

            foreach (PropertyDescriptor descriptor in properties)
            {
                var key = descriptor.Name;
                var value = descriptor.GetValue(@object);

                if (descriptor.PropertyType.Name == typeof(DateTime).Name)
                {
                    if (value != null && value.ToString() != DateTime.MinValue.ToString())
                    {
                        hash.Add(key, value.ToString());
                    }
                    else if (nullHandler != null)
                    {
                        hash.Add(key, nullHandler(key));
                    }
                }
                else
                {

                    if (value != null)
                    {
                        hash.Add(key, value.ToString());
                    }
                    else if (nullHandler != null)
                    {
                        hash.Add(key, nullHandler(key));
                    }
                }
            }

            return hash;
        }
    }
}
