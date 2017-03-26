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
        private string mNewPassword;
        private string mConfirmPassword;

        //Getter and setter methods
        public string NewPassword
        {
            get { return mNewPassword; }
            set { mNewPassword = value; }
        }
        public string ConfirmPassword
        {
            get { return mConfirmPassword; }
            set { mConfirmPassword = value; }
        }
        //Constructor
        public OnSignEventArgs(string newPassword, string confirmPassword)   : base() //the base calls the super class constructor which is EventArgs
        {
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;
        }


    }


    class Dialog_SignUp : DialogFragment
    {
        //Variables
        private EditText mNewPassword;
        private EditText mConfirmPassword;
        private Button mBtnDialogSignUp;
        //Variable to broadcast the event of our custom class
        public event EventHandler<OnSignEventArgs> mOnSignUpComplete;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate the fragmennt view of our dialog Sign Up
            var view = inflater.Inflate(Resource.Layout.dialog_signup, container, false);

            //Instantiate the object from the view
            mNewPassword = view.FindViewById<EditText>(Resource.Id.txtNewPassword);
            mConfirmPassword = view.FindViewById<EditText>(Resource.Id.txtConfirmPassword);
            mBtnDialogSignUp = view.FindViewById<Button>(Resource.Id.btnSubmit);

            //Register the Sign UP button from the dialog fragment
            mBtnDialogSignUp.Click += (object sender, EventArgs e) =>
            {
                //User has click the sign up button from the dialog. He has requested to resgiter with the email
                //Broadcast to any subscriber that we got the request to subscribe the user
                mOnSignUpComplete.Invoke(this, new OnSignEventArgs(mNewPassword.Text, mConfirmPassword.Text));
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