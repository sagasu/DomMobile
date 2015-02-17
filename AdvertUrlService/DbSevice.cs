// -----------------------------------------------------------------------
// <copyright file="AdvertUrl.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Trader.AdvertUrlService
{
    using System;
    using System.Linq;

    using Trader.Common;

    public interface IDbService
    {
        string GetAlladsAdvertIdFromDomiportaRPId(int advertId);

        string GetAdvertUrl(int advertId);

        int? GetAlladsAdvertId();
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DbService : IDbService
    {
        private const string ConnectionStringKey = "TraderConn";
        
        public string GetAlladsAdvertIdFromDomiportaRPId(int advertId)
        {
            var url = this.GetAdvertUrl(advertId);

            // url is in format foo_bar_buzz_id.
            var id = url.Split('_').Last();
            int parsedId;

            // This is to check if extracted string is a number, so there is a changece that it is an id.
            if (int.TryParse(id, out parsedId))
            {
                return SolrMapperHelper.MapToDprp(id, encodeUrl:false);
            }

            throw new ArgumentException("Can't parse advert id from url");
        }

        public string GetAdvertUrl(int advertId)
        {
            string connStr = ConfigurationManager.ConnectionStrings[ConnectionStringKey].ConnectionString;
            string advertUrl;

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (var command = new SqlCommand {Connection = conn})
                {
                    command.CommandText = "GetAdvertUrl";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@AdvertId", SqlDbType.Int).Value = advertId;

                    advertUrl = command.ExecuteScalar().ToString();
                }
            }

            return advertUrl;
        }

        public int? GetAlladsAdvertId()
        {
            string connStr = ConfigurationManager.ConnectionStrings[ConnectionStringKey].ConnectionString;
            int?  advertId = null;

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (var command = new SqlCommand { Connection = conn })
                {
                    command.CommandText = "select top 1 id from allads where kontakt is not null and kontakt <> ''";
                    command.CommandType = CommandType.Text;

                    string strAdvertId = command.ExecuteScalar().ToString();

                    int  tmpAdvertId;
                    if(int.TryParse(strAdvertId, out tmpAdvertId))
                    {
                        advertId = tmpAdvertId;
                    }
                }
            }

            return advertId;
        }
    }
}
