using System;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using iOS.Client.Model;
using Framework.iOS;
using System.Drawing;

namespace iOS.Client
{

	public class TransactionCell:ModelBasedCell<Transaction>
	{
		UILabel DescriptionLabel, BalanceLabel, DateLabel, RemainingBalanceLabel;

		public TransactionCell (NSString key): base(key)
		{
		}
		public override void Update (Transaction source)
		{
			DescriptionLabel.Text = source.Description;
			BalanceLabel.Text= source.Amount.ToString ("C");
			DateLabel.Text = string.Format ("{0:MM/dd hh:mm tt}", source.OccuredOn);
			RemainingBalanceLabel.Text = source.RemainingBalance.ToString ("C");

		}

		public new static int GetHeight ()
		{
			return 50;
		}

		protected override void ApplyStyle ()
		{
			SelectionStyle = UITableViewCellSelectionStyle.None;
			Accessory = UITableViewCellAccessory.DisclosureIndicator;
		}

		protected override void CreateContent ()
		{
			var topMargin = 5;
			var leftMargin = 5;
			int labelXGuide = 5;

			DescriptionLabel = new UILabel () {
				Font = Fonts.BoldPrimaryFont(14f),
				TextColor = UIColor.DarkGray,
				TextAlignment = UITextAlignment.Left,
				Lines = 1,
				BackgroundColor = UIColor.Clear,
				Frame = new RectangleF (labelXGuide, 0 + topMargin, ContentView.Frame.Width-100, 20)
			};

			DateLabel = new UILabel () {
				Lines = 1,
				Font = Fonts.PrimaryFont(10f),
				TextColor = UIColor.DarkGray,
				Frame = new RectangleF (labelXGuide, 20 + topMargin, ContentView.Frame.Width-100, 15),
				BackgroundColor = UIColor.Clear
			};

			BalanceLabel = new UILabel () {
				Lines = 1,
				Font = UIFont.BoldSystemFontOfSize (14f),
				TextColor = "6dbc61".ToUIColor(), 
				TextAlignment = UITextAlignment.Right,
				Frame = new RectangleF (labelXGuide + 50,0 + topMargin, ContentView.Frame.Width-100, 20),
				BackgroundColor = UIColor.Clear
			};

			RemainingBalanceLabel = new UILabel () {
				Lines = 1,
				Font = UIFont.BoldSystemFontOfSize (14f),
				TextColor = UIColor.DarkGray, 
				TextAlignment = UITextAlignment.Right,
				Frame = new RectangleF (labelXGuide + 50,20 + topMargin, ContentView.Frame.Width-100, 20),
				BackgroundColor = UIColor.Clear
			};

			ContentView.AddSubviews (DescriptionLabel, DateLabel, BalanceLabel, RemainingBalanceLabel);
		}
	}
	
}
