using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;

namespace CerberusAndroid
{
    public class SlidingTabsFragment : Fragment
    {
        private SlidingTabScrollView mSlidingTabScrollView;
        private ViewPager mViewPager;
      



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_sample, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            mSlidingTabScrollView = view.FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            mViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);

            mViewPager.Adapter = new SamplePagerAdapter(this.Activity);
            

            mSlidingTabScrollView.ViewPager = mViewPager;
        }

        public class SamplePagerAdapter : PagerAdapter
        {
            List<string> items = new List<string>();
            private ListView upcomingEventsListView;
            private List<ProjectCerberusEvent> upComingEvents;

            public SamplePagerAdapter(Activity theActivity) : base()
            {
                

                items.Add("Upcoming");
                items.Add("Accepted");
                items.Add("Rejected");
                items.Add("History");

            }

            public override int Count
            {
                get { return items.Count; }
            }

            public override bool IsViewFromObject(View view, Java.Lang.Object obj)
            {
                return view == obj;
            }

            public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
            {

               

                View view;
                int pos = position + 1;



                if (pos == 1)
                {
                    view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.EmployeeUpcomingEvents, container, false);
                    upcomingEventsListView = view.FindViewById<ListView>(Resource.Id.listViewUpcomingEvents);
                    upComingEvents = new List<ProjectCerberusEvent>();
                    
                    //Populate the upcoming List with some events
                    upComingEvents.Add(new ProjectCerberusEvent() { EventName = "Chente World Tour", EventDate = "March 25, 2017" });
                    upComingEvents.Add(new ProjectCerberusEvent() { EventName = "Pepe's Grill", EventDate = "May 17, 2017" });

                    //This array adapter is used to work with the row of the list view. It populates each row with the Items passed and defines each item with a simple layout
                    EmployeeUpcomingEventsAdapter adapter = new EmployeeUpcomingEventsAdapter(view.Context, Resource.Layout.row_upcomingEvent, upComingEvents);

                    //Connect the ListView of the GUI with the Adapter
                    upcomingEventsListView.Adapter = adapter;


                    upcomingEventsListView.ItemClick += UpcomingEventsListView_ItemClick;
                  

                    container.AddView(view);


                }

                
                else
                {
                    view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_item, container, false);
                    
                }
          
                return view;


            }

            private void UpcomingEventsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
            {
              
               
            }

            public string GetHeaderTitle (int position)
            {
                return items[position];
            }

            public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object obj)
            {
                container.RemoveView((View)obj);
            }
        }
    }
}