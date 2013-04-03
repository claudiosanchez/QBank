using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using NLog;
using QBank.Infrastructure.Web.WCF;

namespace QBank.Infrastructure.Web.Proxy
{
    public interface IDynamicWebServiceProxy<TServiceContract>: IDisposable
    {
        /// <summary>
        /// Gets or sets the name of the endpoint.
        /// </summary>
        /// <value>The name of the endpoint.</value>
        string EndpointName { get; set; }

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <value>The client.</value>
        TServiceContract Client { get; }

        /// <summary>
        /// Calls the operation on client. 
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <returns></returns>
        OperationResults CallOperationOnClient(Action operation);

        /// <summary>
        /// Calls the operation on client.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="operation">The operation.</param>
        /// <returns><see cref="OperationResults&lt;TResult&gt;"/></returns>
        OperationResults<TResult> CallOperationOnClient<TResult>(Func<TResult> operation);
    }

    /// <summary>
    /// Dynamically create a WCF proxy class using the given interface. 
    /// This class currently supports automatic configuration of http and tcp bindings based on the Uri provided for the endpoint.
    /// </summary>
    /// <typeparam name="TServiceContract">The type of the service contract.</typeparam>
    public class DynamicWebServiceProxy<TServiceContract> : IDynamicWebServiceProxy<TServiceContract>
    {
        #region Constants and Fields

        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly bool _userConfigurationFile;
        private ChannelFactory<TServiceContract> _channel;
        private TServiceContract _client;
        private readonly Uri _remoteUri;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicWebServiceProxy&lt;TServiceContract&gt;"/> class.
        /// </summary>
        public DynamicWebServiceProxy()
        {
            _userConfigurationFile = true;
            EndpointName = typeof (TServiceContract).Name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicWebServiceProxy&lt;TServiceContract&gt;"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public DynamicWebServiceProxy(string endpointConfigurationName)
        {
            EndpointName = endpointConfigurationName;
            _userConfigurationFile = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicWebServiceProxy&lt;TServiceContract&gt;"/> class.
        /// </summary>
        /// <param name="remoteAddress">The remote address.</param>
        public DynamicWebServiceProxy(Uri remoteAddress)
        {
            if (!remoteAddress.IsAbsoluteUri)
                throw new ApplicationException("Uri must be absolute. i.e.:net.tcp://somehost:8000/SomeService/");

            _remoteUri = remoteAddress;
            _userConfigurationFile = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <value>The client.</value>
        public TServiceContract Client
        {
            get
            {
                if (_client == null)
                {
                    _channel = CreateChannelFactory();
                    _client = CreateChannel();
                }
                return _client;
            }
        }

        /// <summary>
        /// Gets or sets the name of the endpoint.
        /// </summary>
        /// <value>The name of the endpoint.</value>
        public string EndpointName { get; set; }

        protected virtual TServiceContract CreateChannel()
        {
            return _channel.CreateChannel();
        }

        protected virtual ChannelFactory<TServiceContract> CreateChannelFactory()
        {
            if (!typeof (TServiceContract).IsInterface)
            {
                throw new NotSupportedException("TServiceContract must be an interface!");
            }
            if (_userConfigurationFile && string.IsNullOrEmpty(EndpointName))
            {
                throw new NotSupportedException("EndpointName must be set prior to use!");
            }

            if (_userConfigurationFile) new ChannelFactory<TServiceContract>(EndpointName);

            Binding binding = CreateBinding();
            EndpointAddress endpoint = CreateEndPointAddress();

            var channelf = new ChannelFactory<TServiceContract>(binding, endpoint);

            return channelf;
        }

        /// <summary>
        /// Creates the end point address.
        /// </summary>
        /// <returns></returns>
        protected virtual EndpointAddress CreateEndPointAddress()
        {
            var endpoint = new EndpointAddress(_remoteUri);
            return endpoint;
        }

        /// <summary>
        /// Creates the binding.
        /// </summary>
        /// <returns></returns>
        protected virtual Binding CreateBinding()
        {
            Binding binding = null;

            switch (_remoteUri.Scheme)
            {
                case "net.tcp":
                    binding = new NetTcpBinding(SecurityMode.None);
                    break;

                case "http":
                    binding = new WSHttpBinding(SecurityMode.None);
                    break;

                default:
                    throw new ApplicationException(string.Format("The following address is not supported. {0}",
                                                                 _remoteUri));
                    
            }

            return binding;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_channel != null)
            {
                _channel.CloseConnection();
            }
            GC.SuppressFinalize(this);
        }

        #endregion


        /// <summary>
        /// Calls the operation on client. 
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <returns></returns>
        public virtual OperationResults CallOperationOnClient(Action operation)
        {
            string message = string.Empty;

            try
            {
                operation.Invoke();
            }

            catch (FaultException ex)
            {
                Logger.Error(ex);
            }
            catch (CommunicationException ex)
            {
                message = "There was a communication-related problem. Please read the log for details."; 
                Logger.Error(ex);
            }
            
            
            return new OperationResults( true, message);
        }
        
        /// <summary>
        /// Calls the operation on client.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="operation">The operation.</param>
        /// <returns><see cref="OperationResults&lt;TResult&gt;"/></returns>
        public virtual OperationResults<TResult> CallOperationOnClient<TResult>(Func<TResult> operation)
        {
            bool succeeded = false;
            string message = string.Empty;
            TResult result;
            try
            {
                result = operation.Invoke();
                succeeded = true;
            }

            catch (FaultException ex)
            {
                // any other faults
                result = default(TResult);
            }

            catch (EndpointNotFoundException ex)
            {
                // The other side was not reachable. 
                succeeded = false;
                message = "We are sorry; the party you are trying to reach is not in service. Please read the log for details.";
                result = default(TResult);
                Logger.Error(message, ex);
            }

            catch (CommunicationException ex)
            {
                // any communication errors?
                succeeded = false;
                message = "There was a communication-related problem. Please read the log for details."; 
                result = default(TResult);
                Logger.Error(ex);
            }

           

            return new OperationResults<TResult>(result, succeeded, message);
        }
    }
}