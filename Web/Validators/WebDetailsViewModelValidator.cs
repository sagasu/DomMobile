namespace Trader.Web.Validators
{
    using FluentValidation;

    using Trader.Web.Models.Domiporta;

    public class WebDetailsViewModelValidator : AbstractValidator<WebDetailsViewModel>
    {
        public WebDetailsViewModelValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty();
        }
    }
}