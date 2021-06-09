using Sitecore.Mvc.Controllers;
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
    public class SubjectInformationController : Controller
    {
        // GET: SampleTrn1
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            SubjectDataServices subjectDataServices = new SubjectDataServices();

            return View(subjectDataServices.GetSubjectInfo(contextItem));
        }
    }
}