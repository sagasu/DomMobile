namespace Trader.Services.Tests
{
    using Ninject;

    using Trader.TestsBase;

    using Xunit;

    public class ConfigurationServiceTest : TestBase
    {
        [Fact]
        public void ConfigurationService_GetPicturePropertyConfiguration_Success()
        {
            var configurationService = Kernel.Get<IConfigurationService>();
            Assert.Equal("http://dev.pictures.trader.pl/pictures/", configurationService.GetConfiguration(x => x.PictureServerUrl));
        }
    }
}
