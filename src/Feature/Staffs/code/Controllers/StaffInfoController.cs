using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Staffs.Models;

namespace Trn.Feature.Staffs.Controllers
{
    public class StaffInfoController : Controller
    {
        // GET: StaffInfo
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            Staff staff = new Staff
            {
                staffName = new HtmlString(FieldRenderer.Render(contextItem, "name")),
                staffDesignation = new HtmlString(FieldRenderer.Render(contextItem, "staffDesignation")),
                staffExperience = new HtmlString(FieldRenderer.Render(contextItem, "staffExperience")),
                staffAvtar = new HtmlString(FieldRenderer.Render(contextItem, "Avtar"))
            };

            return View(staff);
        }
    }
}