
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Article.Models;
using Sitecore.Web.UI.WebControls;
using Trn.Feature.Article.Repositories;

namespace Trn.Feature.Article.Controllers
{
    public class TrnArticleController : Controller
    {
        private ITrnArticleRepository trnArticleRepository;
        public TrnArticleController(ITrnArticleRepository trnArticleRepository)
        {
            this.trnArticleRepository = trnArticleRepository;
        }
        // GET: article
        public ActionResult Index()
        {
            return View(trnArticleRepository.GetArticleInfo());
        }
    }
}
