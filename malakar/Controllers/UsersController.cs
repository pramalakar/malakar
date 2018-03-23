using malakar.Data;
using malakar.Models;
using malakar.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace malakar.Controllers
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _AppRoleManager = null;


        public UsersController()
        {
        }
        public UsersController(ApplicationUserManager userManager, ApplicationRoleManager appRoleManager)
        {
            UserManager = userManager;
            AppRoleManager = appRoleManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
            private set
            {
                _AppRoleManager = value;
            }
        }

        [HttpPost]
        [Authorize(Roles = "superadmin, admin")]
        [Route("api/Users/GetAllUsers")]
        public dynamic GetAllUsers()
        {
            var result = UserManager.Users.ToList();
            return result;
        }

        [HttpPost]
        [Route("api/Users/GetLoggedInUser")]
        public dynamic GetLoggedInUser()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return user;
        }

        [HttpPost]
        public async Task<Boolean> Create(RegisterViewModel user)
        {
            if (user.RoleName == null)
            {
                user.RoleName = "user";
            }
            if (ModelState.IsValid)
            {
                var applicationUser = new ApplicationUser() { UserName = user.Email.ToLower(), Email = user.Email};
                IdentityResult usrResult = await UserManager.CreateAsync(applicationUser, user.Password);

                if (usrResult.Succeeded)
                {
                    usrResult = await UserManager.AddToRoleAsync(applicationUser.Id, user.RoleName);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            return false;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
