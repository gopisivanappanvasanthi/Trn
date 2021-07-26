using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.ContentSearch.Models;
using Sitecore.Data.Items;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Trn.Feature.ContentSearch.Controllers
{
    public class ArticleSearchController : Controller
    {
        // GET: SearchArticle
        public ActionResult Index()
        {
            string searchterm = string.Empty;
            searchterm = Request.QueryString["searchterm"];

            ArticleSearchInfo searchStr = new ArticleSearchInfo
            {
                SearchTermString = searchterm
            };
            return View(searchStr);
        }
        [HttpPost]
        public ActionResult Index(ArticleSearchInfo term)
        {
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            Item searchResultItem = homeItem?.Axes.GetDescendants()
                .Where(x => x.TemplateID == new Sitecore.Data.ID("{34220B76-0BF8-4D70-B09D-C3C4C8B7BAE1}"))
                ?.FirstOrDefault();

            string redirectUrl = LinkManager.GetItemUrl(searchResultItem);
            return Redirect(redirectUrl + "?searchterm=" + term.SearchTermString);
        }
    }
    }
