using System;
using Raven.Client;

namespace ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity
{
    public interface IUserIdentityService : IDisposable
    {
        #region Properties

        IDocumentStore UserDatabase { get; }

        ApplicationUserManager UserManager { get; set; }

        ApplicationSignInManager SignInManager { get; set; }

        #endregion
    }
}