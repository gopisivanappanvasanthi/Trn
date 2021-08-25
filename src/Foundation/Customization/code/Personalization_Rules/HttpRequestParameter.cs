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
    public class HttpRequestParameter<T> : StringOperatorCondition<T> where T : RuleContext

    {
        public string ParameterName
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
        
        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");
            if(string.IsNullOrEmpty(this.ParameterName) || string.IsNullOrEmpty(this.Value))
            {
                return false;
            }
            if (string.IsNullOrEmpty(HttpContext.Current.Request.Params.Get(this.ParameterName)))
            {
                return false;
            }
            return base.Compare(HttpContext.Current.Request.Params.Get(this.ParameterName), this.Value);
        }
    }
}