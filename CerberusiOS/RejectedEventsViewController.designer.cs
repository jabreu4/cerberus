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
    [Register ("RejectedEventsViewController")]
    partial class RejectedEventsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BackButtonRejectedEvents { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem Rejected { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView rejectedEventsTable { get; set; }

        [Action ("BackButtonRejectedEvents_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButtonRejectedEvents_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BackButtonRejectedEvents != null) {
                BackButtonRejectedEvents.Dispose ();
                BackButtonRejectedEvents = null;
            }

            if (Rejected != null) {
                Rejected.Dispose ();
                Rejected = null;
            }

            if (rejectedEventsTable != null) {
                rejectedEventsTable.Dispose ();
                rejectedEventsTable = null;
            }
        }
    }
}