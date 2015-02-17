// -----------------------------------------------------------------------
// <copyright file="TransactionType.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries
{
    using System;
    using System.Collections.Generic;

    using Trader.Model.Glossaries.Providers;

    public class TransactionType : AbstractGlossary<TransactionType>, IKeptInCodeGlossary<TransactionType>
    {
        /// <summary>
        /// Show as an option
        /// </summary>
        public bool ShowAsSearchCriteria { get; set; }

        public string AlternativeName { get; set; }

        public string OldDomiportaSearchQueryName { get; set; }

        public override IEnumerable<TransactionType> GetValues()
        {
            return new TransactionTypeProvider().GetValues();
        }
    }
}
