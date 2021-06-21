using Sitecore.Data;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Departments.Models;
using Trn.Foundation.Publishing.Services;

namespace Trn.Feature.Departments.Controllers
{
    public class TrnSymposiumEnquiryController : Controller
    {
        [HttpGet]
        // GET: TrnSymposiumEnquiry
        public ActionResult Index()
        {
            SymposiumEnquiry symposiumEnquiry = new SymposiumEnquiry
            {
                TeamName= "",
                PhoneNumber="",
                SymposiumName="",
                Idea="",
                Presenters="",
            };
            return View(symposiumEnquiry);
        }
        [HttpPost]
        public ActionResult Index(SymposiumEnquiry inputComment)
        {
            ID parentItemID = new ID("{0AD08451-B02A-4D65-B1BE-0A130A2742F5}");
            var masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master");

            var web = Sitecore.Configuration.Factory.GetDatabase("web");
            //var parentItemFromWeb = webDatabase.GetItem(parentItem.ID);

            var parentItemFromMaster = masterDatabase.GetItem(parentItemID);
            ID templateid = new ID("{8279CC55-604F-45B4-911D-081E6B0090D3}");
            TemplateID templateID = new TemplateID(templateid);
            using (new SecurityDisabler())
            {
                var createdItem = parentItemFromMaster.Add(inputComment.TeamName, templateID);
                createdItem.Editing.BeginEdit();
                createdItem.Fields["TeamName"].Value = inputComment.TeamName;
                createdItem.Fields["PhoneNumber"].Value = inputComment.PhoneNumber;
                createdItem.Fields["SymposiumName"].Value = inputComment.SymposiumName;
                createdItem.Fields["IdeatobePresented"].Value = inputComment.Idea;
                createdItem.Fields["NumberofPresenters"].Value = inputComment.Presenters;
                createdItem.Editing.EndEdit();
                createdItem.Editing.AcceptChanges();

                TrnPublishing trnPublishing = new TrnPublishing();
                trnPublishing.DoTrnPublish(createdItem, masterDatabase, web);
            }

            return View("/Views/TrnSymposiumEnquiry/EnquirySummary.cshtml");
        }
    }
}