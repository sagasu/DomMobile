namespace Trader.Web.Validators
{
    using FluentValidation;

    using Trader.Web.Models.Domiporta;

    public class GuessMarketViewModelValidator : AbstractValidator<GuessMarketViewModel>
    {
        public GuessMarketViewModelValidator()
        {
            //this.RuleFor(x => x.Rynek).NotEmpty();
        }
    }
}