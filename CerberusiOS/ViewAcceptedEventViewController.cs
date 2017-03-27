using Foundation;
using System;
using UIKit;

namespace Cerberus
{
    public partial class ViewAcceptedEventViewController : UIViewController
    {
        public ViewAcceptedEventViewController (IntPtr handle) : base (handle)
        {
        }

		partial void BackButtonAcceptedEvent_TouchUpInside(UIButton sender)
		{
			this.DismissModalViewController(true);
		}
	}
}