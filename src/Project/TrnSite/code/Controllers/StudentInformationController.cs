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
    public class StudentInformationController : Controller
    {
        // GET: SampleTrn
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;



            MultilistField studentsGender = contextItem.Fields["gender"];
            MultilistField studentsInterest = contextItem.Fields["interests"];

            HtmlString gender = null;
            List<HtmlString> interests = new List<HtmlString>();


            foreach (var gen in studentsGender.GetItems())
            {
                gender = new HtmlString(FieldRenderer.Render(gen, "value"));
            }

            foreach (var interest in studentsInterest.GetItems())
            {
                var data = new HtmlString(FieldRenderer.Render(interest, "value"));
                interests.Add(data);
            }


            StudentsInfo studentsInfo = new StudentsInfo();

            studentsInfo.id = new HtmlString(FieldRenderer.Render(contextItem, "id"));
            studentsInfo.name = new HtmlString(FieldRenderer.Render(contextItem, "name"));
            studentsInfo.address = new HtmlString(FieldRenderer.Render(contextItem, "address"));
            studentsInfo.emailid = new HtmlString(FieldRenderer.Render(contextItem, "emailid"));
            studentsInfo.phone = new HtmlString(FieldRenderer.Render(contextItem, "phone"));
            studentsInfo.studentAvtar = new HtmlString(FieldRenderer.Render(contextItem, "Avtar"));
            studentsInfo.gender = gender;
            studentsInfo.interests = interests;
            return View(studentsInfo);
        }
    }
}