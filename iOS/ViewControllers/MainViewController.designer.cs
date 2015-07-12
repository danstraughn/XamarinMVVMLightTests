// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MVVMlight.iOS
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		UIKit.UIButton ButtonHelloWorld { get; set; }

		[Outlet]
		UIKit.UIButton ButtonMoveNext { get; set; }

		[Outlet]
		UIKit.UILabel lblAsYouTypeDisplayResult { get; set; }

		[Outlet]
		UIKit.UILabel lblBindingAsYouType { get; set; }

		[Outlet]
		UIKit.UILabel lblBindingOnResult { get; set; }

		[Outlet]
		UIKit.UILabel lblOnEnterDisplayText { get; set; }

		[Outlet]
		UIKit.UITextField TextInput { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TextInput != null) {
				TextInput.Dispose ();
				TextInput = null;
			}

			if (lblBindingAsYouType != null) {
				lblBindingAsYouType.Dispose ();
				lblBindingAsYouType = null;
			}

			if (lblBindingOnResult != null) {
				lblBindingOnResult.Dispose ();
				lblBindingOnResult = null;
			}

			if (ButtonHelloWorld != null) {
				ButtonHelloWorld.Dispose ();
				ButtonHelloWorld = null;
			}

			if (ButtonMoveNext != null) {
				ButtonMoveNext.Dispose ();
				ButtonMoveNext = null;
			}

			if (lblAsYouTypeDisplayResult != null) {
				lblAsYouTypeDisplayResult.Dispose ();
				lblAsYouTypeDisplayResult = null;
			}

			if (lblOnEnterDisplayText != null) {
				lblOnEnterDisplayText.Dispose ();
				lblOnEnterDisplayText = null;
			}
		}
	}
}
