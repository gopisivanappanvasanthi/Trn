using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.ContentSearch.Models;

namespace Trn.Feature.ContentSearch.Controllers
{
    public class TrnSearchController : Controller
    {
        // GET: TrnSearch
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            TrnSearchInfo Trnsearch = new TrnSearchInfo
            {
                PageTitle = new HtmlString(FieldRenderer.Render(contextItem, "PageTitle")),
                
            };

            return View(Trnsearch);
        }
    }
}