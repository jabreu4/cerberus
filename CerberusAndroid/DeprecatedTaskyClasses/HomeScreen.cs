using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Cerberus.PortableLibrary;
using CerberusAndroid;
using CerberusAndroid.ApplicationLayer;

namespace CerberusAndroid.Screens 
{
	/// <summary>
	/// Main ListView screen displays a list of tasks, plus an [Add] button
	/// </summary>
	[Activity (Label = "Cerberus", MainLauncher = true, Icon="@drawable/icon")]			
	public class HomeScreen : Activity 
	{
		TodoItemListAdapter taskList;
		IList<TodoItem> tasks;
		Button addTaskButton;
		ListView taskListView;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// set our layout to be the home screen
			SetContentView(Resource.Layout.HomeScreen);

			//Find our controls
			taskListView = FindViewById<ListView> (Resource.Id.TaskList);
			addTaskButton = FindViewById<Button> (Resource.Id.AddButton);

			// wire up add task button handler
			if(addTaskButton != null) {
				addTaskButton.Click += (sender, e) => {
					StartActivity(typeof(TodoItemScreen));
				};
			}
			
			// wire up task click handler
			if(taskListView != null) {
				taskListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
					var taskDetails = new Intent (this, typeof (TodoItemScreen));
					taskDetails.PutExtra("TaskGUID", tasks[e.Position].ID);
					StartActivity (taskDetails);
				};
			}
		}

		protected override async void OnResume ()
		{
			base.OnResume ();

			await CerberusApp.Current.TodoManager.RefreshDataAsync();

			tasks = CerberusApp.Current.TodoManager.GetTasks();

			// create our adapter
			taskList = new TodoItemListAdapter(this, tasks);

			//Hook up our adapter to our ListView
			taskListView.Adapter = taskList;
		}
	}
} 