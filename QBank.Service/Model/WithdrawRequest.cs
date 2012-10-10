using System.ServiceModel;

namespace QBank.Service.Model
{
    [MessageContract]
    public class WithdrawRequest
    {
        [MessageBodyMember(Order = 1)] public string AccountNumber;
        [MessageBodyMember(Order = 2)] public double Amount;
    }
}