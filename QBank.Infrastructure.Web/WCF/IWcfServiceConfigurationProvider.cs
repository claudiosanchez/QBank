using System;
using System.ServiceModel.Channels;

namespace QBank.Infrastructure.Web.WCF
{
    public interface IWcfServiceConfigurationProvider
    {
        /// <summary>
        /// With the default binding.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <returns></returns>
        IWcfServiceConfigurationProvider WithDefaultBinding(Binding binding);

        /// <summary>
        /// With the base address.
        /// </summary>
        /// <param name="baseAddress">The base address.</param>
        /// <returns></returns>
        IWcfServiceConfigurationProvider WithBaseAddress(Uri baseAddress);

        /// <summary>
        /// Adds the configuration set.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="binding">The binding.</param>
        /// <param name="contract">The contract.</param>
        IWcfServiceConfigurationProvider AddConfigurationSet(Uri address, PreferredBinding binding, Type contract);

        /// <summary>
        /// Adds the configuration set. Defaults the Uri to blank. 
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="contract">The contract.</param>
        IWcfServiceConfigurationProvider AddConfigurationSet(PreferredBinding binding, Type contract);

        /// <summary>
        /// Adds the configuration set. Sets the preferred binding to NoPreference.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="contract">The contract.</param>
        IWcfServiceConfigurationProvider AddConfigurationSet( Type contract);
    }
}