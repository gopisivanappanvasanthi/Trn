using Sitecore.Mvc.Controllers;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Project.TrnSite.Models;

namespace Trn.Project.TrnSite.Controllers
{
    public class SubjectInformationController : Controller
    {
        // GET: SampleTrn1
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            SubjectsInfo subjectsInfo = new SubjectsInfo();

            subjectsInfo.mainsub = new HtmlString(FieldRenderer.Render(contextItem, "mainsub"));
            subjectsInfo.alliedsub = new HtmlString(FieldRenderer.Render(contextItem, "alliedsub"));

            return View(subjectsInfo);
        }
    }
}