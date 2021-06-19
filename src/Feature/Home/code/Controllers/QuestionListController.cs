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
        [HttpGet]
        public ActionResult Index()
        {
            ID parentItemID = new ID("{8CFC3B0F-B415-4152-B097-F4F6F64D0080}");
            var masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master");
            var webDatabase = Sitecore.Configuration.Factory.GetDatabase("web");

            var parentItemFromMaster = masterDatabase.GetItem(parentItemID);

            var listofquestion = parentItemFromMaster.GetChildren()
                .Select(x => new QandA
                {
                    Question = x.Fields["question"].Value,
                    QuestionGuid = x.ID.ToString(),
                    answer = "",
                }).ToList();

            QuestionList questionList = new QuestionList
            {
                questions = listofquestion,
            };

            return View(questionList);
        }
    }
}