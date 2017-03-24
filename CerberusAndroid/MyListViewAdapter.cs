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
    class MyListAdapter : BaseAdapter<ProjectCerberusEvent>
    {
        //Keep a list of the items 
        private List<ProjectCerberusEvent> mItems;

        private Context mContext;


        //Constructor for our custom view adapter
        public MyListAdapter(Context context, List<ProjectCerberusEvent> items )
        {
            mItems = items;
            mContext = context;

        }

        //Tells how many rows are in our list view
        public override int Count
        {
                get { return mItems.Count; }
        }

        //Return the postion of the row
        public override long GetItemId(int position)
        {
            return position;
        }

        //return the actual object of the row

        public override ProjectCerberusEvent this[int position]
        {
               get { return mItems[position]; }
            
        }


        //Create the row and let you do what you want with it

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            //Check if the row is null
            if(row == null)
            {// create a new row if null
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);
            }

            //Get the text of our row
            TextView eventName = row.FindViewById<TextView>(Resource.Id.eventNameTextView);
            //Match the row with its position
            eventName.Text = mItems[position].EventName;

            //Get the text of our row
            TextView eventDate = row.FindViewById<TextView>(Resource.Id.eventDateTextView);
            //Match the row with its position
            eventDate.Text = mItems[position].EventDate;



            return row;
        }

    }
}