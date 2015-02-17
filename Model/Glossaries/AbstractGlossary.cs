// -----------------------------------------------------------------------
// <copyright file="AbstractGlossary.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries
{
    using System.Collections.Generic;

    public abstract class AbstractGlossary<T> : IGlossary<T>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public abstract IEnumerable<T> GetValues();
    }

    public interface IGlossary<out T>
    {
        int Id { get; set; }

        string Name { get; set; }

        IEnumerable<T> GetValues();
    }
}
