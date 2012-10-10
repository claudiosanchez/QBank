using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using StructureMap;

namespace QBank.Infrastructure.Web.WCF
{
    public class DependencyInjectionServiceHostFactory : ServiceHostFactory
    {
        /// <summary>
        /// Creates an instance of the specified <see cref="T:System.ServiceModel.Web.WebServiceHost"/> derived class with the specified base addresses.
        /// </summary>
        /// <param name="serviceType">The type of service host to create.</param>
        /// <param name="baseAddresses">An array of base addresses for the service.</param>
        /// <returns>
        /// An instance of a <see cref="T:System.ServiceModel.ServiceHost"/> derived class.
        /// </returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new DependencyInjectionEnabledServiceHost(ObjectFactory.Container,serviceType, baseAddresses);
            //return base.CreateServiceHost(serviceType, baseAddresses); 
        }
    }
}