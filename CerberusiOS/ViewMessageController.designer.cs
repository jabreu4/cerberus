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
    [Register ("ViewMessageController")]
    partial class ViewMessageController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton backToInboxButton { get; set; }

        [Action ("BackToInboxButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackToInboxButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (backToInboxButton != null) {
                backToInboxButton.Dispose ();
                backToInboxButton = null;
            }
        }
    }
}