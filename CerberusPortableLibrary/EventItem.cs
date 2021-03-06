﻿using System;
using Newtonsoft.Json;

namespace Cerberus.PortableLibrary
                  
{
	/// <summary>
	/// Class that defines a Event for the whole Application.
	/// </summary>
	public class EventItem
	{

		// SQLite attributes Not sure if needed for Azure DB
		// [PrimaryKey, AutoIncrement]

		public string ID { get; set; }

		public string Location { get; set; }
        
        public string EventName { get; set; }

        public DateTime EventDuration { get; set; }

        public DateTime EventDatetime { get; set; }

        public int PhotoId { get; set; }
		

	}

}