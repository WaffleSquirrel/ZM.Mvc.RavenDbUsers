using System.Web.Mvc;

namespace ZM.Mvc.RavenDbUsers
{
    public class FilterConfig
    {
        #region Methods

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        #endregion
    }
}