using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilantWebApplication.ViewModels;

namespace UtilantWebApplication.Interfaces
{
    public interface IPhotoService
    {
        IList<PhotoViewModel> GetPhotoDetails();
        IList<PhotoViewModel> GetThumbNailDetailsByAlbumId(int albumId);
    }
}