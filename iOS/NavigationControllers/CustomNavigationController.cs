using UIKit;

namespace MVVMlight.iOS
{
	public partial class CustomNavigationController : UINavigationController
	{
		public CustomNavigationController (UIViewController ctrl)
			: base (ctrl)
		{
			UINavigationBar.Appearance.SetTitleTextAttributes (new UITextAttributes {
				TextColor = UIColor.White
			});
			UIApplication.SharedApplication.SetStatusBarStyle (UIStatusBarStyle.LightContent, false);
			NavigationBar.TintColor = UIColor.White;
			NavigationBar.BarTintColor = CustomColors.AwesomeBlue;
			NavigationBar.Translucent = false;
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}