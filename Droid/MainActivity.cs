
using Android.App;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;

namespace MVVMlight.Droid
{
	
	public partial class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};
			TxtNewText.KeyPress += (sender, e) => {
			};
			TxtNewText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
			};
			this.SetBinding (() => TxtNewText.Text, () => MainApp.ViewModelLocator.Main.Text, BindingMode.OneWay);
			this.SetBinding (() => MainApp.ViewModelLocator.Main.Text, () => LblResult.Text, BindingMode.OneWay);
			this.SetBinding (() => MainApp.ViewModelLocator.Main.Text, () => LblAutoUpdate.Text, BindingMode.OneWay);
//			this.SetBinding (() => MainApp.ViewModelLocator.Main.Text)
//				.WhenSourceChanges (() => LblAutoUpdate.Text = MainApp.ViewModelLocator.Main.Text);
//
//			this.SetBinding (
//				() => this.TxtNewText.Text)
//				.UpdateSourceTrigger ("KeyPress")
//				.WhenSourceChanges (() => MainApp.ViewModelLocator.Main.Text = this.TxtNewText.Text);
//
//			this.SetBinding (
//				() => this.TxtNewText.Text)
//				.UpdateSourceTrigger ("TextChanged")
//				.WhenSourceChanges (() => {
//				LblResult.Text = MainApp.ViewModelLocator.Main.Text;
//			});
			
		}
	}
}


