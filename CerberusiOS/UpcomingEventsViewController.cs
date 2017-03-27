using Foundation;
using System;
using UIKit;

namespace Cerberus
{
    public partial class UpcomingEventsViewController : UIViewController
    {
        public UpcomingEventsViewController (IntPtr handle) : base (handle)
        {
			this.Title = "Upcoming";
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//table = new UITableView(View.Bounds); // defaults to Plain sty
			string[] tableItems = new string[] { "Pelea Tito Trinidad", "Ricky Martin Tour", "Media Milla" };
			TableSource source = new TableSource(tableItems, this);

			//source.NewPageEvent += HandleNewPage;
			//msgsTableVie
			upcomingEventsTable.Source = source;

			Add(upcomingEventsTable);
		}

		public void rowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//this.NavigationController.PushViewController(new ViewMessageController((System.IntPtr)0), true);
			// then open the detail view to edit it
			//var messageView = Storyboard.InstantiateViewController("messageView") as ViewMessageController;
			//detail.SetTask(this, newChore);
			//NavigationController.PushViewController(messageView, true);

			UIStoryboard board = UIStoryboard.FromName("Storyboard", null);
			UIViewController ctrl = (UIViewController)board.InstantiateViewController("ViewUpcomingEvent");
			//ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
			this.PresentModalViewController(ctrl, true);
		}

		partial void BackButtonUpcomingEvents_TouchUpInside(UIButton sender)
		{
			this.DismissViewController(true, null);
		}
	}
}