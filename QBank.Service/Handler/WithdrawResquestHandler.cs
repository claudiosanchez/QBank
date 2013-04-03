using System.Linq;
using QBank.DataAccess;
using QBank.Model;
using QBank.Service.Mapper;
using QBank.Service.Model;

namespace QBank.Service.Handler
{
    public class WithdrawResquestHandler: RequestHandlerBase<WithdrawRequest, WithdrawResponse>
    {
        private readonly IEntityMapper<AccountDto, Account> _mapper;
        private readonly AccountRepository _repository;

        public WithdrawResquestHandler(AccountRepository repository,IEntityMapper<AccountDto, Account> mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override WithdrawResponse Handle(WithdrawRequest request)
        {
            var response = CreateResponse();
            // TODO: In real life, this would be part of an Account Facade/Manager wrapping the whole thing in a transaction 

            var account = _repository.Accounts().First(a => a.AccountNumber.Equals(request.AccountNumber));

            string errorMessage = string.Empty;
            bool isError = false;

            if (account == null)
                return new WithdrawResponse { Account = new AccountDto(), IsError = true, ErrorMessage = "Account Not Found." };

            // If there is not enough balance
            if (account.Balance < request.Amount)
            {
                errorMessage = string.Format("There are insufficient funds in account {0}", account.AccountNumber);
                isError = true;
            }
                // Execute the withdrawal and return the new balance
            else
            {
                account.Balance -= request.Amount;
                //_unitOfWork.Commit();
            }

            AccountDto dto = _mapper.MapToDto(account);

            return new WithdrawResponse { Account = dto, IsError = isError, ErrorMessage = errorMessage };
        }
    }
}