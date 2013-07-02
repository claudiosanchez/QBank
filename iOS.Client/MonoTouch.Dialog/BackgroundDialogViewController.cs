using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace iOS.Client.MonoTouch.Dialog
{
    public class BackgroundDialogViewController : DialogViewController {
        private readonly string _filename;

        public BackgroundDialogViewController (RootElement root, string filename) 
            : base (root)
        {
            _filename = filename;
        }

        public override void LoadView () {
            base.LoadView ();
            this.TableView.BackgroundColor = UIColor.Clear;
            var background = UIImage.FromBundle(_filename);
            ParentViewController.View.BackgroundColor = UIColor.FromPatternImage(background);
        }
    }
}