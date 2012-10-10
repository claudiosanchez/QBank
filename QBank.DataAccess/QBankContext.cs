using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using QBank.Model;

namespace QBank.DataAccess
{
    public class QBankContext: DbContext 
    {
        public  DbSet<Account> Accounts { get; set; }
    }
}
