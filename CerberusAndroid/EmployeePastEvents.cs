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
    [Activity(Label = "EmployeePastEvents")]
    public class EmployeePastEvents : Activity
    {
        //List for past events name & date
        private List<ProjectCerberusEvent> pastEventsItems;
        //The list view from the GUI
        private ListView pastEventsListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EmployeePastEvents);

            //Instantiate the ListView from the GUI and find it by its ID
            pastEventsListView = FindViewById<ListView>(Resource.Id.pastEventsListView);

            //Instantiate the ListItem  Object
            pastEventsItems = new List<ProjectCerberusEvent>();

            //Populate the pastEvents List with some events
            pastEventsItems.Add(new ProjectCerberusEvent() { EventName = "Metallica Concert Tour 2010", EventDate = "March 14, 2010" });
            pastEventsItems.Add(new ProjectCerberusEvent() { EventName = "Zion & Lennox Concert", EventDate = "February 7, 2017" });

            //This array adapter is used to work with the row of the list view. It populates each row with the Items passed and defines each item with a simple layout
            MyListAdapter adapter = new MyListAdapter(this, pastEventsItems);

            //Get the item of a specific row
            ProjectCerberusEvent indexTest = adapter[1];


            //Connect the ListView of the GUI with the Adapter
            pastEventsListView.Adapter = adapter;


            pastEventsListView.ItemClick += PastEventsListView_ItemClick;


        }


        /*****************************************************************************************
         *                                      Listener Events
         * 
         * ***************************************************************************************/



        private void PastEventsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            Intent intent = new Intent(this, typeof(EmployeePastEventDetails));
            // el EventName es un key para referenciarlo en el otro activity
            intent.PutExtra("NombreDeEvento", pastEventsItems[e.Position].EventName);
            intent.PutExtra("FechaDeEvento", pastEventsItems[e.Position].EventDate);
            this.StartActivity(intent);
        }

    }
}
