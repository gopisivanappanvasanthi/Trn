using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Students.Models;
using Trn.Feature.Students.Services;

namespace Trn.Feature.Students.Controllers
{
    public class GeneralActivityController : Controller
    {
        // GET: SampleTrn5
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            GeneralActivityServices generalActivityServices = new GeneralActivityServices();
            General general = generalActivityServices.GetGeneralActivityData(contextItem);

            return View(general);
        }
    }
}