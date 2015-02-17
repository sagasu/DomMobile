// -----------------------------------------------------------------------
// <copyright file="ConfigurationPocoTemplateCodeTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;

    using Xunit;

    /// <summary>
    /// Test code inside a template
    /// </summary>
    public class ConfigurationPocoTemplateCodeTest
    {
        [Fact]
        public void TestCode_Success()
        {
            var names = GetNames();
            foreach (var name in names)
            {
                Assert.False(string.IsNullOrEmpty(name));
                Console.WriteLine(name);
            }

            Assert.NotEmpty(names);
        }

        /// <summary>
        /// Testing is ugly, because tempates are run in a specific AppDomain, due to that there is a problem to show a web.config location
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetNames()
        {
            var doc = new XmlDocument();

            // This is configuration for tests, and for tests run by cruise control
            var absolutePath = Directory.GetCurrentDirectory().Replace("\\Services.Tests\\bin\\Debug", "\\Web\\Web.config").Replace("\\Services.Tests\\Build\\Frontend\\bin", "\\Web\\Web.config").Replace("\\Services.Tests\\bin\\Release", "\\Web\\Web.config");

            // This is configuration for template
            //string absolutePath = Host.ResolvePath("../../Web/Web.config");

            doc.Load(absolutePath);

            return (from XmlNode node in doc.SelectNodes("/configuration/appSettings/add")
                    select node.Attributes["key"].InnerText.Replace(":", string.Empty)).ToList();
        }
    }
}
