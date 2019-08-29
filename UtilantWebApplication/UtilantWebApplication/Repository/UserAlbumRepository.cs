using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilantWebApplication.ViewModels;

namespace UtilantWebApplication.Repository
{
    public class UserAlbumRepository
    {
        private AlbumRepository albumRepo;
        private UserRepository userRepo;
        private PhotoRepository photoRepo;

        public UserAlbumRepository()
        {
            albumRepo = new AlbumRepository();
            userRepo = new UserRepository();
            photoRepo = new PhotoRepository();
        }
        /// <summary>
        /// Get all album,user and photo details
        /// </summary>
        /// <returns></returns>
        public IList<AlbumViewModel> GetAllDetails()
        {
            IList<AlbumViewModel> albumList = albumRepo.GetAlbumDetails();
            IList<UserViewModel> userList = userRepo.GetUserDetails();
            IList<PhotoViewModel> photoList = photoRepo.GetPhotoDetails();

            albumList = (from album in albumList
                         join user in userList on album.UserId equals user.Id
                         join photos in photoList on album.Id equals photos.AlbumId into photo
                         from ph in photo.Take(1)
                         select new AlbumViewModel
                         {
                             Id = album.Id,
                             UserId = user.Id,
                             Title = album.Title,
                             UserName = user.Name,
                             Email = user.Email,
                             Phone = user.Phone,
                             Address = user.address,
                             ThumbNailUrl = ph.ThumbNailUrl
                         }).ToList();

            return albumList;
        }
    }
}