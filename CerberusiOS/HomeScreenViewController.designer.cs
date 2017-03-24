// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Cerberus
{
    [Register ("HomeScreenViewController")]
    partial class HomeScreenViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton eventsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton historyButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton inboxButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton infoButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton profileButton { get; set; }

        [Action ("EventsButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EventsButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("HistoryButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void HistoryButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("InboxButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void InboxButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("InfoButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void InfoButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("ProfileButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ProfileButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (eventsButton != null) {
                eventsButton.Dispose ();
                eventsButton = null;
            }

            if (historyButton != null) {
                historyButton.Dispose ();
                historyButton = null;
            }

            if (inboxButton != null) {
                inboxButton.Dispose ();
                inboxButton = null;
            }

            if (infoButton != null) {
                infoButton.Dispose ();
                infoButton = null;
            }

            if (profileButton != null) {
                profileButton.Dispose ();
                profileButton = null;
            }
        }
    }
}