﻿using System;
using System.IO;
using SQLite;
using Android.App;
using Cerberus.PortableLibrary;
using Microsoft.WindowsAzure.MobileServices;

namespace CerberusAndroid
{
	[Application]
	public class CerberusApp : Application {
		public static CerberusApp Current { get; private set; }

		public TodoItemManager TodoManager { get; set; }
		//SQLiteConnection conn;

		public CerberusApp(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer)
			: base(handle, transfer) {
			Current = this;
		}

		public override void OnCreate()
		{
			base.OnCreate();

			//var sqliteFilename = "TodoItemDB.db3";
			//string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			//var path = Path.Combine(libraryPath, sqliteFilename);
			//conn = new SQLiteConnection(path);

			CurrentPlatform.Init();

			TodoManager = new TodoItemManager();
		}
	}
}

