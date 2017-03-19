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

namespace CerberusAndroid
{
    [Activity(Label = "EmployeeHomePage")]
    public class EmployeeHomePage : Activity
    {
        //Variables
        TextView mEmployeeUsername;
        Button mBtnEmployeeProfile;
        Button mBtnPastEvents;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EmployeeHomeScreen);
            // instantiate the text views we are going to get
            mEmployeeUsername = FindViewById<TextView>(Resource.Id.txtEmployeeGreetings);
            mBtnEmployeeProfile = FindViewById<Button>(Resource.Id.btnEmployeeProfile);
            mBtnPastEvents = FindViewById<Button>(Resource.Id.btnEmployeeHistory);
            //Pass the values to from the main activity
            mEmployeeUsername.Text = "Welcome !\n" + Intent.GetStringExtra("EmployeeUsername").ToString();
           
            //Pass intent to the User Profile
            mBtnEmployeeProfile.Click += (object sender, EventArgs args) =>
            {
                Intent intent = new Intent(this, typeof(EmployeeProfile));
                this.StartActivity(intent);
            };

            //Pass intent to the Employee History Events
            mBtnPastEvents.Click += (object sender, EventArgs args) =>
            {
                Intent intent = new Intent(this, typeof(EmployeePastEvents));
                this.StartActivity(intent);
            };




        }

        
    }
}