using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Students.Models;

namespace Trn.Feature.Students.Controllers
{
    public class HobbyInformationController : Controller
    {
        // GET: SampleTrn2
        public ActionResult Index()
        {

            var contextItem = Sitecore.Context.Item;

            HobbyInfo hobbyInfo = new HobbyInfo();

            hobbyInfo.sports = new HtmlString(FieldRenderer.Render(contextItem, "sports"));
            hobbyInfo.arts = new HtmlString(FieldRenderer.Render(contextItem, "arts"));
            return View(hobbyInfo);
        }
    }
}