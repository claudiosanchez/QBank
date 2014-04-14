using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {

        private AccountsRepository repository;

        public AccountViewModel()
        {
            repository = new AccountsRepository();
        }

        public List<Account> AccountItems()
        {
            return repository.GetAccountByCustomerId().ToList();
        }

        public Account AccountItem(String ID)
        {
            return repository.GetByAccountNumber(ID);
        }
    }
}
