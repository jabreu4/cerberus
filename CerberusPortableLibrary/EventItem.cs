using System;
using Newtonsoft.Json;

namespace Cerberus.PortableLibrary
                  
{
	/// <summary>
	/// Event business object
	/// </summary>
	public class EventItem
	{

		// SQLite attributes Not sure if needed for Azure DB
		// [PrimaryKey, AutoIncrement]

		//public string ID { get; set; }

		public string EventID { get; set; }

		public string EventName { get; set; }

		public string EventTime { get; set; }

		public string Location { get; set; }

		public string PhotoID { get; set; }

		public string EventDuration { get; set; }

		public bool Done { get; set; }  // TODO: add this field to the user-interface

	}

}