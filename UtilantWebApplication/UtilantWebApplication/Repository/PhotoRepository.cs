using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilantWebApplication.Interfaces;
using UtilantWebApplication.Services;
using UtilantWebApplication.ViewModels;

namespace UtilantWebApplication.Repository
{
    public class PhotoRepository
    {
        private IPhotoService photoService;

        public PhotoRepository()
        {
            photoService = new PhotoService();
        }

        /// <summary>
        /// Get all photo details from API
        /// </summary>
        /// <returns></returns>
        public IList<PhotoViewModel> GetPhotoDetails()
        {
            IList<PhotoViewModel> photoList = photoService.GetPhotoDetails();
            return photoList;
        }

        /// <summary>
        /// Get thumb nails of corresponding album from API
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public IList<PhotoViewModel> GetThumbNailDetailsByAlbumId(int albumId)
        {
            IList<PhotoViewModel> thumbNails = photoService.GetThumbNailDetailsByAlbumId(albumId);
            return thumbNails;
        }
    }
}