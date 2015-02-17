// -----------------------------------------------------------------------
// <copyright file="SendEmailTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services.Tests
{
    using Ninject;

    using Trader.Model.Common;
    using Trader.TestsBase;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SendEmailTest : TestBase
    {
        [Fact(Skip = "No need to send email each time. Cruise Control will run this test, otherwise.")]
        public void SendEmail_Success()
        {
            var emailService = Kernel.Get<IEmailService>();

            var email = new EmailViewModel
                {
                    BodyAsHtml = "This is a body of <b>email</b>.",
                    DestinationEmail = "mkopij@trader.pl",
                    SenderEmail = "mkopij@trader.pl"
                };

            emailService.SendEmail(email);
        }
    }
}
