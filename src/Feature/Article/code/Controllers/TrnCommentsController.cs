using Sitecore.Data;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Article.Models;
using Trn.Feature.Article.Repositories;
using Trn.Foundation.Publishing.Services;

namespace Trn.Feature.Article.Controllers
{
    public class TrnCommentsController : Controller
    {
        private ITrnCommentRepository trnCommentRepository;
        public TrnCommentsController(ITrnCommentRepository trnCommentRepository)
        {
            this.trnCommentRepository = trnCommentRepository;
        }
        //private Sitecore.Data.Items.Item item;

        [HttpGet]
        public ActionResult Index()
        {
            return View(trnCommentRepository.InitializeCoomment());
        }
        [HttpPost]
        public ActionResult Index(Comment inputComment)
        {

            //Database master = Sitecore.Configuration.Factory.GetDatabase("master");

            trnCommentRepository.AddComment(inputComment);
            return View("/Views/TrnComments/CommentsSummary.cshtml");
        }
    }
}