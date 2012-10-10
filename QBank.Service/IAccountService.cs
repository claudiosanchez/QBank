using System.ServiceModel;
using QBank.Service.Model;

namespace QBank.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountService" in both code and config file together.
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        CheckBalanceResponse CheckBalance(CheckBalanceRequest request);

        [OperationContract]
        WithdrawResponse Withdraw(WithdrawRequest request);
    }
}