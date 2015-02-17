// -----------------------------------------------------------------------
// <copyright file="TransactionTypeProvider.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries.Providers
{
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TransactionTypeProvider : IGlossaryProvider<TransactionType>
    {
        public const int BuyId = 1;
        public const int SellId = 2;
        public const int RentId = 3;

        public const int DefaultTransactionTypeId = SellId;

        public IEnumerable<TransactionType> GetValues()
        {
            return transactionTypes;
        }

        // AlternateName is used for Land category type
        private static readonly TransactionType[] transactionTypes = new[]
            {
                new TransactionType { Id = BuyId, Name = "Kupno", ShowAsSearchCriteria = false, OldDomiportaSearchQueryName = "kupie" },
                new TransactionType { Id = SellId, Name = "Sprzedaż", ShowAsSearchCriteria = true, AlternativeName = "Sprzedaż", OldDomiportaSearchQueryName = "sprzedam" },
                new TransactionType { Id = RentId, Name = "Wynajem", ShowAsSearchCriteria = true, AlternativeName = "Dzierżawa", OldDomiportaSearchQueryName = "wynajme"},
            };

        public static IEnumerable<TransactionType> TransactionTypes
        {
            get { return transactionTypes; }
        }
    }
}
