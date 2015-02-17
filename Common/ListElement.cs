// -----------------------------------------------------------------------
// <copyright file="ListElement.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Common
{
    /// <summary>
    /// A list Element
    /// Do not add members to this class, it is by design so simple - use a decorator pattern to add some functionality!
    /// </summary>
    public class ListElement
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        /// <summary>
        /// an element for a list asking a user to 'select' some walue, sometimes we want to show it other time we don't
        /// </summary>
        /// <returns></returns>
        public static ListElement GetSelectAnyElement(string labelText = null)
        {
            if (string.IsNullOrEmpty(labelText))
            {
                return new ListElement { Id = 0, Name = "Wybierz", };
            }

            return new ListElement { Id = 0, Name = labelText };
        }
    }
}
