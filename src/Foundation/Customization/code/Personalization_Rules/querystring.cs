using System;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Foundation.Customization.Personalization_Rules
{
    public class querystring<T>: StringOperatorCondition<T> where T : RuleContext
    {
        public string querystringvalue { get; set; }
        protected override bool Execute(T ruleContext)
        {
            bool isPersonalized = false;
            Assert.ArgumentNotNull(ruleContext, "ruleContext");
            var queryStringValueFromRule = this.querystringvalue;
            var queryStringValueFromURL = HttpContext.Current.Request.QueryString["search"];
            if(queryStringValueFromURL==queryStringValueFromRule)
            {
                return true;
            }
            return isPersonalized;
        }
    }
}