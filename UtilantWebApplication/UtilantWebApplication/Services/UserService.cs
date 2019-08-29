using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using UtilantWebApplication.Interfaces;
using UtilantWebApplication.ViewModels;

namespace UtilantWebApplication.Services
{
   public class UserService:IUserService
    {
        private HttpClient client = null;
        public UserService()
        {
            client = new HttpClient();
        }
       
        /// <summary>
        /// Get all user details 
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        public IList<UserViewModel> GetUserDetails()
        {
            IList<UserViewModel> userList = null;
            using (client)
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                var responseTask = client.GetAsync("users");
                responseTask.Wait();
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<UserViewModel>>();
                    readTask.Wait();
                    userList = readTask.Result;
                }
                else
                {
                    userList.Clear();
                }

                return userList;
            }
        }
        /// <summary>
        /// Get user details of a particular user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<UserViewModel> GetUserDetailsById(int id)
        {
            IList<UserViewModel> userList = null;
            using (client)
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                var responseTask = client.GetAsync("users");
                responseTask.Wait();
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<UserViewModel>>();
                    readTask.Wait();
                    userList = readTask.Result;
                    userList = userList.Where(i => i.Id == id).ToList();
                }
                else
                {
                    userList.Clear();
                }

                return userList;
            }
        }
    }
}