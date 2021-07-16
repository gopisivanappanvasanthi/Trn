using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Feature.Search.Models
{
    public class TrnSearchResult
    {
        public string ResultTitle { get; set; }

        public string ResultDescription { get; set; }

        public string ResultRefUrl { get; set; }

        public HtmlString ResultImageCard { get; set; }
    }
}