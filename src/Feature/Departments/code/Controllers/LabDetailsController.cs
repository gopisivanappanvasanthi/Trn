using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.SecurityModel;
using Trn.Feature.Departments.Models;
using Trn.Foundation.Publishing.Services;

namespace Trn.Feature.Departments.Controllers

{
    public class LabDetailsController : Controller
    {
        //private Sitecore.Data.Items.Item item;

        [HttpGet]
        public ActionResult Index()
        {
            LabDetailsInfo LabDetailsInfo = new LabDetailsInfo
            {
                Department = "",
                LabSubject = "",
                EquipmentName = "",
                EquipmentIdentity = "",
                EquipmentExpiryDate = "",
                EquipmentUsageManual = "",
            };
            return View(LabDetailsInfo);
        }
        [HttpPost]
        public ActionResult Index(LabDetailsInfo inputComment)
        {
           // { EF8BF5C9 - E99E - 4B7B - 9F3B - DD757B11FF27}
            ID parentItemID = new ID("{EF8BF5C9-E99E-4B7B-9F3B-DD757B11FF27}");
            var masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master");

            var web = Sitecore.Configuration.Factory.GetDatabase("web");
            //var parentItemFromWeb = webDatabase.GetItem(parentItem.ID);

            var parentItemFromMaster = masterDatabase.GetItem(parentItemID);
            ID id = new ID("{EE14F1C5-2C82-4AAD-BA39-6CDB08CE1446}");
            TemplateID templateID = new TemplateID(id);
            using (new SecurityDisabler())
            {
                var createdItem = parentItemFromMaster.Add(inputComment.Department, templateID);
                createdItem.Editing.BeginEdit();
                createdItem.Fields["Department"].Value = inputComment.Department;
                createdItem.Fields["LabSubject"].Value = inputComment.LabSubject;
                createdItem.Fields["EquipmentName"].Value = inputComment.EquipmentName;
                createdItem.Fields["EquipmentIdentity"].Value = inputComment.EquipmentIdentity;
                createdItem.Fields["EquipmentExpiryDate"].Value = inputComment.EquipmentExpiryDate;
                createdItem.Fields["EquipmentUsageManual"].Value = inputComment.EquipmentUsageManual;
                createdItem.Editing.EndEdit();
                createdItem.Editing.AcceptChanges();

                TrnPublishing trnPublishing = new TrnPublishing();
                trnPublishing.DoTrnPublish(createdItem, masterDatabase, web);

            }
            Database master = Sitecore.Configuration.Factory.GetDatabase("master");


            return View("/Views/LabDetails/LabdetailsView.cshtml");

        }
    }
}