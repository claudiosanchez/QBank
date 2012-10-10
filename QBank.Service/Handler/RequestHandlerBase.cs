using QBank.Service.Model;

namespace QBank.Service.Handler
{
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
        where TRequest : class, new() 
        where TResponse : ResponseBase, new()
    {
        public abstract TResponse Handle(TRequest request);

        public virtual TResponse CreateResponse()
        {
            var response = new TResponse();
            return response;
        }

    }
}