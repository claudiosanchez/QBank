using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Transaction
    {
        public int ReferenceNumber { set; get; }
        public double RemainingBalance { get; set; }
        public double Amount
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public DateTime OccuredOn
        {
            get;
            set;
        }
    }
}
