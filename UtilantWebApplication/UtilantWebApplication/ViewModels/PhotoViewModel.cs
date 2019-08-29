using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilantWebApplication.ViewModels
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string ThumbNailUrl { get; set; }
        public string Title { get; set; }
    }
}