using System.Linq;
using QBank.DataAccess;
using QBank.Model;
using QBank.Service.Mapper;
using QBank.Service.Model;

namespace QBank.Service.Handler
{
    public class CheckBalanceRequestHandler : RequestHandlerBase<CheckBalanceRequest, CheckBalanceResponse>
    {
        private readonly IEntityMapper<AccountDto, Account> _entityMapper;
        private readonly IAccountRepository _repository;

        public CheckBalanceRequestHandler(IAccountRepository repository, IEntityMapper<AccountDto, Account> entityMapper)
        {
            _repository = repository;
            _entityMapper = entityMapper;
        }

        public override CheckBalanceResponse Handle(CheckBalanceRequest request)
        {
            var response = CreateResponse();

            var account = _repository.Accounts().First(a => a.AccountNumber.Equals(request.AccountNumber));

            response.Account = _entityMapper.MapToDto(account);

            return response;
        }
    }
}