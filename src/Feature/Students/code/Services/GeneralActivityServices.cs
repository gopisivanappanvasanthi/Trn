using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trn.Feature.Students.Models;
using Sitecore.Web.UI.WebControls;

namespace Trn.Feature.Students.Services
{
    public class GeneralActivityServices
    {
        public General GetGeneralActivityData(Sitecore.Data.Items.Item item)    
        {
            General general = new General();

            general.activityTitle = new HtmlString(item.Fields["activityTitle"].Value);
            general.activityDescription = new HtmlString(item.Fields["activityDescription"].Value);

            return general;
        }
    }
}