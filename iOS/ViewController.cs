using System;
		
using UIKit;
using GalaSoft.MvvmLight.Helpers;

namespace MVVMlight.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController (IntPtr handle) : base (handle)
		{		
		}

		public Binding TextBindingField{ get; set; }

		public Binding TextBinding{ get; set; }

		public Binding TextChangedBinding{ get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start ();
			#endif
			HideKeyboardHandling ();
			// Perform any additional setup after loading the view, typically from a nib.
			Button.AccessibilityIdentifier = "myButton";
			Button.TouchUpInside += delegate {
				var title = string.Format ("{0} clicks!", count++);
				Button.SetTitle (title, UIControlState.Normal);
			};
		}

		void HideKeyboardHandling ()
		{
			TextInput.ShouldReturn = textField => {
				textField.ResignFirstResponder ();
				return true;
			};
			var g = new UITapGestureRecognizer (() => View.EndEditing (true));
			g.CancelsTouchesInView = false;
			//for iOS5
			View.AddGestureRecognizer (g);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			lblUpdateAsYouType.Text = "Update as you type";
			lblUpdateOnReturn.Text = "Update on return";

			TextBindingField = this.SetBinding (() => AppDelegate.ViewModelLocator.Main.Text)
				.WhenSourceChanges (() => UpdateLabelOnTyping.Text = AppDelegate.ViewModelLocator.Main.Text);

			TextBinding = this.SetBinding (
				() => this.TextInput.Text)
				.UpdateSourceTrigger ("EditingChanged")
				.WhenSourceChanges (() => AppDelegate.ViewModelLocator.Main.Text = this.TextInput.Text);

			TextChangedBinding = this.SetBinding (
				() => this.TextInput.Text)
				.UpdateSourceTrigger ("EditingDidEnd")
				.WhenSourceChanges (() => {
				UpdateLabelOnReturn.Text = AppDelegate.ViewModelLocator.Main.Text;
			});

		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
