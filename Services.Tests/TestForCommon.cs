// -----------------------------------------------------------------------
// <copyright file="TestForCommon.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services.Tests
{
    using Trader.Model.Solr;

    using Xunit;

    /// <summary>
    /// This test is created to create a reference to a Trader.Common, and use it, in order to make CC on dev2 find this lib.
    /// </summary>
    public class TestForCommon
    {
        [Fact]
        public void TestForCommon_Success()
        {
            const string Categoryid = "CategoryId";

            Assert.Equal(new SolrSearchCategoryAndParent(131).Map(Categoryid), "CategoryPath:131");
        }
    }
}
