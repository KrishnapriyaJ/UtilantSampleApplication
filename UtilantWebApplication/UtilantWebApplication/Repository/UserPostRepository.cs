using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilantWebApplication.ViewModels;

namespace UtilantWebApplication.Repository
{
    public class UserPostRepository
    {
        private UserRepository userRepo;
        private PostRepository postRepo;

        public UserPostRepository()
        {
            userRepo = new UserRepository();
            postRepo = new PostRepository();
        }

        /// <summary>
        /// Get user and post details of particular user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<UserViewModel> GetUserAndPostDetails(int id)
        {
            IList<UserViewModel> userList = userRepo.GetUserDetailById(id);
            IList<PostViewModel> postList = postRepo.GetPostDetailsById(id);

            userList.FirstOrDefault().Post = postList;

            return userList;
        }
    }
}