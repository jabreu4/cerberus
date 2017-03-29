using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Cerberus.PortableLibrary;
using CerberusAndroid;

namespace CerberusAndroid.Screens 
{
	/// <summary>
	/// View/edit a Task
	/// </summary>
	[Activity (Label = "TaskDetailsScreen")]			
	public class TodoItemScreen : Activity 
	{
		TodoItem task = new TodoItem();
		Button cancelDeleteButton;
		EditText notesTextEdit;
		EditText nameTextEdit;
        EditText eventNameTextEdit;

        Button saveButton;
		CheckBox doneCheckbox;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			string taskID = Intent.GetStringExtra("TaskGUID");
			if(!string.IsNullOrEmpty(taskID)) {
				task = CerberusApp.Current.TodoManager.GetTask(taskID);
			}
			
			// set our layout to be the home screen
			SetContentView(Resource.Layout.TaskDetails);
			nameTextEdit = FindViewById<EditText>(Resource.Id.NameText);
			notesTextEdit = FindViewById<EditText>(Resource.Id.NotesText);
            eventNameTextEdit = FindViewById<EditText>(Resource.Id.EventNameText);
            saveButton = FindViewById<Button>(Resource.Id.SaveButton);

			// TODO: find the Checkbox control and set the value
			doneCheckbox = FindViewById<CheckBox>(Resource.Id.chkDone);
			doneCheckbox.Checked = task.Done;

			// find all our controls
			cancelDeleteButton = FindViewById<Button>(Resource.Id.CancelDeleteButton);
			
			// set the cancel delete based on whether or not it's an existing task
			cancelDeleteButton.Text = (string.IsNullOrEmpty(task.ID) ? "Cancel" : "Delete");
			
			nameTextEdit.Text = task.Name; 
			notesTextEdit.Text = task.Notes;
            eventNameTextEdit.Text = task.EventName;

			// button clicks 
			cancelDeleteButton.Click += (sender, e) => { CancelDelete(); };
			saveButton.Click += (sender, e) => { Save(); };
		}

		async void Save()
		{
			task.Name = nameTextEdit.Text;
			task.Notes = notesTextEdit.Text;
            task.EventName = eventNameTextEdit.Text;
			//TODO: 
			task.Done = doneCheckbox.Checked;

			await CerberusApp.Current.TodoManager.SaveTask(task);
			Finish();
		}
		
		void CancelDelete()
		{
			if (!string.IsNullOrEmpty(task.ID)) {
				CerberusApp.Current.TodoManager.DeleteTask(task);
			}
			Finish();
		}
	}
}