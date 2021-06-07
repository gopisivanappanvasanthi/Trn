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
    public class TrnSymposiumController : Controller
    {
        // GET: SampleTrn
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            SymposiumInfo symposiumInfo = new SymposiumInfo();

          
            symposiumInfo.SPOCPhoneNumber = new HtmlString(FieldRenderer.Render(contextItem, "SPOCPhoneNumber"));
            symposiumInfo.PaperSubmissionLastDate = new HtmlString(FieldRenderer.Render(contextItem, "PaperSubmissionLastDate"));
            symposiumInfo.SymposiumDescription = new HtmlString(FieldRenderer.Render(contextItem, "SymposiumDescription"));

            return View(symposiumInfo);
        }
    }
}