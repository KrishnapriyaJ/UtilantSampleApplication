using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilantWebApplication.Interfaces;
using UtilantWebApplication.Services;
using UtilantWebApplication.ViewModels;


namespace UtilantWebApplication.Repository
{
    public class AlbumRepository
    {
        private IAlbumService albumService;
        
        public AlbumRepository()
        {
            albumService = new AlbumService();
        }

        /// <summary>
        /// Get album details from API
        /// </summary>
        /// <returns></returns>
        public IList<AlbumViewModel> GetAlbumDetails()
        {
            IList<AlbumViewModel> albumList = albumService.GetAlbumDetails();
            return albumList;
        }
    }
}