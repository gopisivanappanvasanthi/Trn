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
    public class Cookie<T> : WhenCondition<T> where T : RuleContext
    {
        public string CookieName { get; set; }
        protected override bool Execute(T ruleContext)
        {
            if (string.IsNullOrEmpty(CookieName))
                return false;
            return HttpContext.Current.Request.Cookies[CookieName] != null;
        }
    }
}