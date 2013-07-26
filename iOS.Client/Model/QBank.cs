using System;
using System.Collections.Generic;

namespace iOS.Client.Model
{
	public class Account
	{
		public Account ()
		{
			Transactions = new List<Transaction> ();
		}

		public double Balance { get; set; }
		public string AccountHolder { get; set; }
		public string AccountSubType { get; set;}
		public string AccountType { get; set; }
		public string NickName { get; set; }

		public string AccountNumber {
			get;
			set;
		}


		public IList<Transaction> Transactions { get; set; }
	}

	public class Transaction	
	{
		public int ReferenceNumber { set; get; }
		public double RemainingBalance { get; set; }
		public double Amount {
			get;
			set;
		}
		public string Description {
			get;
			set;
		}
		public DateTime OccuredOn {
			get;
			set;
		}
	}
}


