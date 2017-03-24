using Foundation;
using System;
using UIKit;

namespace Cerberus
{
    public partial class LoginScreenViewController : UIViewController
    {
        public LoginScreenViewController (IntPtr handle) : base (handle)
        {
        }
   	public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib

			// open password input keyboard when returning
			emailInputField.ShouldReturn = (textField) =>
			{
				passwordInputField.BecomeFirstResponder();
				return true;
			};

			passwordInputField.ShouldReturn = (textField) =>
			{
				passwordInputField.ResignFirstResponder();
				LoginButton_TouchUpInside(null);
				return true;
			};

			emailInputField.ShouldReturn += TextFieldShouldReturn;
			passwordInputField.ShouldReturn += TextFieldShouldReturn;


			var g = new UITapGestureRecognizer(() => View.EndEditing(true));
			g.CancelsTouchesInView = false; //for iOS
			View.AddGestureRecognizer(g);

		}

		private bool TextFieldShouldReturn(UITextField tf)
		{
			return true;
		}

		partial void LoginButton_TouchUpInside(UIButton sender)
		{
			//throw new NotImplementedException();
		}

	}
}