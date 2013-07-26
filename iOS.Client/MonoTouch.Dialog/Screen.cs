using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace iOS.Client.MonoTouch.Dialog
{
   
	public class Screen : DialogViewController
    {
        private readonly string _filename;

        public Screen(RootElement root, string filename)
            : base(root)
        {
            _filename = filename;
        }

        public override void LoadView()
        {
            base.LoadView();
        }
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var bounds = View.Bounds;
			var paper = UIImage.FromBundle(_filename);
			var paperView = new UIView(bounds)
			{
				BackgroundColor = UIColor.FromPatternImage(paper)
			};

			Root.TableView.AddSubview(paperView);
			Root.TableView.SendSubviewToBack(paperView);
			Root.TableView.ScrollEnabled = false;
		}

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            var bounds = View.Bounds;
            var paper = UIImage.FromBundle(_filename);
            var paperView = new UIView(bounds)
            {
                BackgroundColor = UIColor.FromPatternImage(paper)
            };

            Root.TableView.AddSubview(paperView);
            Root.TableView.SendSubviewToBack(paperView);

        }
    }
}