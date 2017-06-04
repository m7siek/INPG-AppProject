using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CryptMe.Fragments
{
    public class Input : Fragment
    {
       
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Input, container, false);
            ISharedPreferences pref = Application.Context.GetSharedPreferences("Keys", FileCreationMode.Private);
            long RSA_n = pref.GetLong("RSA_n", -1);
            long RSA_e = pref.GetLong("RSA_e", -1);
            long RSA_d = pref.GetLong("RSA_d", -1);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            // Create Layouts and their elements handlers
            TextView inputTextView = view.FindViewById<TextView>(Resource.Id.InputTextView);


            var buttons = new Button[40];       // MainView buttons
            bool SwitchPressed = false;         // (Lower/Upper)case control

            long[] textOUT;

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

                int resID = Resources.GetIdentifier(buttonID, "id", "CryptMe.CryptMe");
                buttons[i] = view.FindViewById<Button>(resID);
            }

            foreach (Button pressed in buttons)
            {
                if(pressed.Id == Resource.Id.buttonSwitch)
                {
                    pressed.Click += (object sender, EventArgs e) =>
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
                else if (pressed.Id == Resource.Id.buttonEnter)
                {
                    pressed.Click += (object sender, EventArgs e) =>
                    {
                        if (RSA_d == -1 || RSA_n == -1)
                        {
                            Toast.MakeText(Application.Context, "Wystąpił problem przy generacji kluczy.\nZamykanie aplikacji", ToastLength.Long).Show();
                            //zamkniecie apki
                        }

                        var numbersIN = Encrypt.ZmienNaASCII(inputTextView.Text.ToCharArray(), inputTextView.Text.Length);
                        
                        textOUT = Encrypt.Kodowanie_RSA(numbersIN, RSA_e, RSA_n, inputTextView.Text.Length);

                        string textOutString = "";

                        foreach(long element in textOUT)
                        {
                            textOutString += element.ToString();
                        }


                        ISharedPreferences textPref = Application.Context.GetSharedPreferences("Encrypted", FileCreationMode.Private);
                        ISharedPreferencesEditor edit = textPref.Edit();
                        edit.PutString("TextOut", textOutString);
                        edit.Apply();

                        var trans = FragmentManager.BeginTransaction();

                        trans.Add(Resource.Id.FragmentContainer, new Output(), "OutputView");
                        trans.AddToBackStack(null);
                        trans.Commit();
                    };
                }
                else
                {
                    pressed.Click += (object sender, EventArgs e) =>
                    {
                        inputTextView.Text = KeyPress.ModifyString(pressed, inputTextView.Text);
                    };
                }
            }

            return view;
        }
    }
}