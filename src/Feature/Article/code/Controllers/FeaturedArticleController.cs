using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Article.Models;
using Trn.Feature.Article.Repositories;

namespace Trn.Feature.Article.Controllers
{
    public class FeaturedArticleController : Controller
    {
        private ITrnArticleRepository trnArticleRepository;
        public FeaturedArticleController(ITrnArticleRepository trnArticleRepository)
        {
            this.trnArticleRepository = trnArticleRepository;
        }
        // GET: FeaturedArticle
        public ActionResult Index()
        {

            return View(trnArticleRepository.GetArticleInfo(true));
        }
    }
}