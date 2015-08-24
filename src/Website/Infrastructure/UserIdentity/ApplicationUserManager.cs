using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ZM.Mvc.RavenDbUsers.Models;

namespace ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity
{
    public sealed class ApplicationUserManager : UserManager<ApplicationUser>
    {
        #region Methods

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IUserStore<ApplicationUser> userStore)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if (userStore == null)
            {
                throw new ArgumentNullException("userStore");
            }

            var userManager = new ApplicationUserManager(userStore);

            // configure validation logic for usernames
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // configure validation logic for passwords
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // configure user lockout defaults
            userManager.UserLockoutEnabledByDefault = true;
            userManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            userManager.MaxFailedAccessAttemptsBeforeLockout = 10;

            // configure data protection provider
            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return userManager;
        }

        #endregion

        #region Constructor(s)

        private ApplicationUserManager(IUserStore<ApplicationUser> userStore) : base(userStore)
        {
        }

        #endregion
    }
}