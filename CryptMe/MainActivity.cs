using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Content.Res;


namespace CryptMe
{
    [Activity(Label = "CryptMe", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            TextView inputTextView = FindViewById<TextView>(Resource.Id.InputTextView);

            string inputtext = inputTextView.Text;

            var buttons = new Button[40];

            // Declare handle and behaviour for axml buttons
            for (int i = 0; i < 40; i++)
            {
                string buttonID = "button";
                if (i >= 10 && i < 36)
                {
                    char ID = (char)(65 + i - 10);
                    buttonID += ID;
                }
                else if (i == 36) buttonID += "Space";
                else if (i == 37) buttonID += "BSP";
                else if (i == 38) buttonID += "Switch";
                else if (i == 39) buttonID += "Enter";
                else buttonID += i;

                int resID = Resources.GetIdentifier(buttonID, "id", "CryptMe.CryptMe");
                buttons[i] = (Button)FindViewById<Button>(resID);

                Button activebutton = buttons[i];
                

                if (i >= 0 && i <= 37)
                {
                    
                    buttons[i].Click += (object sender, EventArgs e) =>
                    {
                        inputTextView.Text = KeyPress.ModifyString(activebutton,inputTextView.Text);
                    };
                }
            }
        }
    }
}


