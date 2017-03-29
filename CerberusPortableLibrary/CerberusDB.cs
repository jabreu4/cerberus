using System;
using System.Net.Http;
//using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
//using SQLite;
using Microsoft.WindowsAzure.MobileServices;


namespace Cerberus.PortableLibrary
{
	/// <summary>
	/// CRUD operations for all Azure Database Calls.
	/// </summary>

	public class CerberusDB
	{
		static object locker = new object();

		//Initialization of the Azure database with its corresponding URL and implementation of the client
		/************************************************************************************/
		static CerberusDB instance = new CerberusDB();

		const string applicationURL = @"https://cerberusadministrator.azurewebsites.net/";

		private MobileServiceClient client;

		private IMobileServiceTable<EventItem> eventTable;

		/***********************************************************************************/

		/// <summary>
		/// Initializes a new instance of the Cerberus Database. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		public CerberusDB()
		{

			// Initialize the client with the mobile app backend URL.
			client = new MobileServiceClient(applicationURL);

			eventTable = client.GetTable<EventItem>();
		}

		public static CerberusDB DefaultService
		{
			get
			{
				return instance;
			}
		}

		//This initialize a list of all events in the Azure Database table
		public List<EventItem> Events { get; private set; }

		public async Task<List<EventItem>> RefreshDataAsync()
		{
			try
			{
				// This code refreshes the entries in the list view by querying the local TodoItems table.

				Events = new List<EventItem>(await eventTable.ReadAsync());


			}
			catch (MobileServiceInvalidOperationException e)
			{
				//	Console.Error.WriteLine(@"ERROR {0}", e.Message)
				return null;
			}

			return Events;
		}

		public IEnumerable<EventItem> GetEvents()
		{
			lock (locker)
			{
				if (Events == null)
				{
					Events = new List<EventItem>();
				}
				return Events;

			}
		}

		//Returns the Event with the Specified Guid
		public EventItem GetEvent(string guid)
		{
			foreach (var e in Events)
			{
				if (guid.Equals(e.ID))
				{
					return e;
				}
			}
			return null;
		}


		//Saves an Event in the Table and returns the Table 
		public async Task<EventItem> SaveEvent(EventItem e )
		{
			try 
			{
				if (String.IsNullOrEmpty(e.ID))
				{
					// Insert a new EventItem into the local database.
					await eventTable.InsertAsync(e); 
					Events.Add(e);
				}
				else
				{
					// Insert a new EventItem into the local database.
					await eventTable.UpdateAsync(e);
				}
				
			}
			catch (MobileServiceInvalidOperationException m)
			{
				
			}

			return e;	
		}

		public int DeleteItem(EventItem e)
		{
			
			Events.Remove(e);
			eventTable.DeleteAsync(e); // Delete a Event into the local database
			return -1;

		}


	}
}
