using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trn.Project.TrnSite.Controllers
{
    public class DynamicPlaceholderController : Controller
    {
        // GET: DynamicPlaceholder
        public ActionResult Index()
        {
            Database masterDB = Sitecore.Context.Database;
            Item studentsItem = masterDB.GetItem("{75F0BD78-BC6B-4F48-8A54-06588F42F025}");
            List<Item> students = studentsItem.GetChildren().ToList();
            return View(students);
        }
    }
}