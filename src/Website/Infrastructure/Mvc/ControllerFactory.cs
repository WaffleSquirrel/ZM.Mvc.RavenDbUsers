using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client;
using ZM.Mvc.RavenDbUsers.Controllers;
using ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity;

namespace ZM.Mvc.RavenDbUsers.Infrastructure.Mvc
{
    //internal sealed class ControllerFactory : DefaultControllerFactory
    //{
    //    #region Fields

    //    private readonly Dictionary<string, Func<RequestContext, IController>> _controllerMap;

    //    #endregion

    //    #region Overrides

    //    public override IController CreateController(RequestContext requestContext, string controllerName)
    //    {
    //        if (requestContext == null)
    //        {
    //            throw new ArgumentNullException("requestContext");
    //        }

    //        //if (string.IsNullOrWhiteSpace(controllerName))
    //        //{
    //        //    throw new ArgumentException("A valid [controllerName] was not provided.");
    //        //}

    //        if (this._controllerMap.ContainsKey(controllerName))
    //        {
    //            return this._controllerMap[controllerName](requestContext);
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }

    //    public override void ReleaseController(IController controller)
    //    {
    //        base.ReleaseController(controller);
    //    }

    //    #endregion

    //    #region Constructor(s)

    //    public ControllerFactory(IUserIdentityService userIdentityService)
    //    {
    //        if (userIdentityService == null)
    //        {
    //            throw new ArgumentNullException("userIdentityService");
    //        }

    //        this._controllerMap = new Dictionary<string, Func<RequestContext, IController>>();

    //        // Map factory for Home controller
    //        this._controllerMap["Home"] = requestContext => new HomeController();

    //        // Map factory for Admin controller
    //        this._controllerMap["Admin"] = requestContext =>
    //        {
    //            if (requestContext == null)
    //            {
    //                throw new ArgumentNullException("The [requestContext] is null. Unable to create the controller.");
    //            }

    //            //if (requestContext.HttpContext == null)
    //            //{
    //            //    throw new ArgumentException("The HttpContext is null for the [requestContext]. Unable to create the controller.");
    //            //}

    //            //IOwinContext owinContext = HttpContextBaseExtensions.GetOwinContext(requestContext.HttpContext);

    //            return new AdminController(userIdentityService);
    //        };
    //    }

    //    #endregion
    //}
}