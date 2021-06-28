using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Home.Models;

namespace Trn.Feature.Home.Controllers
{
    public class QuestionListController : Controller
    {
        // GET: QuestionList
        public ActionResult Index()
        {
            ID parentItemID = new ID("{8CFC3B0F-B415-4152-B097-F4F6F64D0080}");
            var masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master");
            var webDatabase = Sitecore.Configuration.Factory.GetDatabase("web");
            var parentItemFromMaster = masterDatabase.GetItem(parentItemID);

            var listOfQuestions = parentItemFromMaster.GetChildren()
                                      .Select(qtn => new QandA
                                      {
                                          Question = qtn.Fields["question"].Value,
                                          QuestionGuid = qtn.ID.ToString(),
                                          Answers = GetListOfAnswers(qtn),
                                          QandAHasChildren = qtn.HasChildren,
                                      }).ToList();

            QuestionList questionList = new QuestionList
            {
                questions = listOfQuestions
            };

            return View(questionList);
        }
        [HttpPost]
        public ActionResult Index(QuestionList questionList)
        {
            return View("/Views/QuestionList/AnswerSummary.cshtml");
        }

        private List<Answer> GetListOfAnswers(Sitecore.Data.Items.Item ques)
        {
            List<Answer> answers = new List<Answer>();

            if (ques.HasChildren)
            {
                answers = ques.GetChildren()
                            .Select(ans => new Answer
                            {
                                AnswerForQuestion = ans.Fields["answer"].Value,
                                QuestionId = ans.ID.ToString(),
                                MarkedasCorrect = Convert.ToBoolean(ans.Fields["markascorrect"].Value == "1" ? "true" : "false", null),
                                IsValidAnswer = true
                            }).Concat(new List<Answer>() { new Answer
                            {
                                AnswerForQuestion = "",
                                QuestionId = ques.ID.ToString(),
                                MarkedasCorrect = false,
                                IsValidAnswer = false
                            }}).ToList();
            }
            else
            {
                answers = new List<Answer>()
                {
                    new Answer
                    {
                        AnswerForQuestion = "",
                        QuestionId = ques.ID.ToString(),
                        MarkedasCorrect = false,
                        IsValidAnswer = false
                    }
                };
            }
            return answers;
        }
    }
}