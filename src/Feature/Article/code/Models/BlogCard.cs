using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Feature.Article.Models
{
    public class BlogCard
    {
        public string blogTitle { get; set; }
        public HtmlString blogImage { get; set; }
        public string blogurl { get; set; }
    }
}