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
        Button mAttend;
        Button mDecline;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Create your application here
            SetContentView(Resource.Layout.EmployeeUpcomingEventItemView);

            // instantiate the text views we are going to get
            eventDate = FindViewById<TextView>(Resource.Id.txtUpComingEventDate);
            eventName = FindViewById<TextView>(Resource.Id.txtUpComingEventName);
            mAttend = FindViewById<Button>(Resource.Id.btnAttendUpcmoingEvent);
            mDecline = FindViewById<Button>(Resource.Id.btnDeclineUpcomingEvent);

            //Pass the values to from the main activity
            eventName.Text = Intent.GetStringExtra("NombreDeEvento").ToString();
            eventDate.Text = Intent.GetStringExtra("FechaDeEvento").ToString();

            mAttend.Click += Attend_Click;
            mDecline.Click += Decline_Click;
        }

        private void Decline_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alertDialog = builder.Create();
            alertDialog.SetTitle("Are you sure ?");
            alertDialog.SetIcon(Resource.Drawable.Icon);
            alertDialog.SetMessage(" Why not :( ?");
            alertDialog.Show();
           
        }

        private void Attend_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alertDialog = builder.Create();
            alertDialog.SetTitle("Are you sure ?");
            alertDialog.SetIcon(Resource.Drawable.Icon);
            alertDialog.SetMessage("By confirming to this event, you have commited to attend to such event.\nThere is no turning back!!!)");
            alertDialog.Show();
           
            
        }
    }
}