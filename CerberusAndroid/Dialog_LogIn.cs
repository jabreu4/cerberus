using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CerberusAndroid
{
    //Event delegate or inner class made just for when the event of signnin up happens
    public class OnLogInEventArgs : EventArgs
    {
        //variables
        private string mUsername;
        private string mPassword;


        //Getter and setter methods
        public string Username
        {
            get { return mUsername; }
            set { mUsername = value; }
        }
        public string Passowrd
        {
            get { return mPassword; }
            set { mPassword = value; }
        }
        //Constructor
        public OnLogInEventArgs(string username, string password) : base() //the base calls the super class constructor which is EventArgs
        {
            Username = username;
            Passowrd = password;
        }
    }



    class Dialog_LogIn : DialogFragment
    {

        //Variables
        private EditText mUsername;
        private EditText mLogInPassword;
        private Button mBtnDialogLogIn;

        //Variable to broadcast the event of our custom class
        public event EventHandler<OnLogInEventArgs> mOnLogInComplete;



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate the fragmennt view of our dialog Sign Up
            var view = inflater.Inflate(Resource.Layout.dialog_login, container, false);

            //Instantiate the object from the view
            mUsername = view.FindViewById<EditText>(Resource.Id.txtUsername);
            mLogInPassword = view.FindViewById<EditText>(Resource.Id.txtUsernamePassword);
            mBtnDialogLogIn = view.FindViewById<Button>(Resource.Id.btnDialogLogIn);

            //Register the Sign UP button from the dialog fragment
            mBtnDialogLogIn.Click += (object sender, EventArgs e) =>
            {
                //User has click the sign up button from the dialog. He has requested to resgiter with the email
                //Broadcast to any subscriber that we got the request to subscribe the user
                mOnLogInComplete.Invoke(this, new OnLogInEventArgs(mUsername.Text, mLogInPassword.Text));
                //Dismiss the Dialog Fragment
                this.Dismiss();


            };



            return view;
        }

        //Fragment Animations
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            //Remove the title from the action Bar
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            //Save the Instance
            base.OnActivityCreated(savedInstanceState);
            //Attach the animation 
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;

        }
    }
}