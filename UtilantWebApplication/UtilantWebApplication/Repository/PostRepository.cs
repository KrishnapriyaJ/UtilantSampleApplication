using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilantWebApplication.Interfaces;
using UtilantWebApplication.ViewModels;
using UtilantWebApplication.Services;

namespace UtilantWebApplication.Repository
{
    public class PostRepository
    {

        private IPostService postService;

        public PostRepository()
        {
            postService = new PostService();
        }

        /// <summary>
        /// Get post details of a particular user from API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<PostViewModel> GetPostDetailsById(int id)
        {
            IList<PostViewModel> postList = postService.GetPostDetailsById(id);
            return postList;
        }
    }
}