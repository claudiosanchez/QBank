using System.ServiceModel;

namespace QBank.Service.Model
{
    [MessageContract]
    public class CheckBalanceResponse : ResponseBase
    {
        [MessageBodyMember(Order = 3)]
        public AccountDto Account;
    }
}