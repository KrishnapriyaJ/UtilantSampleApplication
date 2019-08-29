using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilantWebApplication.Interfaces;
using UtilantWebApplication.ViewModels;
using UtilantWebApplication.Services;

namespace UtilantWebApplication.Repository
{
    public class UserRepository
    {
        private IUserService userService;

        public UserRepository()
        {
            userService = new UserService();
        }

        /// <summary>
        /// Get all user details from API
        /// </summary>
        /// <returns></returns>
        public IList<UserViewModel> GetUserDetails()
        {
            IList<UserViewModel> userList = userService.GetUserDetails();
            return userList;
        }

        /// <summary>
        /// Get user detail of a particular user from API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<UserViewModel> GetUserDetailById(int id)
        {
            IList<UserViewModel> userList = userService.GetUserDetailsById(id);
            return userList;
        }


    }
}