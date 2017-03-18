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
        TextView employeeUsername;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EmployeeHomeScreen);
            // instantiate the text views we are going to get
            employeeUsername = FindViewById<TextView>(Resource.Id.txtEmployeeGreetings);
            //Pass the values to from the main activity
            employeeUsername.Text = "Welcome !\n" + Intent.GetStringExtra("EmployeeUsername").ToString();


        }
    }
}