// -----------------------------------------------------------------------
// <copyright file="DiacriticServiceTest.cs" company="Agora SA">
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
    public class DiacriticServiceTest : TestBase
    {
        [Fact]
        public void DiacriticService_TestLPolishLetter_Success()
        {
            var diacriticService = Kernel.Get<IDiacriticService>();

            Assert.Equal("lodz", diacriticService.RemoveDiacriticsAndCastToLower("lódź"));
            Assert.Equal("zzlocean", diacriticService.RemoveDiacriticsAndCastToLower("żźłóćęąń"));
        }
    }
}
