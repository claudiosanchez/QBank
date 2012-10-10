using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFramework.Patterns;
using QBank.Model;

namespace QBank.DataAccess
{
    public class AccountRepository: Repository<Account>
    {
        private readonly IObjectSetFactory _objectSetFactory;

        public AccountRepository(IObjectSetFactory objectSetFactory) : base(objectSetFactory)
        {
            _objectSetFactory = objectSetFactory;
        }
    }
}
