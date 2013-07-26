using System;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using iOS.Client.Model;
using Framework.iOS;
using System.Drawing;

namespace iOS.Client
{

	public class AccountCell: ModelBasedCell<Account>
	{
		bool _showIndicator;

		public AccountCell (NSString key, bool showIndicator ): base(key)
		{
			_showIndicator = showIndicator;
			ApplyStyle ();
		}

		UIImageView AccountIcon;
		UILabel AccountNumberLabel, BalanceLabel, AccountSubTypeLabel;

		public new static int GetHeight ()
		{
			return 66;
		}
		public override void Update (Account source)
		{
			AccountNumberLabel.Text = source.AccountType;
			AccountSubTypeLabel.Text = source.AccountSubType;
			BalanceLabel.Text = string.Format ("{0:C}", source.Balance);
		}

		protected override void ApplyStyle ()
		{
			if (_showIndicator) {
				Accessory = UITableViewCellAccessory.DisclosureIndicator;
				SelectionStyle = UITableViewCellSelectionStyle.None;
			}
		}

		protected override void CreateContent ()
		{

			var topMargin = 5;
			var leftMargin = 5;
			AccountIcon = new UIImageView (UIImage.FromBundle ("$.PNG"));
			AccountIcon.Frame = new RectangleF (0+topMargin, 0+leftMargin, AccountIcon.Frame.Size.Width, AccountIcon.Frame.Size.Height);
			int labelXGuide = 0 + (int)AccountIcon.Frame.Size.Width + 10;
							
			AccountNumberLabel = new UILabel () {
				Font = Fonts.BoldPrimaryFont(14f),
				TextColor = UIColor.DarkGray,
				TextAlignment = UITextAlignment.Left,
				Lines = 1,
				BackgroundColor = UIColor.Clear,
				Frame = new RectangleF (labelXGuide, 15, ContentView.Frame.Width-100, 20)
			};
		
			AccountSubTypeLabel = new UILabel () {
				Lines = 1,
				Font = Fonts.PrimaryFont(10f),
				TextColor = UIColor.DarkGray,
				Frame = new RectangleF (labelXGuide, 30, ContentView.Frame.Width-100, 15),
				BackgroundColor = UIColor.Clear
			};

			BalanceLabel = new UILabel () {
				Lines = 1,
				Font = UIFont.BoldSystemFontOfSize (16f),
				TextColor = "6dbc61".ToUIColor(),
				Frame = new RectangleF (labelXGuide + 120, (GetHeight()- 16)/2, ContentView.Frame.Width-100, 15),
				BackgroundColor = UIColor.Clear
			};

			ContentView.AddSubviews (AccountNumberLabel, AccountSubTypeLabel, BalanceLabel, AccountIcon);
		}
	}
}
