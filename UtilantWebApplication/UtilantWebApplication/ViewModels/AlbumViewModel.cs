using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilantWebApplication.ViewModels
{
    public class AlbumViewModel
    {
        public AlbumViewModel()
        {
            Address = new Address();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string ThumbNailUrl { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}