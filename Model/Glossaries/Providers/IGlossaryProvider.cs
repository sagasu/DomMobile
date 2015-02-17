// -----------------------------------------------------------------------
// <copyright file="IGlossaryProvider.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Generic glossary provider interface
    /// </summary>
    public interface IGlossaryProvider<out T>
    {
        IEnumerable<T> GetValues();
    }
}
