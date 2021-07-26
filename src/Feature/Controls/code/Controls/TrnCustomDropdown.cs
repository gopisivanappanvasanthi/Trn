using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web;

namespace Trn.Feature.Controls
{
    public class TrnCustomDropdown : Sitecore.Web.UI.HtmlControls.Control
    {
        public TrnCustomDropdown()
        {
            
        }
        protected override void DoRender(System.Web.UI.HtmlTextWriter output)
        {
            var keyValuePairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Key1", "Value1"),
                new KeyValuePair<string, string>("Key2", "Value2"),
                new KeyValuePair<string, string>("Key3", "Value3"),
                new KeyValuePair<string, string>("Key4", "Value4"),
                new KeyValuePair<string, string>("Key5", "Value5"),
            };
            output.Write("<select" + this.ControlAttributes + ">");
            foreach (var keyValuePair in keyValuePairs)
            {
                if (keyValuePair.Value == Value)
                {
                    output.Write($"<option value=\"{keyValuePair.Value}\" selected=\"selected\">{keyValuePair.Key}</option>");
                }
                else
                {
                    output.Write($"<option value=\"{keyValuePair.Value}\">{keyValuePair.Key}</option>");
                }
            }
            output.Write("</select>");
        }
        protected override bool LoadPostData(string value)
        {
            if (value == null)
                return false;
            if (this.GetViewStateString("Value") != value)
                Sitecore.Context.ClientPage.Modified = true;
            this.SetViewStateString("Value", value);
            return true;
        }
    }
}