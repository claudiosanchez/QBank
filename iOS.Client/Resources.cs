using System;
using MonoTouch.UIKit;
using Framework.iOS;

namespace iOS.Client
{
	public static class Resources
	{
		public static UIImage NavBarBackground = UIImage.FromBundle("navbar.png");
		public static UIImage CellSeparator = UIImage.FromBundle("cellseparator.png");
	}

	public static class Colors
	{
		public static UIColor QBankGreen = "6dbc61".ToUIColor();
		//public static UIColor ProjectGrey = "979797".ToUIColor();
		//public static UIColor TableBackgroundGrey = "e5e8e3".ToUIColor();
		public static UIColor SecondaryTextColor = UIColor.LightGray;
		public static UIColor PrimaryTextColor = UIColor.Black;
	}

	public static class Fonts 
	{
		public static UIFont PrimaryFont(float size)
		{
			return UIFont.SystemFontOfSize(size);
		}

		public static UIFont BoldPrimaryFont(float size)
		{
			return UIFont.BoldSystemFontOfSize(size);
		}
	}
}

