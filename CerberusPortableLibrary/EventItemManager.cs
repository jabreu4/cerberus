using System;
using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;


namespace Cerberus.PortableLibrary
{

	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public class EventItemManager
	{
		EventitemRepository repository;

		public EventItemManager()
		{
			repository = new EventitemRepository();
		}

		public async Task<List<EventItem>> RefreshDataAsync()
		{
			return await repository.RefreshDataAsync();
		}

		public EventItem GetTask(string guid)
		{
			return repository.GetTask(guid);
		}

		public IList<EventItem> GetTasks()
		{
			return new List<EventItem>(repository.GetTasks());
		}

		public async Task<EventItem> SaveTask(EventItem e)
		{
			return await repository.SaveTask(e); ;
		}

		public int DeleteTask(EventItem e)
		{
			return repository.DeleteTask(e);
		}
	}
}
