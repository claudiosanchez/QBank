using System;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace iOS.Client
{
	public abstract class CustomCellBase: UITableViewCell
	{
		public static int GetHeight (){
			return 100;
		}
		protected abstract void CreateContent ();
		protected virtual void ApplyStyle ()
		{
		}

		public CustomCellBase (UITableViewCellStyle style, NSString key): base(style, key)
		{
			CreateContent ();
			ApplyStyle ();
		}
	}

	public abstract class  ModelBasedCell<T> : CustomCellBase 
		where T:class, 
		new() // TODO: Why do we need a parameterless constructor?
	{
		public abstract void Update (T source);

		public ModelBasedCell (NSString key):base(UITableViewCellStyle.Default, key)
		{
		}
	}
}
