using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Owin;

namespace ZM.Mvc.RavenDbUsers.Infrastructure.Extensions
{
    public static class OwinExtensions
    {
        public static IAppBuilder ConfigureMvc(this IAppBuilder app, IContainer container)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return app.UseAutofacMvc();
        }
    }
}