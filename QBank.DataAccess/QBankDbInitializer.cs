using System.Data.Entity;
using QBank.Model;

namespace QBank.DataAccess
{
    public class QBankDbInitializer : DropCreateDatabaseAlways<QBankContext>
    {
        protected override void Seed(QBankContext context)
        {
            var account1 = new Account {AccountNumber = "001-012345", AccountType = "Checking", Balance = 153.04, AccountHolder = "Claudio Sanchez"};
            context.Accounts.Add(account1);
        }
    }
}