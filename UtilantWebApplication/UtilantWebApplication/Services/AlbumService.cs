using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UtilantWebApplication.ViewModels;


namespace UtilantWebApplication.Services
{
    public class AlbumService : IAlbumService
    {
        /// <summary>
        /// Get all album details
        /// </summary>
        /// <returns></returns>
        public IList<AlbumViewModel> GetAlbumDetails()
        {
            using (var client = new HttpClient())
            {
                IList<AlbumViewModel> albumList = null;
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                var responseTask = client.GetAsync("albums");
                responseTask.Wait();
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AlbumViewModel>>();
                    readTask.Wait();
                    albumList = readTask.Result;
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