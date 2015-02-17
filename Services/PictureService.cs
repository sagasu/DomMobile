// -----------------------------------------------------------------------
// <copyright file="PictureService.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services
{
    public interface IPictureService
    {
        /// <summary>
        /// Builds an url for a picture, based on a picture info kept in a db/solr.
        /// </summary>
        /// <param name="picture">
        /// Picture location as is kept in AllAds.
        /// </param>
        /// <param name="pictureSize">
        /// The picture Size.
        /// </param>
        /// <returns>
        /// Null if picture was not provided.
        /// </returns>
        string BuildPicturePath(string picture, PictureService.PictureSize pictureSize);
    }

    /// <summary>
    /// Service to manage everything for a picture.
    /// </summary>
    public class PictureService : IPictureService
    {
        private readonly IConfigurationService _configurationService;

        public PictureService(IConfigurationService configurationService)
        {
            this._configurationService = configurationService;
        }

        /// <summary>
        /// Builds an url for a picture, based on a picture info kept in a db/solr.
        /// </summary>
        /// <param name="picture">
        /// Picture location as is kept in AllAds.
        /// </param>
        /// <param name="pictureSize">
        /// The picture Size.
        /// </param>
        /// <returns>
        /// Null if picture was not provided.
        /// </returns>
        public string BuildPicturePath(string picture, PictureSize pictureSize)
        {
            if (string.IsNullOrEmpty(picture))
            {
                return null;
            }

            string pathSizeModificator = string.Empty;

            if (pictureSize == PictureSize.Min)
            {
                pathSizeModificator = _configurationService.GetConfiguration(x => x.PictureMin);
            }

            if (pictureSize == PictureSize.Medium)
            {
                pathSizeModificator = _configurationService.GetConfiguration(x => x.PictureMiedium);
            }

            if (pictureSize == PictureSize.Max)
            {
                pathSizeModificator = _configurationService.GetConfiguration(x => x.PictureMax);
            }

            return this._configurationService.GetConfiguration(x => x.PictureServerUrl) + pathSizeModificator + picture;
        }

        public enum PictureSize
        {
            Min,
            Medium,
            Max
        }
    }
}
