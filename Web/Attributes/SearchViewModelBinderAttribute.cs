namespace Trader.Web.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Trader.Common;
    using Trader.Model.Glossaries.Providers;
    using Trader.Web.Helpers;
    using Trader.Web.Models.Search;

    public class SearchViewModelBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new SearchViewModelBinder();
        }
    }

    /// <summary>
    /// Dfault model binder allowes # in int, tries to mark an error if such a number is binded
    /// </summary>
    public class SearchViewModelBinder : DefaultModelBinder
    {
        private const string CantParseUrl = "Formularz zawiera nieprawidłowe dane.";

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                return TryBindModel(bindingContext, controllerContext);
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError("Global", CantParseUrl);
                return new SearchViewModel();
            }
        }

        /// <summary>
        /// By design default model binder for int alloweds # sign, this binder validates during creation if int is int
        /// As an addition it sets SearchCriteriaAsString - so they are computed only once
        /// </summary>
        /// <param name="bindingContext"></param>
        /// <param name="controllerContext"></param>
        /// <returns></returns>
        private object TryBindModel(ModelBindingContext bindingContext, ControllerContext controllerContext)
        {
            var model = (SearchViewModel)base.BindModel(controllerContext, bindingContext);

            var mappedValues = new List<string>
                {
                    controllerContext.HttpContext.Request.Params.Get(
                        ReflectionHelper.GetExpressionAsString<SearchViewModel>(x => x.Price.From.SelectedValue)),
                    controllerContext.HttpContext.Request.Params.Get(
                        ReflectionHelper.GetExpressionAsString<SearchViewModel>(x => x.Price.To.SelectedValue)),
                    controllerContext.HttpContext.Request.Params.Get(
                        ReflectionHelper.GetExpressionAsString<SearchViewModel>(x => x.Surface.From.SelectedValue)),
                    controllerContext.HttpContext.Request.Params.Get(
                        ReflectionHelper.GetExpressionAsString<SearchViewModel>(x => x.Surface.To.SelectedValue)),
                    controllerContext.HttpContext.Request.Params.Get(
                        ReflectionHelper.GetExpressionAsString<SearchViewModel>(x => x.NumberOfRooms.From.SelectedValue)),
                    controllerContext.HttpContext.Request.Params.Get(
                        ReflectionHelper.GetExpressionAsString<SearchViewModel>(x => x.NumberOfRooms.To.SelectedValue))
                };

            var marketSegment =
                controllerContext.HttpContext.Request.Params.Get(
                    ReflectionHelper.GetExpressionAsString<SearchViewModel>(x => x.MarketSegment.SelectedId));
            if (marketSegment != null && marketSegment.Equals(MarketSegmentProvider.PrimaryMarketId.ToString()))
            {
                // In primary market there are no private adverts, so IsPrivatePerson is set to false;
                model.IsPrivatePerson = false;
            }

            // Default model binder raises wierd error when passed value is not integer
            int mappedInteger;
            if (mappedValues.Where(x => !string.IsNullOrEmpty(x)).Any(x => !int.TryParse(x, out mappedInteger)))
            {
                bindingContext.ModelState.AddModelError("Global", CantParseUrl);
                return model;
            }

            model.CategoryId = CategoryHelper.MapToBaseCategory(model.CategoryId);

            // By default TransactionTypeId for Room is Rent)
            if(model.CategoryId == CategoryProvider.RoomId)
            {
                model.TransactionTypeId = TransactionTypeProvider.RentId;
            }

            model.SearchCriteriaAsString = SearchCriteriaHelper.GetSearchCriteriaAsString(model);

            return model;
        }
    }
}