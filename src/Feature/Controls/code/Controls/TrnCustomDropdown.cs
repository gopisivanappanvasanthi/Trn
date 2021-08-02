using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web;
using Trn.Feature.Controls.Model;
using Newtonsoft.Json;
using System.Web.UI.MobileControls;
using System.Windows.Documents;

namespace Trn.Feature.Controls
{
    public class TrnCustomDropdown : Sitecore.Web.UI.HtmlControls.Control
    {
        public TrnCustomDropdown()
        {

        }
        protected override void DoRender(System.Web.UI.HtmlTextWriter output)
        {
            //code for static data

            //var keyValuePairs = new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("Key1", "Value1"),
            //    new KeyValuePair<string, string>("Key2", "Value2"),
            //    new KeyValuePair<string, string>("Key3", "Value3"),
            //    new KeyValuePair<string, string>("Key4", "Value4"),
            //    new KeyValuePair<string, string>("Key5", "Value5"),
            //};
            //output.Write("<select" + this.ControlAttributes + ">");
            //foreach (var keyValuePair in keyValuePairs)
            //{
            //    if (keyValuePair.Value == Value)
            //    {
            //        output.Write($"<option value=\"{keyValuePair.Value}\" selected=\"selected\">{keyValuePair.Key}</option>");
            //    }
            //    else
            //    {
            //        output.Write($"<option value=\"{keyValuePair.Value}\">{keyValuePair.Key}</option>");
            //    }
            //}

            //Json File dropdown
            List<IndianStates> KeyValuePairs = GetData();
            output.Write("<select" + this.ControlAttributes + ">");
            foreach (var keyValuePair in KeyValuePairs)
            {
                if (keyValuePair.code == Value)
                {
                    output.Write($"<option value=\"{keyValuePair.code}\" selected=\"selected\">{keyValuePair.name}</option>");
                }
                else
                {
                    output.Write($"<option value=\"{keyValuePair.code}\">{keyValuePair.name}</option>");
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

        private List<IndianStates> GetData()
        {
            //StreamReader r = new StreamReader(@"IndianStates.json");
            StreamReader r = new StreamReader("C:/inetpub/wwwroot/sc93sc.dev.local/IndianStates.json");  
            string jsonString = r.ReadToEnd();
            //List<string, string> keyValuePair = JsonConvert.DeserializeObject<List<string, string>>(jsonString);
            List<IndianStates> keyValuePair = JsonConvert.DeserializeObject<List<IndianStates>>(jsonString).ToList();
            return keyValuePair;
        }
    }
}