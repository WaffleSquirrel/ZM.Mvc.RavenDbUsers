using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using ZM.Mvc.RavenDbUsers.Infrastructure.Mvc;
using ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity;
using ZM.Mvc.RavenDbUsers.Models;

namespace ZM.Mvc.RavenDbUsers.Controllers
{
    public sealed class AccountController : RavenController
    {
        #region Constants

        // used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        #endregion

        #region Methods

        public ActionResult Create()
        {
            return View(new ApplicationUser("chiefchimp@zombiemonkeystudio.com"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                //await RavenDocumentSession.StoreAsync(user);

                return RedirectToAction("Index");
            }

            return View(user);
        }

        public async Task<ActionResult> Delete(string userId)
        {
            ApplicationUser userToDelete = new ApplicationUser("chiefchimp@zombiemonkeystudio.com"); // = await RavenDocumentSession.LoadAsync<ApplicationUser>(userId);

            return View(userToDelete);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string userId)
        {
            ApplicationUser userToDelete = new ApplicationUser("chiefchimp@zombiemonkeystudio.com"); // = await RavenDocumentSession.LoadAsync<ApplicationUser>(userId);

            //RavenDocumentSession.Delete<ApplicationUser>(userToDelete);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(string userId)
        {
            ApplicationUser user = new ApplicationUser("chiefchimp@zombiemonkeystudio.com"); // = await RavenDocumentSession.LoadAsync<ApplicationUser>(userId);

            return View(user);
        }

        public async Task<ActionResult> Edit(string userId)
        {
            ApplicationUser user = new ApplicationUser("chiefchimp@zombiemonkeystudio.com"); // = await RavenDocumentSession.LoadAsync<ApplicationUser>(userId);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = new ApplicationUser("chiefchimp@zombiemonkeystudio.com"); // = await RavenDocumentSession.LoadAsync<ApplicationUser>(user.UserName);

                currentUser.UserName = user.UserName;

                //await RavenDocumentSession.StoreAsync(currentUser);

                return RedirectToAction("Index");
            }

            return View(user);
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        #endregion

        #region Overrides

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion

        #region Constructor(s)

        public AccountController(IUserIdentityService userIdentityService) : base(userIdentityService)
        {
        }

        #endregion

        #region Classes

        public class ChallengeResult : HttpUnauthorizedResult
        {
            #region Properties

            public string LoginProvider { get; set; }

            public string RedirectUri { get; set; }

            public string UserId { get; set; }

            #endregion

            #region Overrides

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };

                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }

                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }

            #endregion

            #region Constructor(s)

            public ChallengeResult(string provider, string redirectUri) : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            #endregion
        }

        #endregion
    }
}