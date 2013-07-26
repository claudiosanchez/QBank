using System;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace iOS.Client
{

	public interface IModelBasedCellFactory<TModel> where TModel:class, new()
	{
		ModelBasedCell<TModel> BuildCell(NSString key);
	}
	
}
