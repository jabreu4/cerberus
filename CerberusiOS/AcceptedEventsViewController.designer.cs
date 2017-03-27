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
    [Register ("AcceptedEventsViewController")]
    partial class AcceptedEventsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem Accepted { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView acceptedEventsTable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BackButtonAcceptedEvents { get; set; }

        [Action ("BackButtonAcceptedEvents_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButtonAcceptedEvents_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Accepted != null) {
                Accepted.Dispose ();
                Accepted = null;
            }

            if (acceptedEventsTable != null) {
                acceptedEventsTable.Dispose ();
                acceptedEventsTable = null;
            }

            if (BackButtonAcceptedEvents != null) {
                BackButtonAcceptedEvents.Dispose ();
                BackButtonAcceptedEvents = null;
            }
        }
    }
}