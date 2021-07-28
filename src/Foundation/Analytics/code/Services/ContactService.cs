using Sitecore.Analytics;
using Sitecore.Analytics.Model;
using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trn.Foundation.Analytics.Models;

namespace Trn.Foundation.Analytics.Services
{
    public class ContactService : IContactService
    {
        public bool CreateContact(UserModel user)
        {
            var manager = Sitecore.Configuration.Factory.CreateObject("tracking/contactManager", true) as Sitecore.Analytics.Tracking.ContactManager;

            if (manager != null)
            {
                if (Sitecore.Analytics.Tracker.Current.Contact.IsNew)
                {
                    Sitecore.Analytics.Tracker.Current.Contact.ContactSaveMode = ContactSaveMode.AlwaysSave;
                    manager.SaveContactToCollectionDb(Sitecore.Analytics.Tracker.Current.Contact);
                }
                var trackerIdentifier = new IdentifiedContactReference(Sitecore.Analytics.XConnect.DataAccess.Constants.IdentifierSource, Sitecore.Analytics.Tracker.Current.Contact.ContactId.ToString("N"));

                using (XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
                {
                    try
                    {
                        var contact = client.Get<Sitecore.XConnect.Contact>(trackerIdentifier, new Sitecore.XConnect.ContactExpandOptions());

                        if (contact != null)
                        {
                            //var imageUrl = "https://toppsta.com/images/profile-pictures/4743?t=1544008711";
                            //var webClient = new System.Net.WebClient();
                            //// Download data from URL
                            //byte[] imageBytes = webClient.DownloadData(imageUrl);
                            //string myType= "image/jpeg";
                            //client.SetFacet<Avatar>(contact, Avatar.DefaultFacetKey, new Avatar(myType, imageBytes)
                            //{
                            //    MimeType= myType,
                            //    Picture=imageBytes
                            //});

                            if (contact.Personal() != null)
                            {
                                contact.Personal().FirstName = user.FirstName;
                                contact.Personal().MiddleName = user.MiddleName;
                                contact.Personal().LastName = user.LastName;
                                contact.Personal().Gender = user.Gender;
                                contact.Personal().JobTitle = user.JobTitle;
                            }
                            else
                            {
                                client.SetFacet<PersonalInformation>(contact, PersonalInformation.DefaultFacetKey, new PersonalInformation()
                                {
                                    FirstName = user.FirstName,
                                    MiddleName = user.MiddleName,
                                    LastName = user.LastName,
                                    Gender = user.Gender,
                                    JobTitle = user.JobTitle
                                });
                            }
                            if (contact.PhoneNumbers() != null)
                            {
                                contact.PhoneNumbers().PreferredPhoneNumber = new Sitecore.XConnect.Collection.Model.PhoneNumber(string.Empty, user.Phone);
                            }
                            else
                            {
                                client.SetFacet<PhoneNumberList>(contact, PhoneNumberList.DefaultFacetKey, new PhoneNumberList(new PhoneNumber(string.Empty,user.Phone), "mobile"));
                            }
                            if (contact.Emails() != null)
                            {
                                contact.Emails().PreferredEmail = new EmailAddress(user.EmailAddress, true);
                            }
                            else
                            {
                                client.SetFacet<EmailAddressList>(contact, EmailAddressList.DefaultFacetKey, new EmailAddressList(new EmailAddress(user.EmailAddress, true), "email"));
                            }
                            client.AddContactIdentifier(contact, new Sitecore.XConnect.ContactIdentifier("Known-User", user.EmailAddress, Sitecore.XConnect.ContactIdentifierType.Known));
                            client.Submit();
                            // Remove contact data from shared session state - contact will be re-loaded
                            // during subsequent request with updated facets
                            manager.RemoveFromSession(Tracker.Current.Contact.ContactId);
                            Tracker.Current.Session.Contact = manager.LoadContact(Tracker.Current.Contact.ContactId);
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Error saving data to xProfile", ex, this);
                    }
                }
            }
            return false;
        }
    }
}