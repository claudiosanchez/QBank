using MonoTouch.Dialog;
using System.Collections.Generic;
using System;
using iOS.Client.Model;
using MonoTouch.UIKit;
using iOS.Client;
using MonoTouch.Foundation;
using System.Linq;
using System.Drawing;



public class Accounts: DialogViewController
{
	IAccountsRepository repository;

	public Accounts (UIWindow window, IAccountsRepository repository): base(new RootElement(""),true)
	{
		this.repository = repository;
		Style = UITableViewStyle.Plain;
		EnableSearch = true;

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

	UIViewController StyleTransactionsScreen (RootElement arg)
	{
		var dvc = new DialogViewController (UITableViewStyle.Plain, arg,true);
		dvc.LoadView ();
		dvc.Root.TableView.SeparatorColor = UIColor.FromPatternImage (Resources.CellSeparator);
		dvc.Root.TableView.BackgroundView = new UIImageView (UIImage.FromBundle ("paper.png"));

		return dvc;
	}

	RootElement CreateNewRoot(IEnumerable<IGrouping<string, Account>> accountsByGroup)
	{
		var root = new RootElement ("My Accounts");
			
		var sections = from _group 
			in accountsByGroup 
			select new Section () {  //  i.e.: Deposits 
			from account in _group select
			new AccountRootElement(accountRepo: repository, account: account, showIndicator: true, createOnSelected: StyleTransactionsScreen, createAddButton: true) 
					{
						new Section()  // Section for Account Header 
						{
							new AccountElement(account, false) as Element,
						},
						new Section("Transactions")  // Section for Transactions 
						{
						//	account.Transactions.Select(tx=> new StyledStringElement(tx.Description, string.Format (@"{0:M/d hh:mm tt} {1:C}",tx.OccuredOn, tx.Amount),UITableViewCellStyle.Subtitle) as Element),
							account.Transactions.Select(tx=> new TransactionElement(tx) as Element),

						},

				} as Element
		};

		root.Add (sections);

		return root;
	}


	void CreateScreen ()
	{
		NavigationItem.TitleView = new UIImageView (UIImage.FromBundle ("logo"));

		var model = repository.GetAccountByCustomerId (0);

		IEnumerable<IGrouping<string, Account>> accountsByGroup;
		accountsByGroup = model.GroupBy (g => g.AccountType);

		Root = CreateNewRoot(accountsByGroup);

		for (int i = 0; i < Root.Count; i++)
		{
			var section = Root [i];
			var accountRootElement = (AccountRootElement)section.Elements [0];
			accountRootElement.NavigationController = this.NavigationController;
		}
	}
}
