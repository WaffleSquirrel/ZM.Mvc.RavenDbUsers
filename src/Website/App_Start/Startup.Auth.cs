using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity;
using ZM.Mvc.RavenDbUsers.Models;

namespace ZM.Mvc.RavenDbUsers
{
    public partial class Startup
    {
        #region Methods

        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the application to use a cookie to store information for the signed in user.
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password.
                    OnValidateIdentity =
                        SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                            validateInterval: TimeSpan.FromMinutes(30),
                            regenerateIdentity: (userManager, user) => user.GenerateUserIdentityAsync(userManager)
                        )
                }
            });
        }

        #endregion

        #region Constructor(s)

        static Startup()
        {
        }

        #endregion
    }
}