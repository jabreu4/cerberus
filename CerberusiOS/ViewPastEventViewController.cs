using Foundation;
using System;
using UIKit;

namespace Cerberus
{
    public partial class ViewPastEventViewController : UIViewController
    {
        public ViewPastEventViewController (IntPtr handle) : base (handle)
        {
        }

		partial void UIButton3381_TouchUpInside(UIButton sender)
		{
			this.DismissModalViewController(true);
		}
	}
}