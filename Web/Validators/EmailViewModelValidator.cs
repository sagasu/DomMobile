namespace Trader.Web.Validators
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentValidation;

    using Trader.Model.Common;

    public class EmailViewModelValidator : AbstractValidator<EmailViewModel>
    {
        private const string EmailValidationFailed = "Podaj swój adres email.";
        private const string EmailBodyValidationFailed = "Formularz zawiera nieprawidłowe dane.";

        public EmailViewModelValidator()
        {
            this.RuleFor(x => x.SenderEmail)
                .NotNull().WithMessage(EmailValidationFailed)
                .EmailAddress().WithMessage(EmailValidationFailed);
            this.RuleFor(x => x.BodyAsHtml).Must(x => NotInBlacklist(x)).WithMessage(EmailBodyValidationFailed);
        }

        /// <summary>
        /// Unfortunatelly there is no time to connect xml file and read from it.
        /// </summary>
        private static readonly IEnumerable<string> Blacklist = new List<string>
            {
                "BiuroOgloszenWWW@poczta.fm",
                "http://www.wojmacz.com",
                "matthew.freney@gmail.com",
                "I am ",
                "My Name ",
                "Jhonie.little@gmail.com"
            };

        public static bool NotInBlacklist(string emailBody)
        {
            if (string.IsNullOrEmpty(emailBody)) return true;

            return !Blacklist.Any(x => emailBody.ToLower().Contains(x.ToLower()));
        }
    }
}