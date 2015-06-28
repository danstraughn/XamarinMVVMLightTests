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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		public UIKit.UIButton Button { get; set; }

		[Outlet]
		public UIKit.UILabel lblUpdateAsYouType { get; set; }

		[Outlet]
		public UIKit.UILabel lblUpdateOnReturn { get; set; }

		[Outlet]
		public UIKit.UITableView tblUpdate { get; set; }

		[Outlet]
		public UIKit.UITextField TextInput { get; set; }

		[Outlet]
		public UIKit.UILabel UpdateLabelOnReturn { get; set; }

		[Outlet]
		public UIKit.UILabel UpdateLabelOnTyping { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Button != null) {
				Button.Dispose ();
				Button = null;
			}

			if (TextInput != null) {
				TextInput.Dispose ();
				TextInput = null;
			}

			if (lblUpdateAsYouType != null) {
				lblUpdateAsYouType.Dispose ();
				lblUpdateAsYouType = null;
			}

			if (UpdateLabelOnTyping != null) {
				UpdateLabelOnTyping.Dispose ();
				UpdateLabelOnTyping = null;
			}

			if (UpdateLabelOnReturn != null) {
				UpdateLabelOnReturn.Dispose ();
				UpdateLabelOnReturn = null;
			}

			if (lblUpdateOnReturn != null) {
				lblUpdateOnReturn.Dispose ();
				lblUpdateOnReturn = null;
			}

			if (tblUpdate != null) {
				tblUpdate.Dispose ();
				tblUpdate = null;
			}
		}
	}
}
