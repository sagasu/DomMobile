// -----------------------------------------------------------------------
// <copyright file="ISolrOrderByFields.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Solr
{
    using System;

    /// <summary>
    /// Iterface to strongly type sort fields that are in SOLR system, but are used in app
    /// </summary>
    public interface ISolrOrderByFields
    {
        DateTime InsertionDate { get; set; }

        decimal? SqMetPrice { get; set; }

        decimal? LocalPrice { get; set; }

        int? SqMetAreal { get; set; }
    }
}
