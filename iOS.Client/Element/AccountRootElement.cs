using MonoTouch.Dialog;
using System.Collections.Generic;
using System;
using iOS.Client.Model;
using MonoTouch.UIKit;
using iOS.Client;
using MonoTouch.Foundation;
using System.Linq;
using System.Drawing;

public class AccountRootElement : RootElement, IElementSizing
{
	public float GetHeight (UITableView tableView, NSIndexPath indexPath)
	{
		return AccountCell.GetHeight ();
	}

	NSString _cellKey = new NSString("AccountCell");
	Account _account;
	bool _showIndicator;
	bool _createAddButton;
	private UIBarButtonItem _addButton;
	IAccountsRepository _repository;

	public UINavigationController NavigationController { get; set; }

	protected override NSString CellKey {get {return _cellKey;}}

	public override MonoTouch.UIKit.UITableViewCell GetCell (MonoTouch.UIKit.UITableView tv)
	{
		var factory = new AccountCellFactory () { ShowIndicator = _showIndicator };
		var cell = factory.BuildCell (CellKey); 

		cell.Update (_account);
		return cell;
	}

	public AccountRootElement (Account account, bool showIndicator, Func<RootElement,UIViewController> createOnSelected) : base(account.AccountNumber,createOnSelected )
	{
		this._showIndicator = showIndicator;
		_account = account;
	}   

	public AccountRootElement (IAccountsRepository accountRepo, Account account, bool showIndicator, Func<RootElement,UIViewController> createOnSelected, bool createAddButton) : base(account.AccountNumber,createOnSelected )
	{
		this._showIndicator = showIndicator;
		_account = account;
		_createAddButton = createAddButton;
		_repository = accountRepo;
	}   

	public AccountRootElement (Account account):base(account.AccountNumber)
	{
		_account = account;
	}
	 
	protected override void PrepareDialogViewController (UIViewController dvc)
	{
		base.PrepareDialogViewController (dvc);

		if (!_createAddButton)
			return;

		accountRoot = (dvc as DialogViewController).Root;

		_addButton = new UIBarButtonItem (UIBarButtonSystemItem.Add, AddTransaction);
		dvc.NavigationItem.RightBarButtonItem = _addButton;
	}

	RootElement accountRoot;

	private void AddTransaction(object sender, EventArgs e)
	{
		var transactionView = new Transactions (_repository, _account);
		transactionView.SaveCompleted += (transaction) => 
		{
			// gets the section that contains the transactions and adds
			//  new transaction element to the section
			var section = accountRoot[1];
			section.Add(new TransactionElement(transaction));

			// updates the account section to updated the account balance.
			var accountSection = new Section() { new AccountElement(_account, false) };
			accountRoot.RemoveAt(0);
			accountRoot.Insert(0, accountSection);
		};

		NavigationController.PushViewController (transactionView, true);
	}
}
