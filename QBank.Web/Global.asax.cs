using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using EntityFramework.Patterns;
using QBank.DataAccess;
using QBank.Infrastructure.Web.WCF;
using QBank.Model;
using QBank.Service;

namespace QBank.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            InitializeDb();
            HostWCFServices();
            RouteTable.Routes.Add(new ServiceRoute("AccountService", new DependencyInjectionServiceHostFactory(),typeof(AccountService)));
        }

        private void HostWCFServices()
        {
           
        }

        private static void InitializeDb()
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            var init = new QBankDbInitializer();
            Database.SetInitializer(init);
            using (var ctx = new QBankContext())
            {
                init.InitializeDatabase(ctx);
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}