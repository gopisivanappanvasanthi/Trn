using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Feature.Departments.Models
{
    public class SymposiumCard
    {
        public string cardTitle { get; set; }
        public HtmlString cardImage { get; set; }
        public string url { get; set; }
    }
}