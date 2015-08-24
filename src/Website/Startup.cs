using Autofac;
using Microsoft.Owin;
using Owin;
using ZM.Mvc.RavenDbUsers;
using ZM.Mvc.RavenDbUsers.App_Start;
using ZM.Mvc.RavenDbUsers.Infrastructure.Extensions;

[assembly: OwinStartup(typeof(Startup))]
namespace ZM.Mvc.RavenDbUsers
{
    public partial class Startup
    {
        #region Methods

        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);

            // Configure IoC container
            IContainer container = ContainerConfig.Configure(app).Build();

            // Finalize IoC container configuration and register the custom MVC Autofac configuration with Owin
            app.UseAutofacMiddleware(container)
               .ConfigureMvc(container);
        }

        #endregion
    }
}