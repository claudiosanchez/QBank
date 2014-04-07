using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IAccountsRepository
    {
        Account GetByAccountNumber(string accountNumber);
        IEnumerable<Account> GetAccountByCustomerId(int id);
    }
}
