using Foundation;
using System;
using UIKit;

namespace Cerberus
{
    public partial class RejectedEventsViewController : UIViewController
    {
        public RejectedEventsViewController (IntPtr handle) : base (handle)
        {
			this.Title = "Rejected";
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//table = new UITableView(View.Bounds); // defaults to Plain st
			string[] tableItems = new string[] { "Event Canceled", "Fiestas de la SanSe", "Circotic"};
			TableSource source = new TableSource(tableItems, this);

			//source.NewPageEvent += HandleNewPage;
			//msgsTableVi
			rejectedEventsTable.Source = source;

			Add(rejectedEventsTable);
		}

		public void rowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//this.NavigationController.PushViewController(new ViewMessageController((System.IntPtr)0), true);
			// then open the detail view to edit it
			//var messageView = Storyboard.InstantiateViewController("messageView") as ViewMessageController;
			//detail.SetTask(this, newChore);
			//NavigationController.PushViewController(messageView, true);

			UIStoryboard board = UIStoryboard.FromName("Storyboard", null);
			UIViewController ctrl = (UIViewController)board.InstantiateViewController("ViewRejectedEvent");
			//ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizont
			this.PresentModalViewController(ctrl, true);
		}

		partial void BackButtonRejectedEvents_TouchUpInside(UIButton sender)
		{
			this.DismissViewController(true, null);
		}
	}
}