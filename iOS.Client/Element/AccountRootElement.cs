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

	public AccountRootElement (Account account):base(account.AccountNumber)
	{
		_account = account;
	}
	 
}
