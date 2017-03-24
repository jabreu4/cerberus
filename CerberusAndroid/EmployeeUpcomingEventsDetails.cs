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
    [Activity(Label = "EmployeeUpcomingEventsDetails")]
    public class EmployeeUpcomingEventsDetails : Activity
    {
        //Reference the text view
        TextView eventDate;
        TextView eventName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Create your application here
            SetContentView(Resource.Layout.EmployeeUpcomingEventItemView);

            // instantiate the text views we are going to get
            eventDate = FindViewById<TextView>(Resource.Id.txtUpComingEventDate);
            eventName = FindViewById<TextView>(Resource.Id.txtUpComingEventName);

            //Pass the values to from the main activity
            eventName.Text = Intent.GetStringExtra("NombreDeEvento").ToString();
            eventDate.Text = Intent.GetStringExtra("FechaDeEvento").ToString();

        }
    }
}