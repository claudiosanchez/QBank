using System;
using System.ServiceModel.Web;

namespace QBank.Infrastructure.Web.WCF
{
    /// <summary>
    /// Provides a host for services with the ability to resolve service instance using a IoC Container.
    /// </summary>
    public class DependencyInjectionEnabledWebServiceHost : WebServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyInjectionEnabledWebServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        public DependencyInjectionEnabledWebServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }
      

        /// <summary>
        /// Invoked during the transition of a communication object into the opening state.
        /// </summary>
        protected override void OnOpening()
        {
            Description.Behaviors.Add(new DependencyInjectionServiceBehavior());
            base.OnOpening();
        }
    }
}