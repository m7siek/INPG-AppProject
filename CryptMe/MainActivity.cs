using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace CryptMe
{
    [Activity(Label = "CryptMe", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            TextView inputTextView = FindViewById<EditText>(Resource.Id.InputTextView);
            Button button_q = FindViewById<Button>(Resource.Id.buttonQ);

            /*button_q.Click += (object sender, EventArgs e) =>
            {
                inputTextView.Text += "Q";
            };*/
            
        }
    }
}

