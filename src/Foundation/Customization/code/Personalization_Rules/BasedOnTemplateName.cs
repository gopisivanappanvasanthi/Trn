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
    public class BasedOnTemplateName<T> : StringOperatorCondition<T> where T : RuleContext
    {
        public string Value { get; set; }
        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");
            Assert.IsNotNull(Tracker.Current, "Tracker.Current is not initialized");
            Assert.IsNotNull(Tracker.Current.Session, "Tracker.Current.Session is not initialized");
            Assert.IsNotNull(Tracker.Current.Session.Interaction, "Tracker.Current.Session.Interaction is not initialized");

            var currentItemTemplateName = ruleContext.Item.TemplateName;

            return Compare(currentItemTemplateName, Value);
        }
    }
}