using System;
using Raven.Client.Embedded;

namespace ZM.Mvc.RavenDbUsers.Infrastructure.UserIdentity
{
    public sealed class UserDb
    {
        #region Properties

        public EmbeddableDocumentStore DbContext { get; private set; }

        #endregion

        #region Methods

        private EmbeddableDocumentStore ConfigureDbContext()
        {
            const string RavenDbConnectionStringName = "RavenDB";
            const string UserDbName = "Users";

            var userStore = new EmbeddableDocumentStore();

            userStore.ConnectionStringName = RavenDbConnectionStringName;
            userStore.DefaultDatabase = UserDbName;
#if DEBUG
            userStore.UseEmbeddedHttpServer = true;
            userStore.Configuration.Port = 9999; // configure to use a different port than the localhost project (so the RavenDb doesn't "take over" the web app routes)
#endif
            userStore.Initialize();
            userStore.SetRequestsTimeoutFor(TimeSpan.FromSeconds(15)); // increase the timeout for initialization (default is 5 seconds). must be done after Initialize()
            userStore.DatabaseCommands.GlobalAdmin.EnsureDatabaseExists(UserDbName);

            return userStore;
        }

        #endregion

        #region Constructor(s)

        public UserDb()
        {
            this.DbContext = this.ConfigureDbContext();
        }

        #endregion
    }
}