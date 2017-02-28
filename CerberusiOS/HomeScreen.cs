using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using Foundation;
using MonoTouch.Dialog;
using Cerberus.PortableLibrary;
using Cerberus.ApplicationLayer;
using System.Threading.Tasks;

namespace Cerberus.Screens {
	
	/// <summary>
	/// A UITableViewController that uses MonoTouch.Dialog - displays the list of Tasks
	/// </summary>
	public class HomeScreen : DialogViewController {
		// 
		IEnumerable<TodoItem> tasks;
		
		// MonoTouch.Dialog individual TaskDetails view (uses /ApplicationLayer/TaskDialog.cs wrapper class)
		BindingContext context;
		TodoItemDialog taskDialog;
		TodoItem currentItem;
		DialogViewController detailsScreen;

		public HomeScreen () : base (UITableViewStyle.Plain, null)
		{
			Initialize ();
		}
		
		protected void Initialize()
		{
			NavigationItem.SetRightBarButtonItem (new UIBarButtonItem (UIBarButtonSystemItem.Add), false);
			NavigationItem.RightBarButtonItem.Clicked += (sender, e) => { ShowTaskDetails(new TodoItem()); };
		}

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();

			//RefreshControl.ValueChanged += async (sender, e) =>
			//{
			//	await AppDelegate.Current.TodoManager.RefreshDataAsync();
			//	PopulateTable();
			//};

			await AppDelegate.Current.TodoManager.RefreshDataAsync();
			PopulateTable();

		}

		//private async Task RefreshAsync()
		//{
		//	RefreshControl.BeginRefreshing();
		//	await AppDelegate.Current.TodoManager.RefreshDataAsync();
		//	RefreshControl.EndRefreshing();

		//	TableView.ReloadData();
		//}

		protected void ShowTaskDetails(TodoItem item)
		{
			currentItem = item;
			taskDialog = new TodoItemDialog (currentItem);
			context = new BindingContext (this, taskDialog, "Task Details");
			detailsScreen = new DialogViewController (context.Root, true);
			ActivateController(detailsScreen);
		}
		public async void SaveTask()
		{
			context.Fetch (); // re-populates with updated values
			currentItem.Name = taskDialog.Name;
			currentItem.Notes = taskDialog.Notes;
			// TODO: show the completion status in the UI
			currentItem.Done = taskDialog.Done;
			await AppDelegate.Current.TodoManager.SaveTask(currentItem);
			NavigationController.PopViewController (true);
			PopulateTable();

		}
		public void DeleteTask ()
		{
			//if (currentItem.ID >= 0)
				//AppDelegate.Current.TodoManager.DeleteTask(currentItem.ID);
			if (currentItem.ID.Length >= 0)
				AppDelegate.Current.TodoManager.DeleteTask(currentItem);

			NavigationController.PopViewController (true);
			PopulateTable();
		}

		//public override void ViewWillAppear (bool animated)
		//{
		//	base.ViewWillAppear (animated);
		//	
		//	// reload/refresh
		//	//PopulateTable();			
		//}

		protected void PopulateTable()
		{
			tasks = AppDelegate.Current.TodoManager.GetTasks().ToList();
//			var rows = from t in tasks
//				select (Element)new StringElement ((t.Name == "" ? "<new task>" : t.Name), t.Notes);
			// TODO: use this element, which displays a 'tick' when item is completed
			var rows = from t in tasks
				select (Element)new CheckboxElement ((t.Name == "" ? "<new task>" : t.Name), t.Done);
			var s = new Section ();
			s.AddAll(rows);
			Root = new RootElement("Tasky") {s}; 
		}
		public override void Selected (Foundation.NSIndexPath indexPath)
		{
			var todoItem = tasks.ElementAt(indexPath.Row);
			ShowTaskDetails(todoItem);
		}
		public override Source CreateSizingSource (bool unevenRows)
		{
			return new EditingSource (this);
		}
		public void DeleteTaskRow(int rowId)
		{
			//AppDelegate.Current.TodoManager.DeleteTask(tasks[rowId].ID);
			AppDelegate.Current.TodoManager.DeleteTask(tasks.ElementAt(rowId));

		}
	}
}