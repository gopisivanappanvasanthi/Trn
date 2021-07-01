using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Departments.Models;

namespace Trn.Feature.Departments.Controllers
{
    public class TrnHighlightsController : Controller
    {
        
        // GET: TrnHighlights
        public ActionResult Index()
        {
            var contextItem = RenderingContext.Current.Rendering.Item;
            PageInfo page = new PageInfo
            { PageTitle = new HtmlString(FieldRenderer.Render(contextItem, "PageTitle")),
                PageBrief = new HtmlString(FieldRenderer.Render(contextItem, "PageBrief")),
                Url = LinkManager.GetItemUrl(contextItem)
            };
     
            return View(page);
        }
    }
}