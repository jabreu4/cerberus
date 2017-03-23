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
    class EmployeeInboxAdapter : BaseAdapter<ProjectCerberusInbox>
    {
        private Context mContext;
        private int mRowLayout;
        private List<ProjectCerberusInbox> mInbox;
        private int[] mAlternatingColors;
        private SlidingTabsFragment.SamplePagerAdapter samplePagerAdapter;
        private int row_upcomingEvent;

        public EmployeeInboxAdapter(Context context, int rowLayout, List<ProjectCerberusInbox> inbox)
        {
            mContext = context;
            mRowLayout = rowLayout;
            mInbox = inbox;
            mAlternatingColors = new int[] { 0xF2F2F2, 0x009900 };
        }

        public override int Count
        {
            get { return mInbox.Count; }
        }

        public override ProjectCerberusInbox this [int position]
        {
            get { return mInbox[position]; }
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


            TextView inboxNotificationName = row.FindViewById<TextView>(Resource.Id.txtInboxNotification);
            inboxNotificationName.Text = mInbox[position].InboxNotification;

            TextView inboxStatusName = row.FindViewById<TextView>(Resource.Id.txtInboxStatus);
            inboxStatusName.Text = mInbox[position].InboxStatus;

            TextView inboxDateName = row.FindViewById<TextView>(Resource.Id.txtInboxDate);
            inboxDateName.Text = mInbox[position].InboxDate;



            if ((position % 2) == 1)
            {
                //Green background, set text white
                inboxNotificationName.SetTextColor(Color.White);
                inboxStatusName.SetTextColor(Color.White);
                inboxDateName.SetTextColor(Color.White);
            }

            else
            {
                //White background, set text black
                inboxNotificationName.SetTextColor(Color.Black);
                inboxStatusName.SetTextColor(Color.Black);
                inboxDateName.SetTextColor(Color.Black);

            }

            return row;
        }

        private Color GetColorFromInteger(int color)
        {
            return Color.Rgb(Color.GetRedComponent(color), Color.GetGreenComponent(color), Color.GetBlueComponent(color));
        }



    }
}