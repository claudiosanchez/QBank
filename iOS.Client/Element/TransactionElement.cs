using System;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using iOS.Client.Model;

namespace iOS.Client
{

	public class TransactionElement:ModelBasedElement<Transaction, TransactionCell>
	{
		public TransactionElement (Transaction model):base(model, model.Description, new TransactionCellFactory())
		{
		}

		public override float GetHeight (UITableView tableView, NSIndexPath indexPath)
		{
			return TransactionCell.GetHeight ();
		}
	}
	
}
