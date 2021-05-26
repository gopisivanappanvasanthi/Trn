using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Project.TrnSite.Models
{
    public class Card
    {
        public string cardTitle { get; set; }
        public HtmlString cardImage { get; set; }
        public string url { get; set; }
    }
}