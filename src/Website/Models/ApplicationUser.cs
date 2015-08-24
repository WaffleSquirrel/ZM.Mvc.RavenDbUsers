using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Identity.RavenDB.Entities;
using Microsoft.AspNet.Identity;

namespace ZM.Mvc.RavenDbUsers.Models
{
    public class ApplicationUser : RavenUser
    {
        #region Methods

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, string> userManager)
        {
            // note the AuthenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType 
            // (see App_Start/Startup.Auth.cs)
            var newUserIdentity = await userManager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            //
            // add custom user claims here
            //

            return newUserIdentity;
        }

        #endregion

        #region Constructor(s)

        public ApplicationUser(string emailAddress) : base(userName: emailAddress, email: emailAddress)
        {
        }

        #endregion
    }
}