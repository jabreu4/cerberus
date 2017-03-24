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
using Android.Graphics;

namespace CerberusAndroid
{
    class EmployeeUpcomingEventsAdapter : BaseAdapter<ProjectCerberusEvent>
    {
        private Context mContext;
        private int mRowLayout;
        private List<ProjectCerberusEvent> mUpcomingEvents;
        private int[] mAlternatingColors;
      

        public EmployeeUpcomingEventsAdapter(Context context, int rowLayout, List<ProjectCerberusEvent> upComingEvents)
        {
            mContext = context;
            mRowLayout = rowLayout;
            mUpcomingEvents = upComingEvents;
            mAlternatingColors = new int[] { 0xF2F2F2, 0x009900 };
        }

        public override int Count
        {
            get { return mUpcomingEvents.Count; }
        }

        public override ProjectCerberusEvent this[int position]
        {
            get { return mUpcomingEvents[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(mRowLayout, parent, false);
            }

            row.SetBackgroundColor(GetColorFromInteger(mAlternatingColors[position % mAlternatingColors.Length]));


            TextView upcomingEventName = row.FindViewById<TextView>(Resource.Id.txtUpcomingEventName);
            upcomingEventName.Text = mUpcomingEvents[position].EventName;

            TextView upComingEventDate = row.FindViewById<TextView>(Resource.Id.txtUpcomingEventDate);
            upComingEventDate.Text = mUpcomingEvents[position].EventDate;

         
            if ((position % 2) == 1)
            {
                //Green background, set text white
                upcomingEventName.SetTextColor(Color.White);
                upComingEventDate.SetTextColor(Color.White);
            }

            else
            {
                //White background, set text black
                upcomingEventName.SetTextColor(Color.Black);
                upComingEventDate.SetTextColor(Color.Black);
         
            }

            return row;
        }

        private Color GetColorFromInteger(int color)
        {
            return Color.Rgb(Color.GetRedComponent(color), Color.GetGreenComponent(color), Color.GetBlueComponent(color));
        }



    }
}