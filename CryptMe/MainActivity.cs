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

            
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            // Create Layouts and their elements handlers
            TextView inputTextView = FindViewById<TextView>(Resource.Id.InputTextView);
            TextView outputTextView = FindViewById<TextView>(Resource.Id.OutTextView);
            LinearLayout MainView = FindViewById<LinearLayout>(Resource.Id.MainViewLayout);
            LinearLayout TranslatedView = FindViewById<LinearLayout>(Resource.Id.TranslatedLayout);

            var buttons = new Button[40];       // MainView buttons
            bool SwitchPressed = false;         // (Lower/Upper)case control

            long[] textOUT;

            long RSA_n = KeyGen.N();
            long RSA_e = KeyGen.E();
            long RSA_d = KeyGen.D();


            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            for (int i = 0; i < 40; i++)                    // Declare handle and behaviour for axml buttons
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

                long temp = KeyGen.N();

                int resID = Resources.GetIdentifier(buttonID, "id", "CryptMe.CryptMe");
                buttons[i] = (Button)FindViewById<Button>(resID);

                Button activebutton = buttons[i];


                if (i >= 0 && i <= 37)
                {

                    buttons[i].Click += (object sender, EventArgs e) =>
                    {
                        inputTextView.Text = KeyPress.ModifyString(activebutton, inputTextView.Text);
                    };
                }
                else if (i == 38)
                {
                    buttons[i].Click += (object sender, EventArgs e) =>
                    {
                        if (SwitchPressed == false)
                        {
                            for (int j = 10; j < 36; j++)
                            {
                                buttons[j].Text = buttons[j].Text.ToLower();
                            }
                            SwitchPressed = true;
                        }
                        else
                        {
                            for (int j = 10; j < 36; j++)
                            {
                                buttons[j].Text = buttons[j].Text.ToUpper();
                            }
                            SwitchPressed = false;
                        }
                    };
                }
                else if (i == 39)
                {
                    buttons[i].Click += (object sender, EventArgs e) =>
                    {
                        // POCZĄTEK BLOKU
                        // Kod poniżej jest jedynie wersją testową

                        textOUT = Encrypt.Kodowanie_RSA(Encrypt.ZmienNaASCII(inputTextView.Text.ToCharArray(), inputTextView.Text.Length), RSA_e, RSA_n, inputTextView.Text.Length);
                        MainView.Visibility = Android.Views.ViewStates.Invisible;
                        TranslatedView.Visibility = Android.Views.ViewStates.Visible;
                        outputTextView.Text = textOUT.ToString();

                        // KONIEC BLOKU
                    };
                }
            }
        }
    }
}


