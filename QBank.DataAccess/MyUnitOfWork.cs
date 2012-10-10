using System.Data.Entity;
using EntityFramework.Patterns;
using QBank.Model;

namespace QBank.DataAccess
{
    public class MyUnitOfWork : UnitOfWork
    {
        private readonly DbContext _context;

        public MyUnitOfWork(QBankContext context) : base(new DbContextAdapter(context))
        {
            _context = context;
            var repo = new AccountRepository(new DbContextAdapter(_context));
            AccountRepository = repo;
        }

        public Repository<Account> AccountRepository { get; set; }
    }
}