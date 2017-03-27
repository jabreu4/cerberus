using Foundation;
using System;
using UIKit;

namespace Cerberus
{
    public partial class ViewRejectedEventViewController : UIViewController
    {
        public ViewRejectedEventViewController (IntPtr handle) : base (handle)
        {
        }

		partial void BackButtonRejectedEvent_TouchUpInside(UIButton sender)
		{
			this.DismissModalViewController(true);
		}
	}
}