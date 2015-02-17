using System.Collections.Generic;
using System.IO;
using System.Linq;

using SolrNet;

namespace Trader.Solr
{
    using System;

    using Ninject.Extensions.Logging;

    public class LoggingConnection : ISolrConnection
    {
        private readonly ISolrConnection _connection;

        private readonly ILogger _logger;

        public LoggingConnection(ISolrConnection connection, ILogger logger)
        {
            this._connection = connection;
            _logger = logger;
        }

        public string Post(string relativeUrl, string s)
        {
#if(DEBUG)
            _logger.Debug("{0}: POSTing '{1}' to '{2}'", DateTime.Now, s, relativeUrl);
#endif
            return this._connection.Post(relativeUrl, s);
        }

        public string PostStream(string relativeUrl, string contentType, Stream content, IEnumerable<KeyValuePair<string, string>> getParameters)
        {
#if(DEBUG)
            _logger.Debug("{0}: POSTing to '{1}'", DateTime.Now, relativeUrl);
#endif
            return this._connection.PostStream(relativeUrl, contentType, content, getParameters);
        }

        public string Get(string relativeUrl, IEnumerable<KeyValuePair<string, string>> parameters)
        {
#if(DEBUG)
            var stringParams = string.Join("& ", parameters.Select(p => string.Format("{0}={1}", p.Key, p.Value)).ToArray());
            _logger.Debug("{0}: GETting '{1}' from '{2}'", DateTime.Now, stringParams, relativeUrl);
#endif
            return this._connection.Get(relativeUrl, parameters);
        }
    }
}