using Sitecore.Data;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Home.Models;




namespace Trn.Feature.Home.Controllers
{
    public class QandAController : Controller
    {
        // GET: QandA
        [HttpGet]
        public ActionResult Index()
        {
            QandA query = new QandA
            {
                Question = "",
            };
           
            return View(query);
        }

        [HttpPost]
        public ActionResult Index(QandA inputQuery)
        {
            var parentItem = Sitecore.Context.Item;
            var masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master");
            var web = Sitecore.Configuration.Factory.GetDatabase("web");

            var parentItemFromMaster = masterDatabase.GetItem(parentItem.ID);
            ID id = new ID("{8CFC3B0F-B415-4152-B097-F4F6F64D0080}");
            TemplateID templateID = new TemplateID(id);
            using (new SecurityDisabler())
            {
                var createdItem = parentItemFromMaster.Add(inputQuery.Question, templateID);
                createdItem.Editing.BeginEdit();
                createdItem.Fields["question"].Value = inputQuery.Question;
                createdItem.Fields["answers"].Value = inputQuery.Answers;
                
                createdItem.Editing.EndEdit();
                createdItem.Editing.AcceptChanges();

                //TrnPublishing trnPublishing = new TrnPublishing();
                //trnPublishing.DoTrnPublish(createdItem, masterDatabase, web);

            }

            return View("/Views/QandA/QandA_SummaryOne.cshtml");

        }
    }
}