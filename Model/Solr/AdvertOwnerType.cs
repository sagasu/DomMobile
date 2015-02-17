// -----------------------------------------------------------------------
// <copyright file="AdvertOwnerType.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Solr
{
    using Trader.Common;

    public class AdvertOwnerType : ISolrMap
    {
        /// <summary>
        /// Check if an advert belongs to a Private User
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Check if an advert belongs to a Developer
        /// </summary>
        public bool IsDeveloper { get; set; }

        public string Map(string key)
        {
            if (IsPrivate && IsDeveloper) return "IsPrivate:true IsDeveloper:true";

            if (IsPrivate) return "IsPrivate:true";

            return "IsDeveloper:true";
        }
    }
}