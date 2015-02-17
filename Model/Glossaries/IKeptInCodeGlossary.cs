// -----------------------------------------------------------------------
// <copyright file="IKeptInCodeGlossary.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries
{
    using System.Collections.Generic;

    /// <summary>
    /// Common interface for each glossary kept in a code
    /// </summary>
    public interface IKeptInCodeGlossary<out T>
    {
        IEnumerable<T> GetValues();
    }
}
