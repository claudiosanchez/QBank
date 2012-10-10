using System;
using System.ServiceModel;
using StructureMap;

namespace QBank.Infrastructure.Web.WCF
{
    public class DependencyInjectionEnabledServiceHost: ServiceHost
    {
        private readonly IContainer _container;

        public DependencyInjectionEnabledServiceHost(IContainer container, Type serviceType):base(serviceType)
        {
            _container = container;
        }

        public DependencyInjectionEnabledServiceHost(IContainer container, Type serviceType, params Uri[] baseAddreses)
            : base(serviceType, baseAddreses)
        {
            _container = container;
        }


        /// <summary>
        /// Invoked during the transition of a communication object into the opening state.
        /// </summary>
        protected override void OnOpening()
        {
            Description.Behaviors.Add(new DependencyInjectionServiceBehavior(_container));
            base.OnOpening();
        }
    }
}