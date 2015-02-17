// -----------------------------------------------------------------------
// <copyright file="MobileSearchCriteriaProvider.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries.Providers
{
    using System.Collections.Generic;

    using Trader.Common;
    using Trader.Model.Solr;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MobileSearchCriteriaProvider : IGlossaryProvider<MobileSearchCriteria>
    {
        public IEnumerable<MobileSearchCriteria> GetValues()
        {
            yield return new MobileSearchCriteria{Id = 1, Name = "Data wprowadzenia", OrderByFieldName = ReflectionHelper.GetProperty<ISolrOrderByFields>(x => x.InsertionDate).Name};
            yield return new MobileSearchCriteria { Id = 2, Name = "Cena", OrderByFieldName = ReflectionHelper.GetProperty<ISolrOrderByFields>(x => x.LocalPrice).Name };
            yield return new MobileSearchCriteria { Id = 3, Name = "Cena za metr", OrderByFieldName = ReflectionHelper.GetProperty<ISolrOrderByFields>(x => x.SqMetPrice).Name };
            yield return new MobileSearchCriteria { Id = 4, Name = "Powierzchnia", OrderByFieldName = ReflectionHelper.GetProperty<ISolrOrderByFields>(x => x.SqMetAreal).Name };
        }
    }
}
