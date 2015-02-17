namespace Trader.Web.Validators
{
    using System;
    using System.Linq;

    using FluentValidation;

    using Trader.Model.Glossaries;
    using Trader.Model.Glossaries.Providers;
    using Trader.Web.Models.Search;

    public class SearchViewModelValidator : AbstractValidator<SearchViewModel>
    {
        public const string IncorrectForm = "Formularz zawiera nieprawidłowe dane.";

        public SearchViewModelValidator()
        {
            this.RuleFor(x => x.Price)
                .Must(CommonValidatorHelper.IsValidRangeCriteria).WithMessage(IncorrectForm)
                .Must(CommonValidatorHelper.IsNonNegative).WithMessage(IncorrectForm);
            this.RuleFor(x => x.Surface)
                .Must(CommonValidatorHelper.IsValidRangeCriteria).WithMessage(IncorrectForm)
                .Must(CommonValidatorHelper.IsNonNegative).WithMessage(IncorrectForm);
            this.RuleFor(x => x.NumberOfRooms)
                .Must(CommonValidatorHelper.IsValidRangeCriteria).WithMessage(IncorrectForm)
                .Must(CommonValidatorHelper.IsNonNegative).WithMessage(IncorrectForm);

            this.RuleFor(x => x.City)
                .Must(CommonValidatorHelper.IsValidStringInput)
                .WithMessage(IncorrectForm)
                .Must(CommonValidatorHelper.IsNotStartWithMinus)
                .WithMessage(IncorrectForm);

            this.RuleFor(x => x.District)
                .Must(CommonValidatorHelper.IsValidStringInput)
                .WithMessage(IncorrectForm)
                .Must(CommonValidatorHelper.IsNotStartWithMinus)
                .WithMessage(IncorrectForm);

            this.RuleFor(x => x.CategoryId).Must(IsInAnyCategory).WithMessage(IncorrectForm);
            this.RuleFor(x => x.TransactionTypeId).Must(x => IsInGlossary<TransactionType>(x)).WithMessage(IncorrectForm);
        }

        private static bool IsInAnyCategory(int categoryId)
        {
            return CategoryProvider.GetAllCategoryIds.Any(x => x == categoryId);
        }

        private static bool IsInGlossary<T>(int? element) where T: IGlossary<T>
        {
            if (!element.HasValue) return true;

            var provider = (T)Activator.CreateInstance(typeof(T));
            return provider.GetValues().Any(x => x.Id == element);
        }
    }
}