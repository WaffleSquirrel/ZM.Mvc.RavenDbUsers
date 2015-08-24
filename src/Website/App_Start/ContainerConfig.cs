using System.Reflection;
using System.Web;
using AspNet.Identity.RavenDB.Stores;
using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using Raven.Client;
using ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity;
using ZM.Mvc.RavenDbUsers.Models;

namespace ZM.Mvc.RavenDbUsers.App_Start
{
    public class ContainerConfig
    {
        public static ContainerBuilder Configure(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // make the RavenDB document store a single instance for the lifetime of the app
            builder.Register(c =>
            {
                return new UserDb().DbContext;
            }).As<IDocumentStore>().SingleInstance();

            // ensure a new Raven Session is created from the RavenDB document store when an IAysncDocumentSession dependency is resolved/injected
            builder.Register(c =>
            {
                var ravenSession = c.Resolve<IDocumentStore>().OpenAsyncSession();

                ravenSession.Advanced.UseOptimisticConcurrency = true;

                return ravenSession;

            }).As<IAsyncDocumentSession>();

            // ensure a new instance of a RavenUserStore<ApplicationUser> is created with an async Raven Session when an IUserStore<ApplicationUser> dependency is resolved/injected
            builder.Register(c => new RavenUserStore<ApplicationUser>(c.Resolve<IAsyncDocumentSession>(), disposeDocumentSession: false)).As<IUserStore<ApplicationUser>>();

            // ensure a new instance of the AuthenicationManager that is reqistered in the OwinContext is created when an IAuthenticationManager dependency is resolved/injected
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();

            //// ensure a new instance of a UserManager<ApplicationUser> is created with resolved dependencies
            //builder.RegisterType<UserManager<ApplicationUser>>();

            //// ensure a new instance of a SignInManager<ApplicationUser, string> is created with resolved dependencies
            //builder.RegisterType<SignInManager<ApplicationUser, string>>();

            // ensure a new instance of a UserIdentityService is created with resolved dependencies when an IUserIdentityService dependency is resolved/injected
            builder.Register(c => new UserIdentityService(c.Resolve<IUserStore<ApplicationUser>>(), c.Resolve<IAuthenticationManager>())).As<IUserIdentityService>();

            //// Custom OAuth Provider stuff, not needed right now
            //// needed to generate user tokens to confirm account registration and for password reset tokens
            //// see http://tech.trailmax.info/2014/09/aspnet-identity-and-ioc-container-registration/
            ////builder.Register(p => app.GetDataProtectionProvider()).As<IDataProtectionProvider>();

            // ensure any custom Autofac modules are registered found in this assembly
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            return builder;
        }
    }
}