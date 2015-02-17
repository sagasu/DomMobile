// -----------------------------------------------------------------------
// <copyright file="OrderBy.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries
{
    using System.Collections.Generic;

    using Trader.Model.Glossaries.Providers;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MobileSearchCriteria : AbstractGlossary<MobileSearchCriteria>, IKeptInCodeGlossary<MobileSearchCriteria>
    {
        public string OrderByFieldName { get; set; }

        public override IEnumerable<MobileSearchCriteria> GetValues()
        {
            return new MobileSearchCriteriaProvider().GetValues();
        }
    }
}
