using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Project.TrnSite.Models;

namespace Trn.Project.TrnSite.Controllers
{
    public class AwardsInfoController : Controller
    {
        // GET: SampleTrn6
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            MultilistField multilistField = contextItem.Fields["awardInfo"];
            var multilistItemsFromAwardInfoField = multilistField
                                                     .GetItems()
                                                      .Select(item => new Awards
                                                      {
                                                          awardTitle = new HtmlString(FieldRenderer.Render(item, "awardTitle")),
                                                          awardDescription = new HtmlString(FieldRenderer.Render(item, "awardDescription")),
                                                          awardImage = new HtmlString(FieldRenderer.Render(item, "awardImage")),
                                                          awardCommemoration = new HtmlString(FieldRenderer.Render(item, "awardCommemoration")),

                                                      });
            return View(multilistItemsFromAwardInfoField);
        }
    }
}