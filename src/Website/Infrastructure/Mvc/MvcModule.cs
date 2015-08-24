using Autofac;
using Autofac.Integration.Mvc;

namespace ZM.Mvc.RavenDbUsers.Infrastructure.Mvc
{
    public class MvcModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterFilterProvider();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerRequest();
        }
    }
}