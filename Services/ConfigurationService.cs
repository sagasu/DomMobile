// -----------------------------------------------------------------------
// <copyright file="ConfigurationService.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services
{
    using System;
    using System.Configuration;
    using System.Linq.Expressions;

    using Trader.Common;
    using Trader.Services.Helpers;

    public interface IConfigurationService
    {
        string GetConfiguration(Expression<Func<ConfigurationPoco, string>> configurationPropertyName);
    }

    /// <summary>
    /// Reads data from a web.config and serves it
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        public string GetConfiguration(Expression<Func<ConfigurationPoco, string>> configurationPropertyName)
        {
            return ConfigurationManager.AppSettings[ReflectionHelper.GetMember(configurationPropertyName).Name];
        }
    }
}
