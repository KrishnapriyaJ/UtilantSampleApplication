using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilantWebApplication.Interfaces;
using UtilantWebApplication.Repository;
using UtilantWebApplication.Services;
using UtilantWebApplication.Utilities;
using UtilantWebApplication.ViewModels;

namespace UtilantWebApplication.Controllers
{
    public class ThumbNailController : Controller
    {
        private PhotoRepository photoRepo;

        public ThumbNailController()
        {
            photoRepo = new PhotoRepository();
        }

        /// <summary>
        /// Get all thumbnails when title is clicked
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public ActionResult Index(int albumId)
        {
            try
            {
                IList<PhotoViewModel> photoModel = photoRepo.GetThumbNailDetailsByAlbumId(albumId);
                return View(photoModel);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLogging(ex);
                return View("Error", new HandleErrorInfo(ex, "ThumbNail", "Index"));
            }
        }
    }
}