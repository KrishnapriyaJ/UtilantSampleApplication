using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilantWebApplication.ViewModels;

namespace UtilantWebApplication.Interfaces
{
    public interface IUserService
    {
        IList<UserViewModel> GetUserDetails();
        IList<UserViewModel> GetUserDetailsById(int id);
    }
}