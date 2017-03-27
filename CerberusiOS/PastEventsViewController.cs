using Foundation;
using System;
using UIKit;

namespace Cerberus
{
    public partial class PastEventsViewController : UIViewController
    {
        public PastEventsViewController (IntPtr handle) : base (handle)
        {
			this.Title = "PastEventsView";
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//table = new UITableView(View.Bounds); // defaults to Plain style
			string[] tableItems = new string[] { "David Bisbal in Concert", "Marc Anthony Tour", "J Lo Tour", "Bingo de Viejitos" };
			TableSource source = new TableSource(tableItems, this);

			//source.NewPageEvent += HandleNewPage;
			//msgsTableView.
			pastEventsTable.Source = source;

			Add(pastEventsTable);
		}

		public void rowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//this.NavigationController.PushViewController(new ViewMessageController((System.IntPtr)0), true);
			// then open the detail view to edit it
			//var messageView = Storyboard.InstantiateViewController("messageView") as ViewMessageController;
			//detail.SetTask(this, newChore);
			//NavigationController.PushViewController(messageView, true);

			UIStoryboard board = UIStoryboard.FromName("Storyboard", null);
			UIViewController ctrl = (UIViewController)board.InstantiateViewController("ViewPastEvent");
			//ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
			this.PresentModalViewController(ctrl, true);
		}

		partial void PastEventsBackButton_TouchUpInside(UIButton sender)
		{
			this.DismissViewController(true, null);
		}

	}
}