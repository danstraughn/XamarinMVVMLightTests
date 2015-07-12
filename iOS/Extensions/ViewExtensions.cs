using Foundation;
using System;
using UIKit;

namespace MVVMlight.iOS
{
	public static class ViewExtensions
	{
		#region Methods

		public static UIButton ConfigureTwoLineButtonWithStates (this UIButton button, string label)
		{
			var split = label.Split ();
           
			var normalText = new UIStringAttributes {
				Font = UIFont.SystemFontOfSize (14),
				ForegroundColor = CustomColors.Blue
                
			};
			var selectedText = new UIStringAttributes {
				Font = UIFont.SystemFontOfSize (14),
				ForegroundColor = UIColor.White                
                        
			};

			var normalTitle = new NSMutableAttributedString (label.ToUpper ());
			normalTitle.SetAttributes (normalText.Dictionary, new NSRange (0, label.Length));

			var selectedTitle = new NSMutableAttributedString (label.ToUpper ());
			selectedTitle.SetAttributes (selectedText.Dictionary, new NSRange (0, label.Length));

			button.SetAttributedTitle (normalTitle, UIControlState.Normal);
			button.SetAttributedTitle (selectedTitle, UIControlState.Selected);
			button.TitleLabel.Lines = 2;
			button.TitleLabel.TextAlignment = UITextAlignment.Center;

			return button;
		}

		public static NSDate DateTimeToNSDate (this DateTime date)
		{
			if (date.Kind == DateTimeKind.Unspecified)
				date = DateTime.SpecifyKind (date, DateTimeKind.Utc);

			return (NSDate)date;
		}

		public static UIView FindFirstResponder (this UIView view)
		{
			if (view.IsFirstResponder) {
				return view;
			}
			foreach (UIView subView in view.Subviews) {
				var firstResponder = subView.FindFirstResponder ();
				if (firstResponder != null)
					return firstResponder;
			}
			return null;
		}

		public static UIView FindSuperviewOfType (this UIView view, UIView stopAt, Type type)
		{
			if (view.Superview != null) {
				if (type.IsAssignableFrom (view.Superview.GetType ())) {
					return view.Superview;
				}

				if (view.Superview != stopAt)
					return view.Superview.FindSuperviewOfType (stopAt, type);
			}

			return null;
		}

		public static DateTime NSDateToDateTime (this NSDate date)
		{
			// NSDate has a wider range than DateTime, so clip
			// the converted date to DateTime.Min|MaxValue.
			double secs = date.SecondsSinceReferenceDate;
			if (secs < -63113904000)
				return DateTime.MinValue;
			if (secs > 252423993599)
				return DateTime.MaxValue;
			return (DateTime)date;
		}

		#endregion Methods
	}
}