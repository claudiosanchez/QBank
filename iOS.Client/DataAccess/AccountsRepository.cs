using System;
using iOS.Client.Model;
using System.Collections.Generic;

namespace iOS.Client
{
	public interface IAccountsRepository
	{
		Account GetByAccountNumber(string accountNumber);
		IEnumerable<Account> GetAccountByCustomerId(int id);
	}

	public class AccountsRepository: IAccountsRepository
	{
		IList<Account> seedAccounts = new List<Account> ();

		#region IAccountsRepository implementation

		public Account GetByAccountNumber (string accountNumber)
		{
			throw new NotImplementedException ();
		}

		public IEnumerable<Account> GetAccountByCustomerId (int id)
		{
			return seedAccounts;
		}

		#endregion

		public AccountsRepository ()
		{
			var cc = new Account {
				Balance=-2000.50,
				AccountHolder ="Lorenzo Martinez",
				AccountNumber="1-234",
				AccountSubType = "CNN Visa",
				NickName ="My Credit Card",
				AccountType = "Credit",
				Transactions = { new Transaction{OccuredOn = new DateTime(2013,07,15,15,0,0),Amount=1050,Description="CodeCampSDQ 3.0"} }
			};

			var codecampsdq40 = new Account {
				Balance=500000.50,
				AccountHolder ="Lorenzo Martinez",
				AccountNumber="1-0000034",
				AccountSubType = "CodeCampSDQ",
				NickName ="CodeCampSDQ",
				AccountType = "Savings",
				Transactions = { new Transaction{OccuredOn = new DateTime(2013,07,20,17,0,0),Amount=500000,Description="EDWARD"} }
			};


			var checking = new Account {
				Balance=27940.50,
				AccountHolder ="Lorenzo Martinez",
				AccountNumber="1-234",
				AccountSubType = "Checking",
				NickName = "Free Checking",
				AccountType = "Deposit",
				Transactions = new List<Transaction> () {

					new Transaction () {
						OccuredOn = new DateTime (2013, 07, 18, 23, 01, 0),
						Amount = 260,
						RemainingBalance = 27940.50-260,
						Description = "Joaquin Pierna"
					},
					new Transaction () {
						OccuredOn = new DateTime (2013, 07, 18, 23, 16, 0),
						Amount = 758.60,
						Description = "Drink2Go Tiradentes"
					},
					new Transaction () {
						OccuredOn = new DateTime (2013, 07, 19, 3, 01, 0),
						Amount = 4000,
						Description = "Bomba Shell, Churchill #399"
					},
					new Transaction () {
						OccuredOn = new DateTime (2013, 07, 19, 3, 40, 0),
						Amount = 500,
						Description = "Retiro ATM @ Barra Payan Jr."
					}
				}
			}; 

			this.seedAccounts.Add (checking);
			this.seedAccounts.Add (cc);
			this.seedAccounts.Add (codecampsdq40);
	
		}
	
	}
}

