using System;
using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;

namespace Cerberus.PortableLibrary 
{
	public class TodoItemRepository
	{
		TodoDatabase db = null;

		public TodoItemRepository ()
		{
			db = TodoDatabase.DefaultService;
		}

		public async Task<List<TodoItem>> RefreshDataAsync()
		{
			return await db.RefreshDataAsync();
		}

		public TodoItem GetTask(string guid)
		{
			return db.GetItem(guid);
		}

		public IEnumerable<TodoItem> GetTasks()
		{
			return db.GetItems();
		}

		public async Task<TodoItem> SaveTask (TodoItem item)
		{
			return await db.SaveItem(item);;
		}

		public int DeleteTask(TodoItem item)
		{
			return db.DeleteItem(item);
		}
	}
}

