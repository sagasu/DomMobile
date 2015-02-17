using System.Linq;

namespace Trader.Web.Validators
{
    using FluentValidation;

    using Trader.Web.Models.Advert;

    public class AdvertViewModelValidator : AbstractValidator<AdvertViewModel>
    {
        public AdvertViewModelValidator()
        {
            this.RuleFor(x => x.DisplayedPictureIndex).Must((x,y) => InRangeOfPicturesCollection(x));
            this.RuleFor(x => x.Id).Must((x, y) => IdSetIfNotInvestment(x));
            this.RuleFor(x => x.Id).Must((x, y) => InvestmentIdSetIfInvestment(x));
        }

        private bool IdSetIfNotInvestment(AdvertViewModel viewModel)
        {
            if (viewModel.IsInvestment) return true;

            return !string.IsNullOrEmpty(viewModel.Id);
        }

        private bool InvestmentIdSetIfInvestment(AdvertViewModel viewModel)
        {
            if(viewModel.IsInvestment)
            {
                return !string.IsNullOrEmpty(viewModel.InvestmentId);
            }

            return true;
        }

        private bool InRangeOfPicturesCollection(AdvertViewModel viewModel)
        {
            if (viewModel.Pictures == null) return true;

            return (viewModel.Pictures.Count() > viewModel.DisplayedPictureIndex + 1) && (viewModel.DisplayedPictureIndex >= 0);
        }
    }
}