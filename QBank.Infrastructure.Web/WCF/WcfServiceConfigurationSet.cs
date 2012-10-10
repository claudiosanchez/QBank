using System;

namespace QBank.Infrastructure.Web.WCF
{
    /// <summary>
    /// Represents the combination of Address, Binding and Contract (The ABCs) of WCF.
    /// </summary>
    /// <remarks></remarks>
    public class WcfServiceConfigurationSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WcfServiceConfigurationSet"/> class.
        /// </summary>
        /// <param name="address">The relative address.</param>
        /// <param name="binding">The preferred binding (if available.</param>
        /// <param name="contract">The contract.</param>
        /// <remarks></remarks>
        public WcfServiceConfigurationSet(Uri address, PreferredBinding binding, Type contract)
        {
            Address = address;
            Binding = binding;
            ContractType = contract;

        }
        /// <summary>
        /// Gets the type of the contract.
        /// </summary>
        /// <remarks></remarks>
        public Type ContractType { get; private set; }
        /// <summary>
        /// Gets the binding.
        /// </summary>
        /// <remarks></remarks>
        public PreferredBinding Binding { get; private set; }
        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <remarks></remarks>
        public Uri Address { get; private set; }
    }
}
