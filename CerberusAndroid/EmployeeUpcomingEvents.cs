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
    [Activity(Label = "EmployeeUpcomingEvents")]
    public class EmployeeUpcomingEvents : Activity
    {
        //List for past events name & date
        private List<ProjectCerberusEvent> upComingEvents;
        //The list view from the GUI
        private ListView upcomingEventsListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EmployeeUpcomingEvents);

            //Instantiate the ListView from the GUI and find it by its ID
            upcomingEventsListView = FindViewById<ListView>(Resource.Id.listViewUpcomingEvents);

            //Instantiate the ListItem  Object
            upComingEvents = new List<ProjectCerberusEvent>();

            //Populate the upcoming List with some events
            upComingEvents.Add(new ProjectCerberusEvent() { EventName = "Chente World Tour", EventDate = "March 25, 2017" });
            upComingEvents.Add(new ProjectCerberusEvent() { EventName = "Pepe's Grill", EventDate = "May 17, 2017" });

            //This array adapter is used to work with the row of the list view. It populates each row with the Items passed and defines each item with a simple layout
            EmployeeUpcomingEventsAdapter adapter = new EmployeeUpcomingEventsAdapter(this, Resource.Layout.row_upcomingEvent, upComingEvents);

            //Connect the ListView of the GUI with the Adapter
            upcomingEventsListView.Adapter = adapter;




        }
    }
}