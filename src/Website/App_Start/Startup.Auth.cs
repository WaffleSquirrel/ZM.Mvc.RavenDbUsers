using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Raven.Client;
using Raven.Client.Embedded;
using ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity;
using ZM.Mvc.RavenDbUsers.Models;

namespace ZM.Mvc.RavenDbUsers
{
    public partial class Startup
    {
        //#region Fields

        //private static IDocumentStore _userDbContext;

        //#endregion

        #region Methods

        public void ConfigureAuth(IAppBuilder app)
        {
            //if (documentStore == null)
            //{
            //    throw new ArgumentNullException("documentStore");
            //}

            //_userDbContext = documentStore;

            //// Configure per-request lifetime instances in the Owin Context for:
            //// 1.) Application User DB Context
            //// 2.) Application User Manager
            //// 3.) Application Sign-In Manager
            //app.CreatePerOwinContext<EmbeddableDocumentStore>(() => _userDbContext as EmbeddableDocumentStore);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            //app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

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
            //OAuthOptions = new OAuthAuthorizationServerOptions
            //{
            //    // Exposes Token endpoint
            //    TokenEndpointPath = new PathString("/Token"),
            //
            //    // Use ApplicationOAuthProvider in order to authenticate
            //    Provider = new ApplicationOAuthProvider(PublicClientId, UserManagerFactory),
            //               AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
            //               AccessTokenExpireTimeSpan = TimeSpan.FromDays(14), // Token expiration => The user will remain authenticated for 14 days
            //               AllowInsecureHttp = true
            //};
        }

        #endregion
    }
}