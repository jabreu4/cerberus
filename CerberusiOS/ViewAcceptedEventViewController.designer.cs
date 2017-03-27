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
    [Register ("ViewAcceptedEventViewController")]
    partial class ViewAcceptedEventViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BackButtonAcceptedEvent { get; set; }

        [Action ("BackButtonAcceptedEvent_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButtonAcceptedEvent_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BackButtonAcceptedEvent != null) {
                BackButtonAcceptedEvent.Dispose ();
                BackButtonAcceptedEvent = null;
            }
        }
    }
}