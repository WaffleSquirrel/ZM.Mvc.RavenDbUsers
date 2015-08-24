using System.Web.Mvc;
using Autofac;
using Microsoft.Owin;
using Owin;
using ZM.Mvc.RavenDbUsers;
using ZM.Mvc.RavenDbUsers.App_Start;
using ZM.Mvc.RavenDbUsers.Infrastructure.Extensions;
using ZM.Mvc.RavenDbUsers.Infrastructure.Mvc;
using ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity;

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

            app.UseAutofacMiddleware(container)
               .ConfigureMvc(container);

            //ControllerBuilder.Current.SetControllerFactory(CompositionRoot.GetMvcControllerFactory());
        }

        #endregion
    }
}