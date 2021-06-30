using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Feature.Home.Models
{
    public class Answer
    {
        public string AnswerForQuestion { get; set; }

        public string QuestionId { get; set; }

        public bool MarkedasCorrect { get; set; }

        public bool IsValidAnswer { get; set; }
    }
}