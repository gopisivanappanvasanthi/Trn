using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Feature.Students.Models
{
    public class ProjectSub
    {
        public HtmlString ProjectTitle { get; set; }
        public HtmlString ProjectDescription { get; set; }
        public HtmlString ProjectDuration { get; set; }
        public HtmlString ProjectCost { get; set; }
        public HtmlString ProjectSubmissionDate { get; set; }
    }
}