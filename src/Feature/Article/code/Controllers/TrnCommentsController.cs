using Sitecore.Data;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Article.Models;
using Trn.Foundation.Publishing.Services;

namespace Trn.Feature.Article.Controllers
{
    public class TrnCommentsController : Controller
    {
        //private Sitecore.Data.Items.Item item;

        [HttpGet]
        public ActionResult Index()
        {
            Comment comment = new Comment
            {
                UserName = "",
                UserEmailId = "",
                UserComments = "",
            };
            return View(comment);
        }
        [HttpPost]
        public ActionResult Index(Comment inputComment)
        {
            var parentItem = Sitecore.Context.Item;
            var masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master");

            var web = Sitecore.Configuration.Factory.GetDatabase("web");
            //var parentItemFromWeb = webDatabase.GetItem(parentItem.ID);

            var parentItemFromMaster = masterDatabase.GetItem(parentItem.ID);
            ID id = new ID("{3810FF1A-3C2F-4698-9284-24BB23E11D46}");
            TemplateID templateID = new TemplateID(id);
            using (new SecurityDisabler())
            {
                var createdItem = parentItemFromMaster.Add(inputComment.UserName, templateID);
                createdItem.Editing.BeginEdit();
                createdItem.Fields["username"].Value = inputComment.UserName;
                createdItem.Fields["useremailid"].Value = inputComment.UserEmailId;
                createdItem.Fields["usercomments"].Value = inputComment.UserComments;
                createdItem.Editing.EndEdit();
                createdItem.Editing.AcceptChanges();

                TrnPublishing trnPublishing = new TrnPublishing();
                trnPublishing.DoTrnPublish(createdItem,masterDatabase,web);

            }
            //Database master = Sitecore.Configuration.Factory.GetDatabase("master");


            return View("/Views/TrnComments/CommentsSummary.cshtml");
        }
    }
}