namespace Trader.Solr.Tests
{
    using System.Linq;

    using Ninject;

    using Trader.Model;
    using Trader.Model.Solr;
    using Trader.Services;
    using Trader.TestsBase;

    using Xunit;

    public class GroupingQueryTest : TestBase
    {
        [Fact]
        public void Query_WoGrouping_Success()
        {
            var solrService = Kernel.Get<ISolrService>();

            var results = solrService.Search(
                "(CategoryId:191  TransactionType:2)& start=0& rows=10");

            Assert.Equal(results.NumFound , 0);
        }

        [Fact]
        public void GroupingQuery_NothingReturnAsResult_Success()
        {
            var solrService = Kernel.Get<ISolrService>();

            var results = solrService.Search(
                "(CategoryId:191  TransactionType:2)& start=0& rows=10& group=true& group.field=InvestmentGroupField& group.limit=1& group.format=grouped");

            Assert.Equal(results.NumFound, 0); // Everything is in a grouping property not in a result.
        }

        [Fact]
        public void GroupingQuery_Success()
        {
            var solrService = Kernel.Get<ISolrService>();

            var results = solrService.SearchWithGrouping(
                new SolrAdvertDto() { CategoryId = new SolrSearchCategoryAndParent(191) }, new SearchOptions() { PaginationNumerOfRows = 10 });

            Assert.True(results.Matches > 0); // Everything is in a grouping property not in a result.
            Assert.True(results.Groups.Any());
            Assert.True(results.Groups.First().NumFound > 0);
        }

        [Fact]
        public void FailuringTest_Failure()
        {
            Assert.False(false);
        }
    }
}
