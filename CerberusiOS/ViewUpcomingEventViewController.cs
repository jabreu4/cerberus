using Foundation;
using System;
using UIKit;

namespace Cerberus
{
    public partial class ViewUpcomingEventViewController : UIViewController
    {
        public ViewUpcomingEventViewController (IntPtr handle) : base (handle)
        {
        }


		partial void BackButtonUpcomingEvent_TouchUpInside(UIButton sender)
		{
			this.DismissModalViewController(true);
		}


		partial void AcceptButton_TouchUpInside(UIButton sender)
		{
			//throw new NotImplementedException();
		}

		partial void RejectButton_TouchUpInside(UIButton sender)
		{
			//throw new NotImplementedException()
		}
	}
}