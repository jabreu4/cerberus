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
    [Register ("PastEventsViewController")]
    partial class PastEventsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PastEventsBackButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView pastEventsTable { get; set; }

        [Action ("PastEventsBackButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PastEventsBackButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (PastEventsBackButton != null) {
                PastEventsBackButton.Dispose ();
                PastEventsBackButton = null;
            }

            if (pastEventsTable != null) {
                pastEventsTable.Dispose ();
                pastEventsTable = null;
            }
        }
    }
}