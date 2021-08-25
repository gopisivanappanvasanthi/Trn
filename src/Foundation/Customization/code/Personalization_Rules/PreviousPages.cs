using System;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics;

namespace Trn.Foundation.Customization.Personalization_Rules
{
    public class PreviousPages<T> : WhenCondition<T> where T : RuleContext
    {
        public string PageId { get; set; }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull((object)ruleContext,"ruleContext");
            Assert.IsNotNull((object)Tracker.Current,"Tracker.Current is not initialized");
            Assert.IsNotNull((object)Tracker.Current.Session,"Tracker.Current.Session is not initialized");
            Assert.IsNotNull((object)Tracker.Current.Session.Interaction,"Tracker.Current.Session.Interaction is not initialized");

            var pageGuid = new Guid(this.PageId);
            return Tracker.Current.Session.Interaction.PreviousPage?.Item?.Id != null &&
                   Tracker.Current.Session.Interaction.PreviousPage.Item.Id == pageGuid;
        }
    }
}