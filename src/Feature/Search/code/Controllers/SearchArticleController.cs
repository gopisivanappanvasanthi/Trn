using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Search.Models;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace Trn.Feature.Search.Controllers
{
    public class SearchArticleController : Controller
    {
        // GET: SearchForm
        public ActionResult Index()
        {
            string searchterm = string.Empty;
            searchterm = Request.QueryString["searchterm"];

            SearchTerm searchStr = new SearchTerm
            {
                SearchTermString = searchterm
            };
            return View(searchStr);
        }
        [HttpPost]
        public ActionResult Index(SearchTerm term)
        {
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            Item searchResultItem = homeItem?.Axes.GetDescendants()
                .Where(x => x.TemplateID == new Sitecore.Data.ID("{45020A57-CF69-4049-A922-797FF524160C}"))
                ?.FirstOrDefault();

            string redirectUrl = LinkManager.GetItemUrl(searchResultItem);
            return Redirect(redirectUrl + "?searchterm=" + term.SearchTermString);
        }
    }
}