using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Account
    {
        public Account()
        {
            Transactions = new List<Transaction>();
        }

        public double Balance { get; set; }
        public string AccountHolder { get; set; }
        public string AccountSubType { get; set; }
        public string AccountType { get; set; }
        public string NickName { get; set; }

        public string AccountNumber
        {
            get;
            set;
        }


        public IList<Transaction> Transactions { get; set; }
    }

}
