using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data;
using Trn.Feature.Article.Models;
using Trn.Feature.Article.Repositories;

namespace Trn.Feature.Article.Controllers
{
    public class TrnCommentsListController : Controller
    {
        private ITrnCommentRepository trnCommentRepository;
        public TrnCommentsListController(ITrnCommentRepository trnCommentRepository)
        {
            this.trnCommentRepository = trnCommentRepository;
        }

        // GET: TrnArticleList
        public ActionResult Index()
        {
            return View(trnCommentRepository.GetComments());
        }
       
    }
}