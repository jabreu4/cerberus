using Foundation;
using System;
using UIKit;
 
namespace Cerberus
{
	public partial class HomeScreenViewController : UIViewController
	{

		public HomeScreenViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			JSBadgeView badgeView = new JSBadgeView()
			{
				BadgeBackgroundColor = UIColor.Red,
				BadgeStrokeColor = UIColor.Red,
				BadgeTextColor = UIColor.White,
				BadgeTextFont = UIFont.FromName("AvenirNext-Regular", 18),
				BadgeAlignment = JSBadgeView.Alignment.TopRight,
				BadgeText = "2"
			};

			inboxButton.Add(badgeView);
		}

		partial void EventsButton_TouchUpInside(UIButton sender)
		{
			//throw new NotImplementedException();
		}

		partial void HistoryButton_TouchUpInside(UIButton sender)
		{
			//throw new NotImplementedException();
		}

		partial void ProfileButton_TouchUpInside(UIButton sender)
		{
			//throw new NotImplementedException();
		}

		partial void InboxButton_TouchUpInside(UIButton sender)
		{
			//throw new NotImplementedException();
		}

		partial void InfoButton_TouchUpInside(UIButton sender)
		{
			//throw new NotImplementedException();
		}
	}
}