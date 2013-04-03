using System.Collections.Generic;

namespace QBank.Model
{
    public interface IAccountRepository
    {
        IEnumerable<Account> Accounts();
        Account GetById(int id);
    }
}