using QBank.Service.Model;

namespace QBank.Service.Handler
{
    public interface IRequestHandler<TRequest, TResponse> where TRequest: class, new()
                                                          where TResponse:ResponseBase
    {
        TResponse Handle(TRequest request);
    }
}