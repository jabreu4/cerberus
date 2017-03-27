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
    [Register ("ViewUpcomingEventViewController")]
    partial class ViewUpcomingEventViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AcceptButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BackButtonUpcomingEvent { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton RejectButton { get; set; }

        [Action ("AcceptButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AcceptButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("BackButtonUpcomingEvent_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButtonUpcomingEvent_TouchUpInside (UIKit.UIButton sender);

        [Action ("RejectButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void RejectButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AcceptButton != null) {
                AcceptButton.Dispose ();
                AcceptButton = null;
            }

            if (BackButtonUpcomingEvent != null) {
                BackButtonUpcomingEvent.Dispose ();
                BackButtonUpcomingEvent = null;
            }

            if (RejectButton != null) {
                RejectButton.Dispose ();
                RejectButton = null;
            }
        }
    }
}