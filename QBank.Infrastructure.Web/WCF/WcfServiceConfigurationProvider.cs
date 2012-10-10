using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace QBank.Infrastructure.Web.WCF
{
    /// <summary>
    /// Serves as a configuration respository for WCF Service Contracts.
    /// </summary>
    public class WcfServiceConfigurationProvider : IWcfServiceConfigurationProvider
    {
        private readonly IList<WcfServiceConfigurationSet> _configurationSets = new List<WcfServiceConfigurationSet>();
        private Binding _defaultBinding;
        private Uri _defaultBaseAddress;

        /// <summary>
        /// With the default binding.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <returns></returns>
        public IWcfServiceConfigurationProvider WithDefaultBinding(Binding binding)
        {
            _defaultBinding = binding;

            return this;
        }

        /// <summary>
        /// With the base address.
        /// </summary>
        /// <param name="baseAddress">The base address.</param>
        /// <returns></returns>
        public IWcfServiceConfigurationProvider WithBaseAddress(Uri baseAddress)
        {
            _defaultBaseAddress = baseAddress;

            return this;
        }
        
        /// <summary>
        /// Adds the configuration set.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="binding">The binding.</param>
        /// <param name="contract">The contract.</param>
        public IWcfServiceConfigurationProvider AddConfigurationSet(Uri address, PreferredBinding binding, Type contract)
        {
           // if(_defaultBinding == null || _defaultBaseAddress == null ) throw new ApplicationException("WithDefaultBinding and WithBaseAddress need to be called first.");
            
            _configurationSets.Add(new WcfServiceConfigurationSet(address, binding, contract));

            return this;
        }

        /// <summary>
        /// Adds the configuration set. Defaults the Uri to blank. 
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="contract">The contract.</param>
        public IWcfServiceConfigurationProvider AddConfigurationSet(PreferredBinding binding, Type contract)
        {
            return AddConfigurationSet(new Uri("", UriKind.Relative), binding, contract);
        }

        /// <summary>
        /// Adds the configuration set. Sets the preferred binding to NoPreference.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="contract">The contract.</param>
        public IWcfServiceConfigurationProvider AddConfigurationSet( Type contract)
        {
            return AddConfigurationSet(PreferredBinding.NoPreference, contract);
        }
       

        /// <summary>
        /// Resolves the preferred binding type into an actual binding. This algorithm can be improved in the future to be have multiple bindings 
        /// </summary>
        /// <param name="binding">The preferred binding type.</param>
        /// <returns></returns>
        private Binding ResolveBinding(PreferredBinding binding)
        {
            var effectiveBinding = _defaultBinding;

            switch (binding)
            {
                case PreferredBinding.NoPreference:

                    effectiveBinding = _defaultBinding;
                    break;

                case PreferredBinding.Http:
                    if (_defaultBinding.GetType() == typeof (WSHttpBinding)) effectiveBinding =  _defaultBinding;
                    break;


                case PreferredBinding.NetTcp:
                    if (_defaultBinding.GetType() == typeof(WSHttpBinding)) effectiveBinding = _defaultBinding;
                    break;
            }

            return effectiveBinding;
        }
        
    }
}