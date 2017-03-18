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
    public class OnSignEventArgs: EventArgs
    {
        //variables
        private string mEmail;
        private string mPassword;

        //Getter and setter methods
        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }
        public string Passowrd
        {
            get { return mPassword; }
            set { mPassword = value; }
        }
        //Constructor
        public OnSignEventArgs(string email, string password)   : base() //the base calls the super class constructor which is EventArgs
        {
            Email = email;
            Passowrd = password;
        }


    }


    class Dialog_SignUp : DialogFragment
    {
        //Variables
        private EditText mEmail;
        private EditText mPassword;
        private Button mBtnDialogSignUp;
        //Variable to broadcast the event of our custom class
        public event EventHandler<OnSignEventArgs> mOnSignUpComplete;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate the fragmennt view of our dialog Sign Up
            var view = inflater.Inflate(Resource.Layout.dialog_signup, container, false);

            //Instantiate the object from the view
            mEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mBtnDialogSignUp = view.FindViewById<Button>(Resource.Id.btnDialogSignUpWithEmail);

            //Register the Sign UP button from the dialog fragment
            mBtnDialogSignUp.Click += (object sender, EventArgs e) =>
            {
                //User has click the sign up button from the dialog. He has requested to resgiter with the email
                //Broadcast to any subscriber that we got the request to subscribe the user
                mOnSignUpComplete.Invoke(this, new OnSignEventArgs(mEmail.Text, mPassword.Text));
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