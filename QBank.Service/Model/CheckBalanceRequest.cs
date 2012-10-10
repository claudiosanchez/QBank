using System.ServiceModel;

namespace QBank.Service.Model
{
    [MessageContract]
    public class CheckBalanceRequest
    {
        [MessageBodyMember(Order = 1)]
        public string AccountNumber;
    }
}