using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace CerberusAndroid
{
    [Activity(Label = "CerberusAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class LogInPage : Activity
    {
        /***********************************************************************
         *                          Variables
         * 
         * **********************************************************************/
        private Button mBtnSignUpWithEmail;
        private ProgressBar mProgressBar;
        private Button mBtnLogIn;


        /*************************************************************************
         *                          Activity Methods
         * 
         * ***********************************************************************/

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LogIn);

            //Wire the Progress Bar
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            //wire up the sign up button
            mBtnSignUpWithEmail = FindViewById<Button>(Resource.Id.btnSignUpWithEmail);
            mBtnLogIn = FindViewById<Button>(Resource.Id.btnLogIn);

            //Register the sign up with email button listener
            mBtnSignUpWithEmail.Click += (object sender, EventArgs args) =>
            {
                //Instantiate a Fragment transaction which in this case is the  SignUp transaction
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                //Pull up the dialog Fragment object of our class
                Dialog_SignUp signUpDialog = new Dialog_SignUp();
                //Show the transaction
                signUpDialog.Show(transaction, "dialog fragment");

                //Recive the broadcase from the signup and say hey i did get your request event, lets subscribe you
                signUpDialog.mOnSignUpComplete += SignUpDialog_mOnSignUpComplete;



            };

            //Register the sign up with email button listener
            mBtnLogIn.Click += (object sender, EventArgs args) =>
            {
                //Instantiate a Fragment transaction which in this case is the  SignUp transaction
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                //Pull up the dialog Fragment object of our class
                Dialog_LogIn logInDialog = new Dialog_LogIn();
                //Show the transaction
                logInDialog.Show(transaction, "dialog fragment");

                //Recive the broadcase from the signup and say hey i did get your request event, lets subscribe you
                logInDialog.mOnLogInComplete += LogInDialog_mOnLogInComplete;



            };







        }

  

        private void LogInDialog_mOnLogInComplete(object sender, OnLogInEventArgs e)
        {

            //The user has been authenticated and logged in, we send him to his employee page with the use of intent
            //We must pass the username string to greet him on the homepage

            Intent intent = new Intent(this, typeof(EmployeeHomePage));
            // el EventName es un key para referenciarlo en el otro activity
            intent.PutExtra("EmployeeUsername",e.Username);
            this.StartActivity(intent);
            //Once we he is logged in we want to kill the log in process
            this.Finish();//finish the login screen


        }

        private void SignUpDialog_mOnSignUpComplete(object sender, OnSignEventArgs e)
        {
           

            /*
            //Set notification to the user that the account link was sent to the email
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alertDialog = builder.Create();
            alertDialog.SetTitle("Notification");
            alertDialog.SetIcon(Resource.Drawable.Icon);
            alertDialog.SetMessage("Account link was sent to " + e.Email);
            alertDialog.Show();
            */


            // at this part we would send request to the server and get a response, here goes like a php code or azure
            //In this case we would simulate the request
            mProgressBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(ActLikeARequest);
            thread.Start();

            //Here you would send the password from the user to the the server like this
            //string validatePassword = e.Passowrd;
            //string validateEmail = e.Email;
            //set alert for executing the task

        }

        //Handle the web request from the server
        private void ActLikeARequest()
        {
            //Sleep for 3 seconds do work
            Thread.Sleep(3000);

            //Run on a different thread for GUI's
            RunOnUiThread(() => { mProgressBar.Visibility = ViewStates.Invisible; });
           
        }
    
    }
}

