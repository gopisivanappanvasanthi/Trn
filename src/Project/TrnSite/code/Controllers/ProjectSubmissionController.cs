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
    public class ProjectSubmissionController : Controller
    {
        // GET: SampleTrn4
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            MultilistField multilistField = contextItem.Fields["projectInfo"];
            var multilistItemsFromProjectInfoField = multilistField
                                                     .GetItems()
                                                     .Select(obj => new ProjectSub
                                                     {
                                                         ProjectTitle = new HtmlString(FieldRenderer.Render(obj, "projectTitle")),
                                                         ProjectDescription = new HtmlString(FieldRenderer.Render(obj, "projectDescription")),
                                                         ProjectDuration = new HtmlString(FieldRenderer.Render(obj, "projectDuration")),
                                                         ProjectCost = new HtmlString(FieldRenderer.Render(obj, "projectCost")),
                                                         ProjectSubmissionDate = new HtmlString(FieldRenderer.Render(obj, "projectSubmissionDate")),
                                                     });
            /*  List<ProjectSub> listOfProjectsSubmitted = new List<ProjectSub>();
              foreach (var eachItemInProjectInfoField in multilistItemsFromProjectInfoField)
              {
                  ProjectSub projSubmitted = new ProjectSub();
                  projSubmitted.ProjectTitle = new HtmlString(FieldRenderer.Render(eachItemInProjectInfoField, "projectTitle"));
                  projSubmitted.ProjectDescription = new HtmlString(FieldRenderer.Render(eachItemInProjectInfoField, "projectDescription"));
                  projSubmitted.ProjectDuration = new HtmlString(FieldRenderer.Render(eachItemInProjectInfoField, "projectDuration"));
                  projSubmitted.ProjectCost = new HtmlString(FieldRenderer.Render(eachItemInProjectInfoField, "projectCost"));
                  projSubmitted.ProjectSubmissionDate = new HtmlString(FieldRenderer.Render(eachItemInProjectInfoField, "projectSubmissionDate"));
                  listOfProjectsSubmitted.Add(projSubmitted);
              }*/
            return View(multilistItemsFromProjectInfoField);
        }
    }
}