// -----------------------------------------------------------------------
// <copyright file="SearchOptions.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model
{
    using System.ComponentModel.DataAnnotations;

    using Trader.Common;
    using Trader.Common.Attributes;
    using Trader.Model.Glossaries;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SearchOptions
    {
        public const int DetailsNumberOfRows = 5;
        public const int InvestmentNumerOfRows = 5;

        private const int _DefaultNumerOfRows = 10;

        public SearchOptions()
        {
            PaginationStart = 0;
            PaginationNumerOfRows = _DefaultNumerOfRows;
            this.OrderBy = ListElementsBuilder.BuildWitProvider<MobileSearchCriteria>();
        }

        public int PaginationStart { get; set; }

        public int PaginationNumerOfRows { get; set; }

        /// <summary>
        /// Sort by one of the elements from MobileSearchCriteriaProvider, set SelectedId to enable search by that field
        /// </summary>
        [UIHint("GlossaryBase")]
        [HtmlProperties(FieldCss = "")]
        [GlossaryBase(ShowChooseOption = false)]
        [Display(Name = "Sortuj po:")]
        public ListElements OrderBy { get; set; }

        public SearchOptions ShallowCloneWoOrder()
        {
            var clone = (SearchOptions)this.MemberwiseClone();
            clone.OrderBy = null;
            return clone;
        }

        public SearchOptions ShallowCloneWoMobileSearchCriteria()
        {
            var clone = (SearchOptions)this.MemberwiseClone();
            if (OrderBy != null)
            {
                clone.OrderBy.SelectedId = this.OrderBy.SelectedId;
            }
            return clone;
        }

        public SearchOptions NextPaginationBuilder()
        {
            var clone = (SearchOptions)this.MemberwiseClone();
            clone.PaginationStart += PaginationNumerOfRows;
            return clone;
        }

        public SearchOptions PreviousPaginationBuilder()
        {
            var clone = (SearchOptions)this.MemberwiseClone();
            if(PaginationStart - PaginationNumerOfRows < 0)
            {
                clone.PaginationStart = 0;
            }else
            {
                clone.PaginationStart -= PaginationNumerOfRows;
            }

            return clone;
        }
    }
}
