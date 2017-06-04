using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using Android.Views;

namespace CryptMe
{
    [Activity(Label = "CryptMe", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        public long RSA_n = KeyGen.N();
        public long RSA_e = KeyGen.E();
        public long RSA_d = KeyGen.D();


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ISharedPreferences pref = Application.Context.GetSharedPreferences("Keys", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();

            edit.PutLong("RSA_n", RSA_n);
            edit.PutLong("RSA_e", RSA_e);
            edit.PutLong("RSA_d", RSA_d);
            edit.Apply();

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);

            var trans = FragmentManager.BeginTransaction();

            trans.Add(Resource.Id.FragmentContainer, new Fragments.Input(), "InputView");
            trans.Commit();



            

            
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.AppMenu, menu);
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.NewKeys:
                    RSA_n = KeyGen.N();
                    RSA_e = KeyGen.E();
                    RSA_d = KeyGen.D();

                    ISharedPreferences pref = Application.Context.GetSharedPreferences("Keys", FileCreationMode.Private);
                    ISharedPreferencesEditor edit = pref.Edit();

                    edit.PutLong("RSA_n", RSA_n);
                    edit.PutLong("RSA_e", RSA_e);
                    edit.PutLong("RSA_d", RSA_d);
                    edit.Apply();

                    return true;

                case Resource.Id.ShowKeys:
                    Toast.MakeText(this, "Klucz publiczny: ("+RSA_n.ToString()+", "+RSA_e.ToString()+ ")\n" +
                                         "Klucz prywatny: (" + RSA_n.ToString() + ", " + RSA_d.ToString() + ")", ToastLength.Long).Show();
                    return true;

                case Resource.Id.CopyKeys:
                    ClipboardManager clipboard = (ClipboardManager)GetSystemService(Context.ClipboardService);
                    ClipData clip = ClipData.NewPlainText("Klucze", "Klucz publiczny: (" + RSA_n.ToString() + ", " + RSA_e.ToString() + ")\n" +
                                                                    "Klucz prywatny: (" + RSA_n.ToString() + ", " + RSA_d.ToString() + ")");

                    clipboard.PrimaryClip = clip;

                    Toast.MakeText(this, "Skopiowano do schowka", ToastLength.Long).Show();

                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}


