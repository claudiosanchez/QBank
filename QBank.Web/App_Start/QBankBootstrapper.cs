using System.Data.Entity;
using System.ServiceModel;
using HibernatingRhinos.Profiler.Appender.EntityFramework;
using QBank.Model;
using QBank.Service;
using QBank.Service.Handler;
using QBank.Service.Mapper;
using QBank.Service.Model;
using QBank.Web.App_Start;
using StructureMap;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof (QBankBootstrapper), "PreStart")]

namespace QBank.Web.App_Start
{
    public static class QBankBootstrapper
    {
        private static ServiceHost _host;
        private static IContainer _container;

        public static void PreStart()
        {
            // Initialize the profiler
            EntityFrameworkProfiler.Initialize();

            // Configure the IoC Container
            ObjectFactory
                .Configure(x => x.Scan(
                    s =>
                        {
                            s.AssembliesFromApplicationBaseDirectory();
                            s.WithDefaultConventions();
                            s.LookForRegistries();
                        }));

            _container = ObjectFactory.Container;

            RegisterServiceDependencies();
        }

        private static void RegisterServiceDependencies()
        {
            _container.Configure(x =>
                                     {
                                         // Handlers -- TODO: Scan and register based on convention
                                         x.For<IRequestHandler<CheckBalanceRequest, CheckBalanceResponse>>()
                                             .Use
                                             <CheckBalanceRequestHandler>();

                                         x.For<IRequestHandler<WithdrawRequest, WithdrawResponse>>()
                                             .Use
                                             <WithdrawResquestHandler>();

                                         x.For<IEntityMapper<AccountDto, Account>>().Use<AccountMapper>();
                                         x.For<AccountService>().Use<AccountService>();
                                         x.For<DbContext>().HttpContextScoped().Use(ctx => new DbContext("QBankContext"));
                                     });
        }
    }
}