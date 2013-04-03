using System.Collections.Generic;
using System.Linq;
using QBank.Model;

namespace QBank.DataAccess
{
    public class AccountRepository : IAccountRepository
    {
        private readonly QBankContext _context;

        public AccountRepository(QBankContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> Accounts()
        {
            return _context.Accounts.AsEnumerable();
        }

        public Account GetById(int id)
        {
           return _context.Accounts.FirstOrDefault(a => a.Id == id);
        }
    }
}