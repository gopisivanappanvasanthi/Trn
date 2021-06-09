using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trn.Feature.Students.Models;

namespace Trn.Feature.Students.Services
{
    public class SubjectDataServices
    {
        public SubjectsInfo GetSubjectInfo(Sitecore.Data.Items.Item item)
        {
            SubjectsInfo subjectsInfo = new SubjectsInfo();

            subjectsInfo.mainsub = new HtmlString(item.Fields["mainsub"].Value);
            subjectsInfo.alliedsub = new HtmlString(item.Fields["alliedsub"].Value);

            return subjectsInfo;
        }
    }
}