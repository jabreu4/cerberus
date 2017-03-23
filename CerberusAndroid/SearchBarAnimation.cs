using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Views.Animations;

namespace CerberusAndroid
{
    class SearchBarAnimation :  Animation
    {
        
        private View mView; //View that is going to be animated
        private int mOriginalHeight; //Keep track of the original height before the animation is started 
        private int mTargetHeight;  //Keep track of the height it needs to go
        private int mGrowBy; //Tells by how much is fonna grow or shrink the animation

        //Constructors

        public SearchBarAnimation(View view, int targetHeight)
        {
            mView = view;
            mOriginalHeight = view.Height;
            mTargetHeight = targetHeight;
            mGrowBy = mTargetHeight - mOriginalHeight;

        }


        //Method called when the view is animated 
        protected override void ApplyTransformation(float interpolatedTime, Transformation t)
        {
            mView.LayoutParameters.Height = (int)(mOriginalHeight + (mGrowBy * interpolatedTime));
            mView.RequestLayout(); // requesting the layout that something has changed and that the view is invalidated so re draw it it
        }

        
        public override bool WillChangeBounds()
        {
            return true;
        }


    }
}