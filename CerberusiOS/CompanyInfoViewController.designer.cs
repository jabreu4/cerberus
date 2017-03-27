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
    [Register ("CompanyInfoViewController")]
    partial class CompanyInfoViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton callCompanyButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton InfoBackButton { get; set; }

        [Action ("CallCompanyButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CallCompanyButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("InfoBackButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void InfoBackButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (callCompanyButton != null) {
                callCompanyButton.Dispose ();
                callCompanyButton = null;
            }

            if (InfoBackButton != null) {
                InfoBackButton.Dispose ();
                InfoBackButton = null;
            }
        }
    }
}