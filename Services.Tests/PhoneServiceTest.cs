// -----------------------------------------------------------------------
// <copyright file="PhoneServiceTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services.Tests
{
    using Ninject;

    using Trader.TestsBase;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PhoneServiceTest : TestBase
    {
        [Fact]
        public void GetNumber_Succes()
        {
            var phoneService = Kernel.Get<IPhoneService>();

            Assert.Equal(phoneService.GetNumber("(61) 846-40-69"), "+48618464069");
            Assert.Equal(phoneService.GetNumber("(61) 846-40-60"), "+48618464060");
            Assert.Equal(phoneService.GetNumber("(58) 340-03-81, (58) 340-03-82"), "+48583400381");
            Assert.Equal(phoneService.GetNumber(string.Empty), string.Empty);
            Assert.Equal(phoneService.GetNumber(null), null);
        }
    }
}
