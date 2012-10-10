using QBank.Model;
using QBank.Service.Model;

namespace QBank.Service.Mapper
{
    public class AccountMapper : IEntityMapper<AccountDto, Account>
    {
        #region IEntityMapper<AccountDto,Account> Members

        public AccountDto MapToDto(Account entity)
        {
            return new AccountDto
                       {
                           AccountHolder = entity.AccountHolder,
                           Balance = entity.Balance,
                           AccountType = entity.AccountType
                       };
        }

        #endregion
    }
}