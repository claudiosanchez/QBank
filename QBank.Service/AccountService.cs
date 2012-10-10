using System.ServiceModel.Activation;
using QBank.Model;
using QBank.Service.Handler;
using QBank.Service.Model;

namespace QBank.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
    public class AccountService : IAccountService
    {
        private readonly IRequestHandler<WithdrawRequest, WithdrawResponse> _wRequestHandler;
        private readonly IRequestHandler<CheckBalanceRequest, CheckBalanceResponse> _cRequestHandler;

        public AccountService(IRequestHandler<WithdrawRequest, WithdrawResponse> wRequestHandler, 
            IRequestHandler<CheckBalanceRequest, CheckBalanceResponse> cRequestHandler 
            )
        {
            _wRequestHandler = wRequestHandler;
            _cRequestHandler = cRequestHandler;
        }

        #region IAccountService Members

        
        public CheckBalanceResponse CheckBalance(CheckBalanceRequest request)
        {
            return _cRequestHandler.Handle(request);
        }
        
        #endregion

        public WithdrawResponse Withdraw(WithdrawRequest request)
        {
            return _wRequestHandler.Handle(request);
        }



       
    }
}