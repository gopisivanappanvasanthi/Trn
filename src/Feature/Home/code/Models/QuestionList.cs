﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Feature.Home.Models
{
    public class QuestionList
    {
        public List<QuestionList> questions { get; set; }
        public string answers { get; set; }
    }
}