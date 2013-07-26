using System;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace iOS.Client
{
	public abstract class ModelBasedElement<T, TCell> : Element, IElementSizing
		where T:class, new()
		where TCell: ModelBasedCell<T>

	{
		NSString skey;

		protected T Model;
		protected ModelBasedCell<T> Cell;
		IModelBasedCellFactory<T> _cellFactory;

		public ModelBasedElement (T model, string caption, IModelBasedCellFactory<T> cellFactory ) : base(caption)
		{
			_cellFactory = cellFactory;
			Model = model;
			skey = new NSString (Model.GetType().Name + "Element");
		}

		protected override NSString CellKey
		{
			get
			{
				return skey;
			}
		}

		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell = tv.DequeueReusableCell (CellKey) as ModelBasedCell<T>;

			if (cell == null){
				cell = _cellFactory.BuildCell(CellKey) as ModelBasedCell<T>;
			}

			cell.Update(this.Model);
			return cell;
		}

		public virtual float GetHeight (UITableView tableView, NSIndexPath indexPath)
		{
			return 100;
		}
	}
}

