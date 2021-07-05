using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Feature.Departments.Models
{

    public class PageInfo
    {
        public HtmlString PageTitle { get; set; }
        public HtmlString PageBrief { get; set; }

        public String Url { get; set; }
    }
}