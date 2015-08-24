using System;
using System.Web.Mvc;
using ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity;

namespace ZM.Mvc.RavenDbUsers.Infrastructure.Mvc
{
    public abstract class RavenController : Controller
    {
        #region Fields

        protected readonly IUserIdentityService UserIdentityService;

        #endregion

        #region Methods

        protected HttpStatusCodeResult HttpNotModified()
        {
            return new HttpStatusCodeResult(304);
        }

        #endregion

        #region Overrides

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Do stuff here if you want

            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Do stuff here if you want

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