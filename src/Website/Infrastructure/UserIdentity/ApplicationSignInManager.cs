using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ZM.Mvc.RavenDbUsers.Models;

namespace ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity
{
    public sealed class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        #region Overrides

        public override async Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser appUser)
        {
            return await appUser.GenerateUserIdentityAsync(this.UserManager);
        }

        #endregion

        #region Constructor(s)

        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
            if (this.UserManager == null)
            {
                throw new NullReferenceException("The UserManager is null in the ApplicationSignInManager.");
            }
        }

        #endregion
    }
}