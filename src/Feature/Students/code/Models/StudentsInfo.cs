using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Feature.Students.Models
{

    public class StudentsInfo
    {
        public HtmlString id { get; set; }
        public HtmlString name { get; set; }
        public HtmlString address { get; set; }
        public HtmlString emailid { get; set; }
        public HtmlString phone { get; set; }

        public HtmlString studentAvtar { get; set; }
        public HtmlString gender { get; set; }
        public List<HtmlString> interests { get; set; }
    

}
}