using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace CryptMe
{
    public static class KeyPress
    {
        public static string ModifyString(Button sender, string text)
        {

            if (sender.Id == Resource.Id.buttonSpace) return text+" ";
            else if (sender.Id == Resource.Id.buttonBSP) return text.Remove(text.Length - 1);
            else return text+sender.Text;
        }
    }
}