using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using iOS.Client.Model;

namespace iOS.Client
{
	public partial class Transactions : DialogViewController
	{
		IAccountsRepository _repository;
		Account _account;

		private bool IsDeposit
		{
			get { return _account.AccountType == "Deposit" || _account.AccountType == "Savings"; }
		}

		public Action<Transaction> SaveCompleted;

		public Transactions (IAccountsRepository repository, Account account) : base (UITableViewStyle.Grouped, null)
		{
			_repository = repository;
			_account = account;
		}

		public override void LoadView ()
		{
			base.LoadView ();
			CreateScreen ();
			ApplyStyle ();
		}

		public void ApplyStyle()
		{
			Root.TableView.SeparatorColor = UIColor.FromPatternImage (Resources.CellSeparator);
			Root.TableView.BackgroundView = new UIImageView (UIImage.FromBundle ("paper.png"));
		}

		private void CreateNewRoot()
		{
			Root = new RootElement ("Add Transaction");

			var section = new Section (string.Empty)
			{
				new DateElement ("Transaction Date", DateTime.Now),
				new EntryElement ("Description", "", ""),
				new EntryElement ("Amount", "", "") { KeyboardType = UIKeyboardType.DecimalPad },
			};

			Root.Add (section);

			var saveSection = new Section (string.Empty);
			var saveButton = new StyledStringElement ("Save", () =>
			{
				float amount = 0f;

				if (!float.TryParse((section.Elements[2] as EntryElement).Value, out amount))
				{
					new UIAlertView("Amount Error", "Amount must be a numeric value and is required", null, "Ok", null).Show();
					return;
				}

				var transaction = new Transaction () 
				{
					OccuredOn = (section.Elements[0] as DateElement).DateValue,
					Amount = amount,
					Description = (section.Elements[1] as EntryElement).Value,
					RemainingBalance = CalculateBalance(amount)
				};

				if (IsDeposit)
					_repository.ProcessDeposit(_account, transaction);
				else
					_repository.ProcessCredit(_account, transaction);

				if (SaveCompleted != null)
					SaveCompleted(transaction);

				NavigationController.PopViewControllerAnimated(true);

			});
			saveSection.Add (saveButton);
			Root.Add (saveSection);
		}

		private double CalculateBalance(float amount)
		{
			if (IsDeposit)
				return _account.Balance + amount;
			else
			{
				if (_account.Balance > 0)
					return _account.Balance - amount;
				else
					return _account.Balance + amount;
			}
		}

		private void CreateScreen ()
		{
			NavigationItem.TitleView = new UIImageView (UIImage.FromBundle ("logo"));
			NavigationItem.LeftBarButtonItem = new UIBarButtonItem ("Back", UIBarButtonItemStyle.Done, (s, e) =>
			{
				NavigationController.PopViewControllerAnimated(true);
			});
			CreateNewRoot();
		}
	}
}
