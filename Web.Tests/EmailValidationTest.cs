// -----------------------------------------------------------------------
// <copyright file="EmailValidationTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Web.Tests
{
    using System.IO;

    using Trader.Web.Validators;

    using Xunit;

    public class EmailValidationTest
    {
        [Fact]
        public void Validate()
        {
            Assert.False(EmailViewModelValidator.NotInBlacklist("I am "));
        }
    }
}
