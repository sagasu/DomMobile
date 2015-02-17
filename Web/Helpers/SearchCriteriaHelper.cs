namespace Trader.Web.Helpers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    using Trader.Common;
    using Trader.Model.Glossaries;
    using Trader.Model.Glossaries.Providers;
    using Trader.Web.Models.Search;

    public static class SearchCriteriaHelper
    {
        public static string GetSearchCriteriaAsString(SearchViewModel viewModel)
        {
            var sc = new StringBuilder();

            var category = CategoryProvider.Categories.SingleOrDefault(x => x.Id == viewModel.CategoryId);
            var transactionType = TransactionTypeProvider.TransactionTypes.SingleOrDefault(x => x.Id == viewModel.TransactionTypeId);

            var metadataProperties = ModelMetadataProviders.Current.GetMetadataForProperties(viewModel, typeof(SearchViewModel)).ToList();

            var landTypeMetadata = metadataProperties.SingleOrDefault(x => x.PropertyName == StaticReflectionPoco.SearchViewModel.LandType);
            var comercialTypeMetadata = metadataProperties.SingleOrDefault(x => x.PropertyName == StaticReflectionPoco.SearchViewModel.ComercialType);
            var provinceMetadata = metadataProperties.SingleOrDefault(x => x.PropertyName == StaticReflectionPoco.SearchViewModel.Province);

            sc.Append(category.Name).Append(
                transactionType == null
                    ? string.Empty
                    : (category.Id == CategoryProvider.LandId
                           ? " " + transactionType.AlternativeName
                           : " na " + transactionType.Name) + ", ");

            if (provinceMetadata.ShowForDisplay) {
                AppendGlossary<Province>(sc, viewModel.Province.SelectedId);
            }

            if (landTypeMetadata.ShowForDisplay)
            {
                AppendGlossary<LandType>(sc, viewModel.LandType.SelectedId);
            }

            if (comercialTypeMetadata.ShowForDisplay)
            {
                AppendGlossary<ComercialType>(sc, viewModel.ComercialType.SelectedId);
            }

            sc.Append(string.IsNullOrEmpty(viewModel.City) ? string.Empty : viewModel.City + ", ");

            if (viewModel.DistrictSelect.SelectedId != default(int))
            {
                var selectedDistrict = DistrictProvider.Districts.SingleOrDefault(x => x.Id == viewModel.DistrictSelect.SelectedId);
                if(selectedDistrict != null)
                {
                    sc.Append(selectedDistrict.Name);
                }
            }
            else
            {
                sc.Append(string.IsNullOrEmpty(viewModel.District) ? string.Empty : viewModel.District + ", ");
            }

            if (viewModel.Surface != null)
            {
                AppendRangeCriteria(stringBuilder: sc, rangeCriteria: viewModel.Surface, unit: " m2 ");
            }

            if (viewModel.NumberOfRooms != null)
            {
                AppendRangeCriteria(stringBuilder: sc, rangeCriteria: viewModel.NumberOfRooms, unit: " pokoi ");
            }

            if (viewModel.Price != null)
            {
                AppendRangeCriteria(stringBuilder: sc, rangeCriteria: viewModel.Price, unit: " PLN ");
            }

            return sc.ToString();
        }

        private static void AppendGlossary<T>(StringBuilder stringBuilder, int selectedId) where T : IGlossary<T>
        {
            var glossary = ((T)Activator.CreateInstance(typeof(T))).GetValues().SingleOrDefault(x => x.Id == selectedId);

            if (glossary != null)
            {
                stringBuilder.Append(glossary.Name + ", ");
            }
        }

        private static void AppendRangeCriteria(StringBuilder stringBuilder, RangeCriteria rangeCriteria, string unit = "")
        {
            if ((rangeCriteria.From != null) && rangeCriteria.From.SelectedValue.HasValue)
            {
                if ((rangeCriteria.To != null) && rangeCriteria.To.SelectedValue.HasValue)
                {
                    stringBuilder.Append("od " + FormatHelper.FormatInt(rangeCriteria.From.SelectedValue.Value));
                }
                else
                {
                    stringBuilder.Append("od " + FormatHelper.FormatInt(rangeCriteria.From.SelectedValue.Value) + unit);
                }
            }
            if ((rangeCriteria.To != null) && rangeCriteria.To.SelectedValue.HasValue)
            {
                stringBuilder.Append(
                    " do " + FormatHelper.FormatInt(rangeCriteria.To.SelectedValue.Value) + unit);
            }
        }
    }
}