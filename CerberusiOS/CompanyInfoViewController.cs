using Foundation;
using System;
using UIKit;

namespace Cerberus
{
    public partial class CompanyInfoViewController : UIViewController
    {
        public CompanyInfoViewController (IntPtr handle) : base (handle)
        {
        }

		partial void InfoBackButton_TouchUpInside(UIButton sender)
		{
			this.DismissModalViewController(true);
		}

		partial void CallCompanyButton_TouchUpInside(UIButton sender)
		{
			//throw new NotImplementedException();
		}
	}
}