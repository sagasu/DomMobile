// -----------------------------------------------------------------------
// <copyright file="PictureServiceTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services.Tests
{
    using Ninject;

    using Trader.TestsBase;

    using Xunit;

    public class PictureServiceTest : TestBase
    {
        private const string PictureUrl = "picUrl";

        [Fact]
        public void PictureService_CheckPictureUrlGeneration_Success()
        {
            var pictureService = Kernel.Get<IPictureService>();
            
            Assert.Equal("http://dev.pictures.trader.pl/pictures/search-results/" + PictureUrl, pictureService.BuildPicturePath(PictureUrl, PictureService.PictureSize.Min));
        }
    }
}
