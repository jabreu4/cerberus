using System;
using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;

namespace Cerberus.PortableLibrary 
{
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public class TodoItemManager 
	{
		TodoItemRepository repository; 

		public TodoItemManager ()
		{
			repository = new TodoItemRepository ();
		}

		public async Task<List<TodoItem>> RefreshDataAsync()
		{
			return await repository.RefreshDataAsync();
		}
		
		public TodoItem GetTask(string guid)
		{
			return repository.GetTask(guid);
		}
		
		public IList<TodoItem> GetTasks ()
		{
			return new List<TodoItem>(repository.GetTasks());
		}

		public async Task<TodoItem> SaveTask (TodoItem item)
		{
			return await repository.SaveTask(item);;
		}
		
		public int DeleteTask(TodoItem item)
		{
			return repository.DeleteTask(item);
		}
	}
}