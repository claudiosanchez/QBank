using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using QBank.DataAccess;
using QBank.Infrastructure.Web.WCF;
using QBank.Service;

namespace QBank.Api
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeDb();
            RegisterWCFService();
        }

        private static void RegisterWCFService()
        {
            //RouteTable.Routes.Add(new ServiceRoute("AccountService", new DependencyInjectionServiceHostFactory(),
            //                                       typeof (AccountService)));
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
    }
}