namespace Trader.Web.Validators
{
    using FluentValidation;

    using Trader.Web.Models.Advert;

    /// <summary>
    /// This empty validator is needed to trigger validation of sub-objects
    /// </summary>
    public class InvestmentViewModelValidator : AbstractValidator<InvestmentViewModel>
    {
        public InvestmentViewModelValidator()
        {
        }
    }
}