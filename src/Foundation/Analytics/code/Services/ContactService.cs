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
                            if (contact.Personal() != null)
                            {
                                contact.Personal().FirstName = user.FirstName?? string.Empty;
                                contact.Personal().MiddleName = user.MiddleName?? string.Empty;
                                contact.Personal().LastName = user.LastName?? string.Empty;
                                contact.Personal().Gender = user.Gender?? string.Empty;
                                contact.Personal().JobTitle = user.JobTitle?? string.Empty;
                            }
                            else
                            {
                                client.SetFacet<PersonalInformation>(contact, PersonalInformation.DefaultFacetKey, new PersonalInformation()
                                {
                                    FirstName = user.FirstName ?? string.Empty,
                                    MiddleName = user.MiddleName?? string.Empty,
                                    LastName = user.LastName?? string.Empty,
                                    Gender = user.Gender?? string.Empty,
                                    JobTitle = user.JobTitle?? string.Empty
                                });
                            }
                            if (contact.PhoneNumbers() != null)
                            {
                                contact.PhoneNumbers().PreferredPhoneNumber = new Sitecore.XConnect.Collection.Model.PhoneNumber(string.Empty, user.Phone?? string.Empty);
                            }
                            else
                            {
                                client.SetFacet<PhoneNumberList>(contact, PhoneNumberList.DefaultFacetKey, new PhoneNumberList(new PhoneNumber(string.Empty,user.Phone?? string.Empty), "mobile"));
                            }
                            if (contact.Emails() != null)
                            {
                                contact.Emails().PreferredEmail = new EmailAddress(user.EmailAddress, true);
                            }
                            else
                            {
                                client.SetFacet<EmailAddressList>(contact, EmailAddressList.DefaultFacetKey, new EmailAddressList(new EmailAddress(user.EmailAddress, true), "email"));
                            }
                            client.AddContactIdentifier(contact, new Sitecore.XConnect.ContactIdentifier(Constants.Analytics.KnownUserContactIdentifier, Sitecore.Analytics.Tracker.Current.Contact.ContactId.ToString("N"), Sitecore.XConnect.ContactIdentifierType.Known));
                            //client.AddContactIdentifier(contact, new Sitecore.XConnect.ContactIdentifier("Known-User", user.EmailAddress, Sitecore.XConnect.ContactIdentifierType.Known));
                            client.Submit();
                            // Remove contact data from shared session state - contact will be re-loaded
                            // during subsequent request with updated facets
                            manager.RemoveFromSession(Tracker.Current.Contact.ContactId);
                            Tracker.Current.Session.Contact = manager.LoadContact(Tracker.Current.Contact.ContactId);
                            AddGoal(Constants.Analytics.KnownUserContactIdentifier, Constants.Analytics.GoalId);
                            AddOutcome(Constants.Analytics.KnownUserContactIdentifier, Constants.Analytics.OutcomeId);
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
        public bool IsKnownContact(string identifier)
        {
            try
            {
                var manager = Sitecore.Configuration.Factory.CreateObject("tracking/contactManager", true) as Sitecore.Analytics.Tracking.ContactManager;

                if (manager != null)
                {
                    if (Sitecore.Analytics.Tracker.Current.Contact.IsNew)
                    {
                        Sitecore.Analytics.Tracker.Current.Contact.ContactSaveMode = ContactSaveMode.AlwaysSave;
                        manager.SaveContactToCollectionDb(Sitecore.Analytics.Tracker.Current.Contact);
                    }

                    var trackerIdentifier = new IdentifiedContactReference(identifier, Sitecore.Analytics.Tracker.Current.Contact.ContactId.ToString("N"));
                    using (var client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
                    {
                        var contact = client.Get<Sitecore.XConnect.Contact>(trackerIdentifier, new Sitecore.XConnect.ContactExpandOptions());
                        if (contact != null)
                        {
                            return contact.IsKnown;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error("xProfile : Error while featching contact info", ex, this);
            }
            return false;
        }
        protected void AddInteraction(string identifier,Event eventType)
        {
            try
            {
                var manager = Sitecore.Configuration.Factory.CreateObject("tracking/contactManager", true) as Sitecore.Analytics.Tracking.ContactManager;

                if (manager != null)
                {
                    if (Sitecore.Analytics.Tracker.Current.Contact.IsNew)
                    {
                        Sitecore.Analytics.Tracker.Current.Contact.ContactSaveMode = ContactSaveMode.AlwaysSave;
                        manager.SaveContactToCollectionDb(Sitecore.Analytics.Tracker.Current.Contact);
                    }

                    var trackerIdentifier = new IdentifiedContactReference(identifier, Sitecore.Analytics.Tracker.Current.Contact.ContactId.ToString("N"));
                    using (var client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
                    {
                        var contact = client.Get<Sitecore.XConnect.Contact>(trackerIdentifier, new Sitecore.XConnect.ContactExpandOptions());

                        if (contact != null)
                        {
                            var channelId = Guid.Parse(Constants.Analytics.ChannelId);

                            var interaction = new Interaction(contact, InteractionInitiator.Contact, channelId, Constants.Analytics.UserAgent);

                            interaction.Events.Add(eventType);

                            client.AddInteraction(interaction);
                            client.Submit();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error("xProfile : Error while adding Interaction", ex, this);
            }
        }
        public void AddPageEvent(string identifier, string pageId)
        {
            var definitionId = Guid.Parse(pageId);
            var pageView = new PageViewEvent(DateTime.UtcNow, definitionId, 1, "en");
            AddInteraction(identifier, pageView);
        }
        public void AddGoal(string identifier, string goalId)
        {
            var definitionId = Guid.Parse(goalId);
            var goal = new Goal(definitionId, DateTime.UtcNow);
            AddInteraction(identifier, goal);
        }
        public void AddOutcome(string identifier, string outcomeId)
        {
            var definitionId = Guid.Parse(outcomeId);
            var outcome = new Outcome(definitionId, DateTime.UtcNow, "USD", 42.95m);
            AddInteraction(identifier, outcome);
        }

    }
}