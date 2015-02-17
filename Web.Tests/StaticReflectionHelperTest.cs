// -----------------------------------------------------------------------
// <copyright file="StaticReflectionHelperTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Trader.Common.Attributes;
    using Trader.Model.Solr;
    using Trader.Web.Helpers;
    using Trader.Web.Models.Advert;

    using Xunit;

    public class StaticReflectionHelperTest
    {
        [Fact]
        public void Scan()
        {
            var propertiesWithStaticReflectionAttribute =
                (from assembly in
                     new[]
                         {
                             Assembly.GetAssembly(typeof(AdvertViewModel)),
                             Assembly.GetAssembly(typeof(SearchResultViewModel))
                         }
                 from type in assembly.GetTypes()
                 from property in type.GetProperties()
                 where property.GetCustomAttributes(typeof(StaticReflectionAttribute), true).Any()
                                                           select new StaticReflectionElement{TypeName = type.Name, PropertyName = property.Name}).ToList();

            var dictionary = new Dictionary<string,List<string>>();
            foreach (var staticReflectionElement in propertiesWithStaticReflectionAttribute)
            {
                if (dictionary.ContainsKey(staticReflectionElement.TypeName))
                {
                    dictionary[staticReflectionElement.TypeName].Add(staticReflectionElement.PropertyName);
                }
                else
                {
                    dictionary[staticReflectionElement.TypeName] = new List<string>
                        {
                            staticReflectionElement.PropertyName 
                        };
                }
            }

            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine(string.Concat("klucz: ", key));
                foreach (var propertyName in dictionary[key])
                {
                    Console.WriteLine("   " + propertyName);
                }
            }
        }
    }
}
