using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity;
using malakar.Data.Abstract;
using malakar.Data.Repositories;
using System;

namespace malakar.Helpers
{
    public class UserManager
    {
        private IUserRepository _userRepository;

        public UserManager()
        {
            _userRepository = new UserRepository(new Data.ApplicationDbContext());
        }
        public int GetLoggedInUserID()
        {
            if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //if (HttpContext.Current.Session == null || HttpContext.Current.Session["UserID"] == null)
                //{
                ClaimsIdentity identity = HttpContext.Current.User.Identity as ClaimsIdentity;
                string UserID = identity.FindFirstValue("UserID");
                return Convert.ToInt32(UserID);
                //string UserCode = identity.GetUserId();
                ////string UserName = identity.GetUserName();
                //try
                //{
                //    var user = _userRepository.GetAll().Where(x => x.UserCode == UserCode).FirstOrDefault();
                //    if (user != null)
                //    {
                //        HttpContext.Current.Session["UserID"] = user.ID;
                //        return user.ID;
                //    }
                //}
                //catch { }
                //}
                //else
                //    return Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            }
            return 0;
        }
        public Models.User GetLoggedInUser()
        {
            if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ClaimsIdentity identity = HttpContext.Current.User.Identity as ClaimsIdentity;
                //string UserCode = identity.GetUserId();
                //string UserName = identity.GetUserName();
                string UserID = identity.FindFirstValue("UserID");
                try
                {
                    var user = _userRepository.GetSingle(Convert.ToInt32(UserID));

                    return user;

                }
                catch { }

            }
            return null;
        }
    }
}