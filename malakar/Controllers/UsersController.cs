using malakar.Data;
using malakar.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace malakar.Controllers
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        public UsersController()
        {
        }
        public UsersController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
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

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Boolean> Create(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = new ApplicationUser() { UserName = user.Email.ToLower(), Email = user.Email};
                IdentityResult usrResult = await UserManager.CreateAsync(applicationUser, user.Password);

                if (usrResult.Succeeded)
                {
                    await db.SaveChangesAsync();
                }
                return false;
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
