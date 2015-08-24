using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Raven.Client;
using ZM.Mvc.RavenDbUsers.Infrastructure.Mvc;
using ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity;
using ZM.Mvc.RavenDbUsers.Models;

namespace ZM.Mvc.RavenDbUsers.Controllers
{
    //[Authorize]
    public sealed class AdminController : RavenController
    {
        #region Fields

        private string errorMessage;

        #endregion

        #region Enums

        public enum ManageMessageId
        {
            None = 0,
            NoRegisteredUsers,
            Error
        }

        #endregion

        #region Methods

        public ActionResult Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage = message == ManageMessageId.Error
                ? "An error has occurred."
                : "";

            return View();
        }

        // GET: /Admin/RegisteredUsers
        [Route("/Admin/RegisteredUsers")]
        [HttpGet, ActionName("RegisteredUsers")]
        public async Task<ActionResult> RegisteredUsers()
        {
            IList<ApplicationUser> registeredUsers = new List<ApplicationUser>();
            ManageMessageId message = ManageMessageId.None;

            try
            {
                registeredUsers = await this.UserIdentityService.UserManager.Users.ToListAsync(); //await this.RavenDocumentSession.Query<ApplicationUser>().ToListAsync();
            }
            catch (Exception ex)
            {
                // ToDo: Trace/Log
                this.errorMessage = ex.ToString();

                message = ManageMessageId.Error;
            }            

            if (message != ManageMessageId.Error)
            {
                if(registeredUsers.Count == 0)
                {
                    ViewBag.StatusMessage = "No registered users.";
                }
                else
                {
                    ViewBag.StatusMessage = string.Format("{0} registered users were found in the system.", registeredUsers.Count.ToString());
                }
            }
            else
            {
#if DEBUG
                ViewBag.StatusMessage = string.Format("An error has occurred. [Exception Details] = > {0}", this.errorMessage);
#else
                ViewBag.StatusMessage = "An error has occurred.";
#endif
            }

            return View(registeredUsers);
        }

        #endregion

        #region Constructor(s)

        public AdminController(IUserIdentityService userIdentityService) : base(userIdentityService)
        {
        }

        #endregion
    }
}