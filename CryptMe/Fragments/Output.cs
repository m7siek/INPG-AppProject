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
    public class Output : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);			
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Output, container, false);

            ISharedPreferences pref = Application.Context.GetSharedPreferences("Encrypted", FileCreationMode.Private);

            TextView outputTextView = view.FindViewById<TextView>(Resource.Id.textOutView);

            outputTextView.Text = pref.GetString("TextOut", "Text");

            outputTextView.Click += (object sender, EventArgs e) =>
            {
                ClipboardManager clipboard = (ClipboardManager)Application.Context.GetSystemService(Context.ClipboardService);
                ClipData clip = ClipData.NewPlainText("Krypto", outputTextView.Text);

                clipboard.PrimaryClip = clip;

                Toast.MakeText(Application.Context, "Skopiowano kod liczbowy do schowka", ToastLength.Long).Show();
            };

            return view;
        }
    }
}