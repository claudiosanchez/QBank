using System.ServiceModel;

namespace QBank.Service.Model
{
    [MessageContract]
    public class ResponseBase
    {
        [MessageBodyMember(Order = 1)] 
        public bool IsError;
        [MessageBodyMember(Order = 2)] 
        public string ErrorMessage;
    }
}