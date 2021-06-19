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

    public class TrnAdmissionFormController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Admission admission = new Admission
            {
                FirstName = "",
                LastName = "",
                DateofBirth = "",
                Course = "",
                PhoneNumber = "",
                EmailId = "",
                Address = "",
            };
            return View(admission);
        }
        [HttpPost]
        public ActionResult Index(Admission inputComment)
        {
            ID parentItemID = new ID("{536FCE6E-3FA7-4AB4-9AA8-9DDD249894A6}");
            var masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master");

            var web = Sitecore.Configuration.Factory.GetDatabase("web");
            //var parentItemFromWeb = webDatabase.GetItem(parentItem.ID);

            var parentItemFromMaster = masterDatabase.GetItem(parentItemID);
            ID idparentitem = new ID("{9F176A86-AFC9-488C-96A4-D801831D4040}");
            var parentItemForAdmission = masterDatabase.GetItem(idparentitem);
            TemplateID templateID = new TemplateID(idparentitem);
            using (new SecurityDisabler())
            {
                var createdItem = parentItemFromMaster.Add(inputComment.FirstName, templateID);
                createdItem.Editing.BeginEdit();
                createdItem.Fields["FirstName"].Value = inputComment.FirstName;
                createdItem.Fields["LastName"].Value = inputComment.LastName;
                createdItem.Fields["DateofBirth"].Value = inputComment.DateofBirth;
                createdItem.Fields["Course"].Value = inputComment.Course;
                createdItem.Fields["PhoneNumber"].Value = inputComment.PhoneNumber;
                createdItem.Fields["EmailId"].Value = inputComment.EmailId;
                createdItem.Fields["Address"].Value = inputComment.Address;
                createdItem.Editing.EndEdit();
                createdItem.Editing.AcceptChanges();

               TrnPublishing trnPublishing = new TrnPublishing();
               trnPublishing.DoTrnPublish(createdItem, masterDatabase, web);

            }
            //Database master = Sitecore.Configuration.Factory.GetDatabase("master");


            return View("/Views/TrnAdmissionForm/AdmissionSummary.cshtml");
        } 
}
}