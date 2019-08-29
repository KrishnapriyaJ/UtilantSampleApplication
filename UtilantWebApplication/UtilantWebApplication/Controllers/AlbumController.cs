using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilantWebApplication.ViewModels;
using UtilantWebApplication.Services;
using PagedList;
using UtilantWebApplication.Repository;
using UtilantWebApplication.Utilities;

namespace UtilantWebApplication.Controllers
{
    public class AlbumController : Controller
    {
        private UserAlbumRepository userAlbumRepo;

        public AlbumController()
        {
            userAlbumRepo = new UserAlbumRepository();
        }

        /// <summary>
        /// Get the details to be displayed in the grid with search function and pagination
        /// </summary>
        /// <param name="page"></param>
        /// <param name="searchData"></param>
        /// <returns></returns>
        public ActionResult Index(int? page, string searchData)
        {
            try
            {
                IList<AlbumViewModel> albumModel = new List<AlbumViewModel>();
                IPagedList<AlbumViewModel> pagedAlbumList = null;
                int pageSize = 4;
                int pageIndex = 1;
                pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

                albumModel = userAlbumRepo.GetAllDetails().ToList();

                if (!String.IsNullOrEmpty(searchData))
                {
                    albumModel = albumModel.Where(s => s.UserName.ToLower().Contains(searchData.ToLower())
                                || s.Title.ToLower().Contains(searchData.ToLower())).ToList();
                }

                pagedAlbumList = albumModel.ToPagedList(pageIndex, pageSize);

                return View(pagedAlbumList);
            }
            catch(Exception ex)
            {
                ErrorLog.ErrorLogging(ex);
                return View("Error", new HandleErrorInfo(ex, "Album", "Index"));
            }
        }
    }
}