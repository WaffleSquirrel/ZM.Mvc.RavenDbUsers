using Autofac;

namespace ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity
{
    public class IdentityModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // register identity related dependencies here (can move from ContainerConfig.cs)
        }
    }
}