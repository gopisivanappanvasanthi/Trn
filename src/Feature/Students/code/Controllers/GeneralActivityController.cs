using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Students.Models;

namespace Trn.Feature.Students.Controllers
{
    public class GeneralActivityController : Controller
    {
        // GET: SampleTrn5
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            General general = new General();

            general.activityTitle = new HtmlString(FieldRenderer.Render(contextItem, "activityTitle"));
            general.activityDescription = new HtmlString(FieldRenderer.Render(contextItem, "activityDescription"));
            return View(general);
        }
    }
}