using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Feature.Home.Models
{
    public class QandA
    {
        public string Question { get; set; }
        public string QuestionGuid { get; set; }
        public List<Answer> Answers { get; set; }
        public bool QandAHasChildren { get; set; }


    }
}