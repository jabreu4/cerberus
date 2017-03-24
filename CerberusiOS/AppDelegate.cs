using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using SQLite;
using Cerberus.PortableLibrary;
using System.IO;
using Microsoft.WindowsAzure.MobileServices;
               
namespace Cerberus 
{
	public class Application 
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}

	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate 
	{
		// class-level declarations
		//UIWindow window;
		//UINavigationController navController;
		//UITableViewController homeViewController;

		public static AppDelegate Current { get; private set; }
		public TodoItemManager TodoManager { get; set; }
		//SQLiteConnection conn;

		// class-level declarations
		public override UIWindow Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Current = this;

			// create a new window instance based on the screen size
			//window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			// make the window visible
			//window.MakeKeyAndVisible ();

			// Create the database file
			//var sqliteFilename = "TodoItemDB.db3";
			//// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
			//// (they don't want non-user-generated data in Documents)
			//string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			//string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			//var path = Path.Combine(libraryPath, sqliteFilename);
			//conn = new SQLiteConnection(path);
			CurrentPlatform.Init();
			TodoManager = new TodoItemManager();

			//// create our nav controller
			//navController = new UINavigationController ();

			//// create our Todo list screen
			//homeViewController = new Screens.HomeScreen ();

			//// push the view controller onto the nav controller and show the window
			//navController.PushViewController(homeViewController, false);
			//window.RootViewController = navController;
			//window.MakeKeyAndVisible ();
			
			return true;
		}
		public override void OnResignActivation(UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground(UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground(UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated(UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate(UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}
	}
}