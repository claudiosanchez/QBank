namespace TinyMessenger
{
    /// <summary>
    /// Default "pass through" proxy.
    /// 
    /// Does nothing other than deliver the message.
    /// </summary>
    public sealed class DefaultTinyMessageProxy : ITinyMessageProxy
    {
        private static readonly DefaultTinyMessageProxy _Instance = new DefaultTinyMessageProxy();

        static DefaultTinyMessageProxy()
        {
        }

        /// <summary>
        /// Singleton instance of the proxy.
        /// </summary>
        public static DefaultTinyMessageProxy Instance
        {
            get
            {
                return _Instance;
            }
        }

        private DefaultTinyMessageProxy()
        {
        }

        public void Deliver(ITinyMessage message, ITinyMessageSubscription subscription)
        {
            subscription.Deliver(message);
        }
    }
}