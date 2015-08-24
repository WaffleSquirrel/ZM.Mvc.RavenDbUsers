using System.Web;
using Autofac;
using Microsoft.Owin.Security;

namespace ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity
{
    public class IdentityModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
        }
    }
}