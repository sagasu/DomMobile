// -----------------------------------------------------------------------
// <copyright file="EncodeTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Web.Tests
{
    using System.Web;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class EncodeTest
    {
        [Fact]
        public void EncodeUrl()
        {
            Assert.Equal(HttpUtility.UrlEncode("/DPRP/17355"), "%2fDPRP%2f17355");

            // One can't encode twice
            Assert.NotEqual(HttpUtility.UrlEncode("%2fDPRP%2f17355"), "%2fDPRP%2f17355");
        }
    }
}
