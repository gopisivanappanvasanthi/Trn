using Sitecore.Links;
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
    public class TrnBlogListController : Controller
    {
        private ITrnBlogRepository trnBlogRepository;
        public TrnBlogListController(ITrnBlogRepository trnBlogRepository)
        {
            this.trnBlogRepository = trnBlogRepository;
        }
        // GET: TrnBlogList
        public ActionResult Index()
        {
            return View(trnBlogRepository.GetBlogsList());
        }
    }
}