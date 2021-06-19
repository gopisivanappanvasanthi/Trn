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
            QuestionList questionList = new QuestionList
            {

            };

            return View();
        }
    }
}