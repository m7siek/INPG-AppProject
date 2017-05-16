using System;
using Foundation;
using Contacts;
using ContactsUI;
using UIKit;

namespace ContactAccess
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        partial void FindContact_TouchUpInside(UIButton sender, string FamilyName)
        {
            // Create predicate to locate requested contact
            var predicate = CNContact.GetPredicateForContacts(FamilyName);

            // Define fields to be searched
            var fetchKeys = new NSString[] { CNContactKey.GivenName, CNContactKey.FamilyName };

            // Grab matching contacts
            var store = new CNContactStore();
            NSError error;
            var contacts = store.GetUnifiedContacts(predicate, fetchKeys, out error);

            // Found?
            if (contacts.Length > 0)
            {
                // Get the first matching contact
                var contact = contacts[0];

                // Display it
                FoundContact.Text = string.Format("{0} {1}", contact.GivenName, contact.FamilyName);
            }
            else
            {
                // Not found
                FoundContact.Text = "";
            }
        }
    }
}