using System;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics;
using Sitecore;

namespace Trn.Foundation.Customization.Personalization_Rules
{
    public class DateCompareRule<T> : OperatorCondition<T> where T : RuleContext
    {
        public string DateFieldOne { get; set; }

        public string DateFieldTwo { get; set; }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull((object)ruleContext, "ruleContext");

            if (!IsDate(DateFieldOne) || !IsDate(DateFieldTwo))
                return false;

            ConditionOperator conditionOperator = base.GetOperator();

            return DateComparer(DateUtil.ParseDateTime(DateFieldOne, DateTime.MinValue), DateUtil.ParseDateTime(DateFieldTwo, DateTime.MinValue), conditionOperator);
        }

        private bool IsDate(string date)
        {
            DateTime tempDate;
            return DateTime.TryParse(date, out tempDate);
        }

        private bool DateComparer(DateTime date1, DateTime date2, ConditionOperator conditionOperator)
        {

            switch (conditionOperator)
            {
                case ConditionOperator.Equal:
                    return date1.Equals(date2);
                case ConditionOperator.LessThan:
                    return date1 < date2;
                case ConditionOperator.LessThanOrEqual:
                    return date1 <= date2;
                case ConditionOperator.GreaterThan:
                    return date1 > date2;
                case ConditionOperator.GreaterThanOrEqual:
                    return date1 >= date2;
                case ConditionOperator.NotEqual:
                    return !date1.Equals(date2);
                default:
                    return false;
            }

        }
    }
}