using System;

namespace QBank.Infrastructure.Web.WCF
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoHostingWcfServiceAttribute: Attribute
    {
        private readonly PreferredBinding _preferredBinding;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoHostingWcfServiceAttribute"/> class.
        /// </summary>
        /// <param name="preferredBinding">The default binding.</param>
        public AutoHostingWcfServiceAttribute(PreferredBinding preferredBinding)
        {
            _preferredBinding = preferredBinding;
        }

        public PreferredBinding PreferredBinding
        {
            get { return _preferredBinding; }
        }
    }
}