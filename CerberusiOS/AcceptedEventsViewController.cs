using Foundation;
using System;
using UIKit;

namespace Cerberus
{
    public partial class AcceptedEventsViewController : UIViewController
    {
        public AcceptedEventsViewController (IntPtr handle) : base (handle)
        {
			this.Title = "Accepted";
        }

		partial void BackButtonAcceptedEvents_TouchUpInside(UIButton sender)
		{
			this.DismissViewController(true, null);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//table = new UITableView(View.Bounds); // defaults to Plain styl
			string[] tableItems = new string[] { "Asamblea UPR", "Show de Motoras", "Daddy Yankee Concert" };
			TableSource source = new TableSource(tableItems, this);

			//source.NewPageEvent += HandleNewPage;
			//msgsTableView
			acceptedEventsTable.Source = source;

			Add(acceptedEventsTable);
		}

		public void rowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//this.NavigationController.PushViewController(new ViewMessageController((System.IntPtr)0), true);
			// then open the detail view to edit it
			//var messageView = Storyboard.InstantiateViewController("messageView") as ViewMessageController;
			//detail.SetTask(this, newChore);
			//NavigationController.PushViewController(messageView, true);

			UIStoryboard board = UIStoryboard.FromName("Storyboard", null);
			UIViewController ctrl = (UIViewController)board.InstantiateViewController("ViewAcceptedEvent");
			//ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal
			this.PresentModalViewController(ctrl, true);
		}
	}
}