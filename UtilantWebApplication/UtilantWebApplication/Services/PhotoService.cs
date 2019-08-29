using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using UtilantWebApplication.Interfaces;
using UtilantWebApplication.ViewModels;

namespace UtilantWebApplication.Services
{
    public class PhotoService : IPhotoService
    {
        private HttpClient client = null;
        public PhotoService()
        {
           client = new HttpClient();
        }

        /// <summary>
        /// Get all photo details
        /// </summary>
        /// <returns></returns>
        public IList<PhotoViewModel> GetPhotoDetails()
        {
            using (client)
            {
                IList<PhotoViewModel> photoList = null;
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                var responseTask = client.GetAsync("photos");
                responseTask.Wait();
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PhotoViewModel>>();
                    readTask.Wait();

                    photoList = readTask.Result;
                }
                else
                {
                    photoList.Clear();
                }
                return photoList;
            }
        }

        /// <summary>
        /// Get all thumbnails of an album
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public IList<PhotoViewModel> GetThumbNailDetailsByAlbumId(int albumId)
        {
            IList<PhotoViewModel> albumList = null;
            using (client)
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                var responseTask = client.GetAsync("photos");
                responseTask.Wait();
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PhotoViewModel>>();
                    readTask.Wait();
                    albumList = readTask.Result;
                    albumList = albumList.Where(i => i.AlbumId == albumId).ToList();
                }
                else
                {
                    albumList.Clear();
                }

                return albumList;
            }
        }
    }
}