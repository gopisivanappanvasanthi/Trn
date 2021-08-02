using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Project.TrnSite.Models;

namespace Trn.Project.TrnSite.Controllers
{
    public class StaticPageController : Controller
    {
        // GET: StaticPage
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            StaticPageInfo staticPage = new StaticPageInfo();
            staticPage.Title = new HtmlString(FieldRenderer.Render(contextItem, "Title"));
            staticPage.Description = new HtmlString(FieldRenderer.Render(contextItem, "Description"));            
            return View(staticPage);
        }
    }
}