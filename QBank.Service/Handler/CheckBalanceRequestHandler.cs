using QBank.DataAccess;
using QBank.Model;
using QBank.Service.Mapper;
using QBank.Service.Model;

namespace QBank.Service.Handler
{
    public class CheckBalanceRequestHandler : RequestHandlerBase<CheckBalanceRequest, CheckBalanceResponse>
    {
        private readonly IEntityMapper<AccountDto, Account> _entityMapper;
        private readonly MyUnitOfWork _unitofWork;

        public CheckBalanceRequestHandler(MyUnitOfWork unitofWork, IEntityMapper<AccountDto, Account> entityMapper)
        {
            _unitofWork = unitofWork;
            _entityMapper = entityMapper;
        }

        public override CheckBalanceResponse Handle(CheckBalanceRequest request)
        {
            var response = CreateResponse();

            var account = _unitofWork.AccountRepository.First(a => a.AccountNumber.Equals(request.AccountNumber));

            response.Account = _entityMapper.MapToDto(account);

            return response;
        }
    }
}