using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using StructureMap;

namespace QBank.Infrastructure.Web.WCF
{
    /// <summary>
    /// WCF Instance Provider implementation using Dependency Injection via StructureMap Container. 
    /// </summary>
    public class DependencyInjectionInstanceProvider : IInstanceProvider
    {
        private readonly IContainer _container;
        private readonly Type _serviceContractType;

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyInjectionInstanceProvider"/> class.
        /// </summary>
        /// <param name="serviceContractType">Type of the service contract to be resolved.</param>
        /// <param name="container">The container.</param>
        public DependencyInjectionInstanceProvider(Type serviceContractType, IContainer container = null)
        {
            _container = container;
            _serviceContractType = serviceContractType;
        }

        public DependencyInjectionInstanceProvider()
        {
        }

        #region Implementation of IInstanceProvider

        /// <summary>
        /// Returns a service object given the specified <see cref="T:System.ServiceModel.InstanceContext"/> object.
        /// </summary>
        /// <returns>
        /// A user-defined service object.
        /// </returns>
        /// <param name="instanceContext">The current <see cref="T:System.ServiceModel.InstanceContext"/> object.</param>
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        /// <summary>
        /// Returns a service object given the specified <see cref="T:System.ServiceModel.InstanceContext"/> object.
        /// </summary>
        /// <returns>
        /// The service object.
        /// </returns>
        /// <param name="instanceContext">The current <see cref="T:System.ServiceModel.InstanceContext"/> object.</param><param name="message">The message that triggered the creation of a service object.</param>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            object instance = ObjectFactory.Container.TryGetInstance(_serviceContractType);


            if (instance == null)
            {
                throw new ApplicationException(
                    string.Format("Unable to resolve Service Instance. Please see the Log for more details."));
            }

            return instance;
        }

        /// <summary>
        /// Called when an <see cref="T:System.ServiceModel.InstanceContext"/> object recycles a service object.
        /// </summary>
        /// <param name="instanceContext">The service's instance context.</param><param name="instance">The service object to be recycled.</param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            var disposable = instance as IDisposable;
            if (!ReferenceEquals(null, disposable))
            {
                disposable.Dispose();
            }
        }

        #endregion
    }
}