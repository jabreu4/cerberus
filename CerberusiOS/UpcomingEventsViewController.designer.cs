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
    [Register ("UpcomingEventsViewController")]
    partial class UpcomingEventsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BackButtonUpcomingEvents { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem Upcoming { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView upcomingEventsTable { get; set; }

        [Action ("BackButtonUpcomingEvents_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButtonUpcomingEvents_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BackButtonUpcomingEvents != null) {
                BackButtonUpcomingEvents.Dispose ();
                BackButtonUpcomingEvents = null;
            }

            if (Upcoming != null) {
                Upcoming.Dispose ();
                Upcoming = null;
            }

            if (upcomingEventsTable != null) {
                upcomingEventsTable.Dispose ();
                upcomingEventsTable = null;
            }
        }
    }
}