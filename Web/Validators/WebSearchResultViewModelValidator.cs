namespace Trader.Web.Validators
{
    using FluentValidation;

    using Trader.Web.Models.Domiporta;

    public class WebSearchResultViewModelValidator : AbstractValidator<WebSearchResultViewModel>
    {
        public WebSearchResultViewModelValidator()
        {
            //this.RuleFor(x => x.CategoryId).NotEmpty();
            //this.RuleFor(x => x.City).NotEmpty();
        }
    }
}