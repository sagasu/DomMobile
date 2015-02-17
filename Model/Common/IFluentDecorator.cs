// -----------------------------------------------------------------------
// <copyright file="IFluentDecorator.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Common
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IFluentDecorator
    {
        IEnumerable<ModelMetadata> Decorate(IList<ModelMetadata> modelMetadata);
    }
}
