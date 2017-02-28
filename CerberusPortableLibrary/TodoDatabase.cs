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
	/// TaskDatabase uses ADO.NET to create the [Items] table and create,read,update,delete data
	/// </summary>
	public class TodoDatabase
	{
		static object locker = new object();

		//public SQLiteConnection database;

		//public string path;


		/************************************************************************************/
		static TodoDatabase instance = new TodoDatabase();

		const string applicationURL = @"https://testingazurecerberus.azurewebsites.net";

		private MobileServiceClient client;

		private IMobileServiceTable<TodoItem> todoTable;

		/***********************************************************************************/

		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		public TodoDatabase()
		{
			//database = conn;
			//// create the tables
			//database.CreateTable<TodoItem>();

			/***********************************************************************************/
			//CurrentPlatform.Init();

			// Initialize the client with the mobile app backend URL.
			client = new MobileServiceClient(applicationURL);

			todoTable = client.GetTable<TodoItem>();

			/***********************************************************************************/

		}
		/***********************************************************************************/
		public static TodoDatabase DefaultService
		{
			get
			{
				return instance;
			}
		}

		public List<TodoItem> Items { get; private set; }


		public async Task<List<TodoItem>> RefreshDataAsync()
		{
			try
			{
				// This code refreshes the entries in the list view by querying the local TodoItems table.
				// The query excludes completed TodoItems
				Items = new List<TodoItem>(await todoTable.ReadAsync());
				//Items = new List<TodoItem>(await todoTable.Where(todoItem => todoItem.Deleted == false).ToListAsync());

				//Items = todoTable.Where(todoItem => todoItem.Deleted == false).ToListAsync();

			}
			catch (MobileServiceInvalidOperationException e)
			{
				//	Console.Error.WriteLine(@"ERROR {0}", e.Message);
				return null;
			}

			return Items;
		}

		/***********************************************************************************/

		public IEnumerable<TodoItem> GetItems()
		{
			lock (locker)
			{
				/***********************************************************************************/
				return Items;
				/***********************************************************************************/

			}
		}

		public TodoItem GetItem(string guid)
		{

			/***********************************************************************************/
			foreach (var item in Items)
			{
				if (guid.Equals(item.ID))
				{
					return item;
				}
			}

			return null;
				/***********************************************************************************/
		}

		public async Task<TodoItem> SaveItem(TodoItem item)
		{
			//if (item.ID != 0) {
			//	database.Update(item);
			//	return item.ID;
			//} else {
			//	return database.Insert(item);
			//}
			/***********************************************************************************/
			try
			{
				if (String.IsNullOrEmpty(item.ID))
				{
					await todoTable.InsertAsync(item); // Insert a new TodoItem into the local database.
			             							   //item.ID = blablabla;
					Items.Add(item);
				}
				else
				{
					await todoTable.UpdateAsync(item); // Insert a new TodoItem into the local database.
				}
			}
			catch (MobileServiceInvalidOperationException e)
			{
				;//Console.Error.WriteLine(@"ERROR {0}", e.Message);
			}

			return item; //Todo convert guid to 128bit decimal
					  //return item.ID;
			/***********************************************************************************/

		}

		public int DeleteItem(TodoItem item)
		{
				/***********************************************************************************/
				Items.Remove(item);
				todoTable.DeleteAsync(item); // Delete a TodoItem into the local database
				return -1;
				/***********************************************************************************/
		}
	}
}