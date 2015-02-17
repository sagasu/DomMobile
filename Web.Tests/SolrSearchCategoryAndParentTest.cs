// -----------------------------------------------------------------------
// <copyright file="SolrSearchCategoryAndParentTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Trader.Model.Solr;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SolrSearchCategoryAndParentTest
    {
        [Fact]
        public void TestToSolrStringSerialization_Success()
        {
            var solrString = new SolrSearchCategoryAndParent(131).Map("CategoryId");

            Console.WriteLine(solrString);
        }
    }
}
