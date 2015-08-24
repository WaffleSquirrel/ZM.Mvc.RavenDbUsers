using System;
using System.Web;
using System.Web.Mvc;
using AspNet.Identity.RavenDB.Stores;
using Microsoft.AspNet.Identity.Owin;
using Raven.Client;
using ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity;
using ZM.Mvc.RavenDbUsers.Models;

namespace ZM.Mvc.RavenDbUsers.Infrastructure.Mvc
{
    public abstract class RavenController : Controller
    {
        #region Fields

        protected readonly IUserIdentityService UserIdentityService;

        #endregion

        //#region Properties

        //public IAsyncDocumentSession RavenDocumentSession { get; set; }

        //#endregion

        #region Methods

        //private void CreateRavenSession()
        //{
        //    this.RavenDocumentSession = this.UserIdentityService.UserDatabase.OpenAsyncSession();
        //    this.RavenDocumentSession.Advanced.UseOptimisticConcurrency = true;
        //}

        protected HttpStatusCodeResult HttpNotModified()
        {
            return new HttpStatusCodeResult(304);
        }

        #endregion

        #region Overrides

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (this.RavenDocumentSession == null)
            //{
            //    this.CreateRavenSession();
            //}

            //var options = new IdentityFactoryOptions<ApplicationUserManager>();
            //var userStore = new RavenUserStore<ApplicationUser>(this.RavenDocumentSession);
            //var authenticationManager = HttpContextBaseExtensions.GetOwinContext(filterContext.HttpContext).Authentication;

            //this.UserIdentityService.UserManager = ApplicationUserManager.Create(options, userStore);
            //this.UserIdentityService.SignInManager = new ApplicationSignInManager(this.UserIdentityService.UserManager, authenticationManager);

            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //if (this.RavenDocumentSession != null)
            //{
            //    using (this.RavenDocumentSession)
            //    {
            //        var thereIsNoRavenDocumentSessionException = filterContext.Exception == null;

            //        if (thereIsNoRavenDocumentSessionException)
            //        {
            //            this.RavenDocumentSession.SaveChangesAsync();
            //        }
            //    }
            //}

            base.OnActionExecuted(filterContext);
        }

        #endregion

        #region Constructor(s)

        public RavenController(IUserIdentityService userIdentityService)
        {
            if (userIdentityService == null)
            {
                throw new ArgumentNullException("userIdentityService");
            }

            this.UserIdentityService = userIdentityService;
        }

        #endregion
    }
}