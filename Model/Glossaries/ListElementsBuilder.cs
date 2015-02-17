// -----------------------------------------------------------------------
// <copyright file="ListElementsBuilder.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries
{
    using System;
    using System.Linq;

    using Trader.Common;

    public static class ListElementsBuilder
    {
        public static ListElements BuildWitProvider<T>(int selectedId = 0) where T : IGlossary<T>
        {
            return new ListElements
                {
                    ListOfListElement = ((T)Activator.CreateInstance(typeof(T)))
                        .GetValues().Select(x => new ListElement { Id = x.Id, Name = x.Name }).ToList(),
                    SelectedId = selectedId
                };
        }
    }
}
