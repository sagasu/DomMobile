namespace Web.Tests
{
    using Moq;

    using Trader.Model.Glossaries;
    using Trader.Services;
    using Trader.Web.Helpers;

    using Xunit;

    public class AutomapperTest
    {
        [Fact]
        public void MapFromProvider_Success()
        {
            AutoMapperTestContainer auto = GetAutomapper();

            Assert.Equal(
                auto.MapCategory<LandType>(";przemysłowo-handlowa;leśna z prawem budowy;siedliskowa; "),
                "leśna z prawem budowy, przemysłowo-handlowa, siedliskowa");
        }

        private AutoMapperTestContainer GetAutomapper()
        {
            var pictureService = new Mock<IPictureService>();
            var phoneService = new Mock<IPhoneService>();
            var solrService = new Mock<ISolrService>();
            var cityProvider = new Mock<ICityProvider>();

            return new AutoMapperTestContainer(pictureService.Object, phoneService.Object, solrService.Object, cityProvider.Object);
        }

        [Fact]
        public void StringConcatNull_Success()
        {
            Assert.Equal(string.Concat(null, "a"), "a");
        }

        [Fact]
        public void MapCategory_OnePostion_Success()
        {
            var auto = GetAutomapper();

            Assert.Equal(
                auto.MapCategory<ComercialType>("Pawilon handlowy"),
                string.Empty);
        }

        [Fact]
        public void SimpleMapCategory_OnePostion_Success()
        {
            var auto = GetAutomapper();

            Assert.Equal(
                auto.SimpleMapCategory("Pawilon handlowy"), "Pawilon handlowy");
        }
        
        [Fact]
        public void SimpleMapCategory_MultipleSemicoln_Success()
        {
            var auto = GetAutomapper();

            Assert.Equal(
                auto.SimpleMapCategory(";biuro;;usługi;;handel;;gastronomia;;gabinet;;inne;"), "biuro, usługi, handel, gastronomia, gabinet, inne");
        }

        class AutoMapperTestContainer : AutoMapperConfig
        {
            public AutoMapperTestContainer(IPictureService pictureService, IPhoneService phoneService, ISolrService solrService, ICityProvider cityProvider)
                : base(pictureService, phoneService, solrService, cityProvider)
            {
            }

            public new string MapCategory<T>(string category) where T : IKeptInCodeGlossaryWSanitize<T>
            {
                return base.MapCategory<T>(category);
            }

            public new string SimpleMapCategory(string category)
            {
                return base.SimpleMapCategory(category);
            }
        }
    }
}
