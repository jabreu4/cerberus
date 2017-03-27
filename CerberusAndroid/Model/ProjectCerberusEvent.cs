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
    class ProjectCerberusEvent
    {
        public string EventName { get; set; }
        public string EventLocation { set; get; }
        public string EventDate { set; get; }
        public string EventHours { set; get; }
        public string EventArrivalTime { set; get; }
        public int EventToxicityLevel { set; get; }

    }
}