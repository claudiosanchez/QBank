using System.Data.Entity;
using QBank.Model;

namespace QBank.DataAccess
{
    public class QBankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}