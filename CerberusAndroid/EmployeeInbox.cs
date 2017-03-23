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
using Android.Views.InputMethods;


namespace CerberusAndroid
{
    [Activity(Label = "EmployeeInbox")]
    public class EmployeeInbox : Activity
    {

        private List<ProjectCerberusInbox> mInbox;
        private ListView mInboxListView;
        private EditText mSearchInbox;
        private LinearLayout mContainer; // container for the animation of sliding down the search bar
        private bool mAnimatedDown; // detect if the action bar is up or down animation
        private bool mIsAnimating; //Check when the animation has been done so the user dosent screw up the animation
        private EmployeeInboxAdapter mAdapter;




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EmployeeInbox);
            mInboxListView = FindViewById<ListView>(Resource.Id.listViewInbox);
            mSearchInbox = FindViewById<EditText>(Resource.Id.eTxtSearchInbox);
            mContainer = FindViewById<LinearLayout>(Resource.Id.containerInbox);

            //Makes the search bar invisible
            mSearchInbox.Alpha = 0;

            //Call the search bar query
            mSearchInbox.TextChanged += mSearch_TextChanged;

            mInbox = new List<ProjectCerberusInbox>();
            mInbox.Add(new ProjectCerberusInbox { InboxNotification = "Canceled" , InboxStatus = "Open" , InboxDate = "3/23/17" } );
            mInbox.Add(new ProjectCerberusInbox { InboxNotification = "Accepted", InboxStatus = "Closed", InboxDate = "2/22/17" });

            EmployeeInboxAdapter adapter = new EmployeeInboxAdapter(this, Resource.Layout.row_inbox, mInbox);
            mInboxListView.Adapter = adapter;

        }

        //Query for searching on the inbox
        void mSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {

            List<ProjectCerberusInbox> searchedInbox = (from inbox in mInbox
                                                        where inbox.InboxNotification.Contains(mSearchInbox.Text, StringComparison.OrdinalIgnoreCase)
                                                                 || inbox.InboxStatus.Contains(mSearchInbox.Text, StringComparison.OrdinalIgnoreCase)
                                                        select inbox).ToList<ProjectCerberusInbox>();


            //Refresh the list of the adpater
            mAdapter = new EmployeeInboxAdapter(this, Resource.Layout.row_inbox, searchedInbox);
            mInboxListView.Adapter = mAdapter;


        }














        //Make the actionbar visible
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar, menu);
            return base.OnCreateOptionsMenu(menu);

        }

        //Bring functionality to the actionbar

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            switch(item.ItemId)
            {
                //Search Icon has been clicked
                case Resource.Id.search: // this id is in the menu folder under actionbar.xml


                    //Check flag if its animating

                    if(mIsAnimating)
                    {
                        return true;
                    }

                    //List View is moving up
                    if (!mAnimatedDown)
                    {
                        SearchBarAnimation anim = new SearchBarAnimation(mInboxListView, mInboxListView.Height - mSearchInbox.Height);
                        anim.Duration = 500;
                        mInboxListView.StartAnimation(anim);
                        anim.AnimationStart += Anim_AnimationStartDown;
                        anim.AnimationEnd += Anim_AnimationEndDown;
                        mContainer.Animate().TranslationYBy(mSearchInbox.Height).SetDuration(500).Start();
                        

                    }
                    //List view is moving down
                    else
                    {
                        SearchBarAnimation anim = new SearchBarAnimation(mInboxListView, mInboxListView.Height - mSearchInbox.Height);
                        anim.Duration = 500;
                        mInboxListView.StartAnimation(anim);
                        anim.AnimationStart += Anim_AnimationStartUp;
                        anim.AnimationEnd += Anim_AnimationEndUp;
                        mContainer.Animate().TranslationYBy(-mSearchInbox.Height).SetDuration(500).Start();
                 

                    }


                    //Toggle State
                    mAnimatedDown = !mAnimatedDown;

                    return true;
                 




                default:
                    return base.OnOptionsItemSelected(item);


            }

        }

        private void Anim_AnimationEndDown(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            //No longer animating
            mIsAnimating = false;
            //Close the keyboard when the animation is done
            mSearchInbox.ClearFocus();
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
          
        }

        private void Anim_AnimationEndUp(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            //No longer animating
            mIsAnimating = false;

        }

        private void Anim_AnimationStartDown(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mSearchInbox.Animate().AlphaBy(1.0f).SetDuration(500).Start();
            
        }

        private void Anim_AnimationStartUp(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mSearchInbox.Animate().AlphaBy(-1.0f).SetDuration(300).Start();

        }



    }
}
