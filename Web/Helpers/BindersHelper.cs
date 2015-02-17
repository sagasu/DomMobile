using System;
using System.Linq;

namespace Trader.Web.Helpers
{
    using Trader.Model.Glossaries;
    using Trader.Model.Glossaries.Providers;

    public static class BindersHelper
    {
        /// <exception cref="NoElementException">No such element found in a collection</exception>
        public static int GetGlossaryElementIdByName<T>(string glossaryElementName, int defaultId) where T : IGlossary<T>
        {
            if (string.IsNullOrEmpty(glossaryElementName))
            {
                return defaultId;
            }

            var glossaryType = ((T)Activator.CreateInstance(typeof(T)));

            return glossaryType.GetValues().SingleOrDefault(
                    x => x.Name.Equals(glossaryElementName, StringComparison.InvariantCultureIgnoreCase)).Id;
        }

        /// <exception cref="NoElementException">No such element found in a collection</exception>
        public static int GetTransactionTypeIdByName(string transactionName, int defaultId) 
        {
            if (string.IsNullOrEmpty(transactionName))
            {
                return defaultId;
            }

            return TransactionTypeProvider.TransactionTypes.SingleOrDefault(
                    x => x.OldDomiportaSearchQueryName.Equals(transactionName, StringComparison.InvariantCultureIgnoreCase)).Id;
        }
    }
}