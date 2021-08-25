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
    public class PersonalizeModelName<T> : StringOperatorCondition<T> where T : RuleContext
    {
        public string Value { get; set; }
        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");
            HttpCookie customCookie = HttpContext.Current.Request.Cookies["Custom_Personalization"];
            if (Value.ToLower().Equals(customCookie.Value.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}