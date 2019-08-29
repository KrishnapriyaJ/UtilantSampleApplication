using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilantWebApplication.ViewModels
{
    public class UserViewModel
    {
        public  UserViewModel()
        {
            Post = new List<PostViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Address address {get;set;}
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }

        public IList<PostViewModel> Post { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
    }

    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }

    public class PostViewModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
