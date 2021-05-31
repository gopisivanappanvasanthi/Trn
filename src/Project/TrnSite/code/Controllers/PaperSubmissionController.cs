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
    public class PaperSubmissionController : Controller
    {
        // GET: SampleTrn32
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            MultilistField multilistField = contextItem.Fields["paperInfo"];
            var multilistItemsFromPaperInfoField = multilistField
                                                   .GetItems()
                                                   .Select(obj => new PapersSub
                                                   {
                                                      PaperTitle = new HtmlString(FieldRenderer.Render(obj,"paperTitle")),
                                                       PaperDescription = new HtmlString(FieldRenderer.Render(obj, "paperDescription")),
                                                       PaperImage = new HtmlString(FieldRenderer.Render(obj, "paperImage")),
                                                   });
                                                    
            /*List<PapersSub> listOfPapersSubmitted = new List<PapersSub>();
            foreach (var eachItemInPaperInfoField in multilistItemsFromPaperInfoField)
            {
                PapersSub paperSubmitted = new PapersSub();
                paperSubmitted.PaperTitle = new HtmlString(FieldRenderer.Render(eachItemInPaperInfoField, "paperTitle"));
                paperSubmitted.PaperDescription = new HtmlString(FieldRenderer.Render(eachItemInPaperInfoField, "paperDescription"));
                paperSubmitted.PaperImage = new HtmlString(FieldRenderer.Render(eachItemInPaperInfoField, "paperImage"));
                
                listOfPapersSubmitted.Add(paperSubmitted);
            }*/
            return View(multilistItemsFromPaperInfoField);
        }

    }
}