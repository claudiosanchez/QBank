using System;
using System.ServiceModel;

namespace QBank.Infrastructure.Web.Proxy
{
    /// <summary>
    /// CommunicationObjectExtension class.
    /// </summary>
    public static class CommunicationObjectExtension
    {
        #region Public Methods

        /// <summary>
        /// Safely closes a service client connection.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        public static void CloseConnection ( this ICommunicationObject serviceClient )
        {
            if ( serviceClient == null )
            {
                return;
            }

            try
            {
                if ( serviceClient.State == CommunicationState.Opened )
                {
                    serviceClient.Close ();
                }
                else
                {
                    serviceClient.Abort ();
                }
            }
            catch ( CommunicationException )
            {
                // Logging.Logger.Log(ex);
                try
                {
                    serviceClient.Abort ();
                }
                catch
                {
                } //nasty but nothing useful can be found by 
                //logging this exception as secondary issue
            }
            catch ( TimeoutException )
            {
                //Logging.Logger.Log(ex);
                try
                {
                    serviceClient.Abort ();
                }
                catch
                {
                } //nasty but nothing useful can be found by 
                //logging this exception as secondary issue
            }
            catch ( Exception )
            {
                // Logging.Logger.Log(ex);
                try
                {
                    serviceClient.Abort ();
                }
                catch
                {
                } //nasty but nothing useful can be found by 
                //logging this exception as secondary issue
                throw;
            }
        }

        #endregion
    }
}