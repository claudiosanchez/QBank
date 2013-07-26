using System;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using iOS.Client.Model;

namespace iOS.Client
{
	public class TransactionCellFactory: IModelBasedCellFactory<Transaction>
	{
		public ModelBasedCell<Transaction> BuildCell(NSString key)
		{
			return new TransactionCell (key);
		}
	}
	
}
