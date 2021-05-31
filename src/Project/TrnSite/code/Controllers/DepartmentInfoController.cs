using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Project.TrnSite.Models;

namespace Trn.Project.TrnSite.Controllers
{
    public class DepartmentInfoController : Controller
    {
        // GET: DepartmentInfo
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            Department department = new Department
            {
                deptName = new HtmlString(FieldRenderer.Render(contextItem, "name")),
                deptAvtar = new HtmlString(FieldRenderer.Render(contextItem, "Avtar"))
            };

            return View(department);
        }
    }
}