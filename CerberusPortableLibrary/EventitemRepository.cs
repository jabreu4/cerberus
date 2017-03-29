using System;
using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;

namespace Cerberus.PortableLibrary
{
	public class EventitemRepository
	{
		CerberusDB db = null;

		public EventitemRepository()
		{
			db = CerberusDB.DefaultService;
		}

		public async Task<List<EventItem>> RefreshDataAsync()
		{
			return await db.RefreshDataAsync();
		}

		public EventItem GetTask(string guid)
		{
			return db.GetEvent(guid);
		}

		public IEnumerable<EventItem> GetTasks()
		{
			return db.GetEvents();
		}

		public async Task<EventItem> SaveTask(EventItem e)
		{
			return await db.SaveEvent(e); 
		}

		public int DeleteTask(EventItem e)
		{
			return db.DeleteItem(e);
		}
	}
}

