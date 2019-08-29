using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using UtilantWebApplication.Interfaces;
using UtilantWebApplication.ViewModels;

namespace UtilantWebApplication.Services
{
    public class PostService:IPostService
    {
        /// <summary>
        /// Get post details of a particular user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<PostViewModel> GetPostDetailsById(int id)
        {
            IList<PostViewModel> postList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                var responseTask = client.GetAsync("posts");
                responseTask.Wait();
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PostViewModel>>();
                    readTask.Wait();
                    postList = readTask.Result;
                    postList = postList.Where(i => i.UserId == id).OrderBy(i => i.Id).ToList();
                }
                else
                {
                    postList.Clear();
                }

                return postList;
            }
        }
    }
}