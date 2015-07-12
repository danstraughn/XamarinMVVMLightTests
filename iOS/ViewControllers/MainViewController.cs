
using System;

using Foundation;
using UIKit;
using GalaSoft.MvvmLight.Helpers;
using MVVMlight.Shared.Service;
using System.Collections.Generic;
using MVVMlight.Shared.Models;


namespace MVVMlight.iOS
{
	public partial class MainViewController : UIViewController
	{
		public MainViewController () : base ("MainViewController", null)
		{
		}

		int count = 1;

		public Binding TextBindingField{ get; set; }

		public Binding TextBinding{ get; set; }

		public Binding TextChangedBinding{ get; set; }


		public List<PhotoModel> Photos { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start ();
			#endif
			HideKeyboardHandling ();
			// Perform any additional setup after loading the view, typically from a nib.
			ButtonHelloWorld.AccessibilityIdentifier = "myButton";
			ButtonHelloWorld.TouchUpInside += delegate {
				var title = string.Format ("{0} clicks!", count++);
				ButtonHelloWorld.SetTitle (title, UIControlState.Normal);
			};
			GetPhotosForTransistion ();
		}

		void HideKeyboardHandling ()
		{
			TextInput.ShouldReturn = textField => {
				textField.ResignFirstResponder ();
				return true;
			};
			var g = new UITapGestureRecognizer (() => View.EndEditing (true));
			g.CancelsTouchesInView = false;
			View.AddGestureRecognizer (g);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			lblBindingAsYouType.Text = "Update as you type";
			lblBindingOnResult.Text = "Update on return";

			TextBindingField = this.SetBinding (() => AppDelegate.ViewModelLocator.Main.BindableText)
				.WhenSourceChanges (() => lblAsYouTypeDisplayResult.Text = AppDelegate.ViewModelLocator.Main.BindableText);

			TextBinding = this.SetBinding (
				() => this.TextInput.Text)
				.UpdateSourceTrigger ("EditingChanged")
				.WhenSourceChanges (() => AppDelegate.ViewModelLocator.Main.BindableText = this.TextInput.Text);

			TextChangedBinding = this.SetBinding (
				() => this.TextInput.Text)
				.UpdateSourceTrigger ("EditingDidEnd")
				.WhenSourceChanges (() => {
				lblOnEnterDisplayText.Text = AppDelegate.ViewModelLocator.Main.BindableText;
			});
			ButtonMoveNext.TouchUpInside += ButtonMoveNext_TouchUpInside;

		}

		void ButtonMoveNext_TouchUpInside (object sender, EventArgs e)
		{
			var TableViewController = new TableViewController ();
			this.NavigationController.PushViewController (TableViewController, true);
		}

		async void GetPhotosForTransistion ()
		{
			AppDelegate.ViewModelLocator.PhotoVM.PhotoModel = await JsonService.GetPhotos ();
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			TextBindingField = null;
			TextBinding = null;
			TextChangedBinding = null;
			ButtonMoveNext.TouchUpInside -= ButtonMoveNext_TouchUpInside;
		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}

