using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilantWebApplication.Interfaces;
using UtilantWebApplication.ViewModels;
using UtilantWebApplication.Repository;
using UtilantWebApplication.Services;
using UtilantWebApplication.Utilities;

namespace UtilantWebApplication.Controllers
{
    public class UserController : Controller
    {
        private UserPostRepository userPostRepo;

        public UserController()
        {
            userPostRepo = new UserPostRepository();
        }

        /// <summary>
        /// Get user and corresponding post details when user name is clicked
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Index(int id)
        {
            try
            {
                IList<UserViewModel> list = userPostRepo.GetUserAndPostDetails(id);
                return View(list);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLogging(ex);
                return View("Error", new HandleErrorInfo(ex, "User", "Index"));
            }
        }
    }
}