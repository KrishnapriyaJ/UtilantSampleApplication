using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilantWebApplication.ViewModels;

namespace UtilantWebApplication.Interfaces
{
    public interface IPostService
    {
        IList<PostViewModel> GetPostDetailsById(int id);
    }
}
