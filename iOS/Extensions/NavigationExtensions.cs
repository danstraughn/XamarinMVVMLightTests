using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace MVVMlight.iOS
{
	public static class NavigationExtensions
	{
		#region Methods

		//Allows a UINavigationController to push using a custom animation transition
		public static void PushControllerWithTransition (this UINavigationController
                target, UIViewController controllerToPush,
		                                                      UIViewAnimationOptions transition)
		{
			UIView.Transition (target.View, 0.75d, transition, delegate() {
				target.PushViewController (controllerToPush, false);
			}, null);
		}

		public static void SetupNavigationTitle (this UINavigationItem NavigationItem, string title, string subTitle = null)
		{
			try {
				if (subTitle == null) {
					var titleAttributes = new UIStringAttributes {
						Font = UIFont.BoldSystemFontOfSize (17),
						ForegroundColor = UIColor.White
					};
					var fullTitle = new NSMutableAttributedString (string.Format (title));
					fullTitle.SetAttributes (titleAttributes.Dictionary, new NSRange (0, title.Length));

					UILabel label = new UILabel (new CGRect (220, 0, 180, 44));
					label.AttributedText = fullTitle;
					label.Lines = 1;
					label.TextAlignment = UITextAlignment.Center;
					NavigationItem.TitleView = label;
					return;
				} else {
					var titleAttributes = new UIStringAttributes {
						Font = UIFont.BoldSystemFontOfSize (17),
						ForegroundColor = UIColor.White
					};
					var subtitleAttributes = new UIStringAttributes {
						Font = UIFont.SystemFontOfSize (12),
						ForegroundColor = UIColor.White
					};
					var fullTitle = new NSMutableAttributedString (string.Format (title + "\n{0}", subTitle));
					fullTitle.SetAttributes (titleAttributes.Dictionary, new NSRange (0, title.Length));
					fullTitle.SetAttributes (subtitleAttributes.Dictionary, new NSRange (title.Length + 1, subTitle.Length));

					UILabel label = new UILabel (new CGRect (220, 0, 180, 44));
					label.AttributedText = fullTitle;
					label.Lines = 2;
					label.TextAlignment = UITextAlignment.Center;
					NavigationItem.TitleView = label;
					return;
				}
			} catch (Exception ex) {
				Console.WriteLine (ex);
			}
		}

		#endregion Methods
	}
}