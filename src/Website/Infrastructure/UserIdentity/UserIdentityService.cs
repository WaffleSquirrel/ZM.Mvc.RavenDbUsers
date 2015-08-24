using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Raven.Client;
using ZM.Mvc.RavenDbUsers.Models;

namespace ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity
{
    internal sealed class UserIdentityService : IUserIdentityService
    {
        #region Constructor(s)

        internal UserIdentityService(IUserStore<ApplicationUser> userStore, IAuthenticationManager authenticationManager)
        {
            if (userStore == null)
            {
                throw new ArgumentNullException("userStore");
            }

            if (authenticationManager == null)
            {
                throw new ArgumentNullException("authenticationManager");
            }

            //this.UserDatabase = documentStore;

            var options = new IdentityFactoryOptions<ApplicationUserManager>();

            this.UserManager = ApplicationUserManager.Create(options, userStore);
            this.SignInManager = new ApplicationSignInManager(this.UserManager, authenticationManager);
        }

        #endregion

        #region IUserIdentityService Members

        public IDocumentStore UserDatabase
        {
            get;
            private set;
        }

        public ApplicationUserManager UserManager
        {
            get;
            set;
        }

        public ApplicationSignInManager SignInManager
        {
            get;
            set;
        }

        #endregion

        #region IDisposable Members (with supporting members to properly implement the disposable pattern)

        // A flag to detect redundant Dispose() calls
        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.SignInManager != null)
                    {
                        this.SignInManager.Dispose();
                    }

                    if (this.UserManager != null)
                    {
                        this.UserManager.Dispose();
                    }

                    if (this.UserDatabase != null)
                    {
                        this.UserDatabase.Dispose();
                    }
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);
        }

        #endregion
    }
}