namespace Trader.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// A common interface for a GlossaryBase view template
    /// </summary>
    public interface IListElements
    {
        /// <summary>
        /// Gets or Sets a selected value
        /// </summary>
        int SelectedId { get; set; }

        IList<ListElement> ListOfListElement { get; set; }
    }

    /// <summary>
    /// Implementation of a GlossaryBase interface class
    /// Do not add members to this class, it is by design so simple - use a decorator pattern to add some functionality!
    /// </summary>
    public class ListElements : IListElements
    {
        public int SelectedId { get; set; }

        public IList<ListElement> ListOfListElement { get; set; }
    }
}
