using System.Web.Mvc;

namespace ZM.Mvc.RavenDbUsers.Controllers
{
    public sealed class HomeController : Controller
    {
        #region Methods

        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region Constructor(s)

        public HomeController()
        {
        }

        #endregion
    }
}