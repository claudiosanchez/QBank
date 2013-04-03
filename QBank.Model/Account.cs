using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QBank.Model
{
    public class Account
    {
        public double Balance { get; set; }
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string AccountHolder { get; set; }
    }
}
