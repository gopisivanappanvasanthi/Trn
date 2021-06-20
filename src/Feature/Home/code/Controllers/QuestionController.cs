using Sitecore.Data;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Home.Models;
using Trn.Foundation.Publishing.Services;

namespace Trn.Feature.Home.Controllers
{
    public class QuestionController : Controller
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
            var contextItem = Sitecore.Context.Item;
            Random randomNumber = new Random();
            var displayNameItem = contextItem.Name + randomNumber.Next(1, 10).ToString();

            ID parentItemID = new ID("{8CFC3B0F-B415-4152-B097-F4F6F64D0080}");
            var masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master");
            var webDatabase = Sitecore.Configuration.Factory.GetDatabase("web");

            var parentItemFromMaster = masterDatabase.GetItem(parentItemID);
            ID idParentItem = new ID("{BDDBCE0D-A7F0-4913-873C-A117CEAE7659}");
            var parentItemForQandA = masterDatabase.GetItem(idParentItem);

            TemplateID templateID = new TemplateID(idParentItem);
            using (new SecurityDisabler())
            {
                var createdItem = parentItemFromMaster.Add(displayNameItem, templateID);
                createdItem.Editing.BeginEdit();
                createdItem.Fields["question"].Value = inputQuery.Question;
                
                
                createdItem.Editing.EndEdit();
                createdItem.Editing.AcceptChanges();

                TrnPublishing trnPublishing = new TrnPublishing();
                trnPublishing.DoTrnPublish(createdItem, masterDatabase, webDatabase);

            }

            return View("/Views/Question/QandA_SummaryOne.cshtml");

        }
    }
}