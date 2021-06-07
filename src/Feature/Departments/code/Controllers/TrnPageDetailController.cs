using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Departments.Models;

namespace Trn.Feature.Departments.Controllers
{
    public class TrnPageDetailController : Controller
    {
        // GET: SampleTrn
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            PageInfo pageInfo = new PageInfo();

            pageInfo.PageTitle = new HtmlString(FieldRenderer.Render(contextItem, "PageTitle"));
            pageInfo.PageBrief = new HtmlString(FieldRenderer.Render(contextItem, "PageBrief"));


            return View(pageInfo);
        }
    }
}