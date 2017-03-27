using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace Cerberus
{
    public partial class InboxViewController : UIViewController
    {
		
		// declare vars
		//List<NavItemGroup> navItems = new List<NavItemGroup>();
		//NavItemTableSource tableSource;

        public InboxViewController (IntPtr handle) : base (handle)
        {
			this.Title = "InboxView";
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//table = new UITableView(View.Bounds); // defaults to Plain style
			string[] tableItems = new string[] { "Event Canceled", "Event Completed", "Review Pending", "Attendance Incomplete" };
			TableSource source = new TableSource(tableItems, this);

			//source.NewPageEvent += HandleNewPage;
			//msgsTableView.
			msgsTableView.Source = source;

			Add(msgsTableView);
		}

		public void rowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//this.NavigationController.PushViewController(new ViewMessageController((System.IntPtr)0), true);
			// then open the detail view to edit it
			//var messageView = Storyboard.InstantiateViewController("messageView") as ViewMessageController;
			//detail.SetTask(this, newChore);
			//NavigationController.PushViewController(messageView, true);

			UIStoryboard board = UIStoryboard.FromName("Storyboard", null);
			UIViewController ctrl = (UIViewController)board.InstantiateViewController("messageView");
			//ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
			this.PresentModalViewController(ctrl, true);
		}

		partial void BackButton_TouchUpInside(UIButton sender)
		{
			this.DismissModalViewController(true);
		}

	}
}