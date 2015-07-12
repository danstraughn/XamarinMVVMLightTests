
using System;
using SDWebImage;
using Foundation;
using UIKit;
using System.Collections.Generic;
using MVVMlight.Shared.Models;

namespace MVVMlight.iOS
{
	public partial class TableViewController : UIViewController
	{
		public TableViewController () : base ("TableViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		void SetupTableSource ()
		{
			var TableSource = new PhotoViewTableSource ();

			TableSource.PhotoCells = AppDelegate.ViewModelLocator.PhotoVM.PhotoModel;
			MainTable.Source = TableSource;
			MainTable.SeparatorStyle = UITableViewCellSeparatorStyle.None;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			SetupTableSource ();
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}

	public class PhotoViewTableSource : UITableViewSource
	{
		#region implemented abstract members of UITableViewSource

		public List<PhotoModel> PhotoCells{ get; set; }

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = new UITableViewCell (UITableViewCellStyle.Default, "PhotoCell");
			cell.ImageView.SetImage (new NSUrl (PhotoCells [indexPath.Row].thumbnailUrl), UIImage.FromBundle ("git"));
			cell.TextLabel.Text = PhotoCells [indexPath.Row].title;
			return cell;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return PhotoCells.Count;
		}

		#endregion
		
	}
}

