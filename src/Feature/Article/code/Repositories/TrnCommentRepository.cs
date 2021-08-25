using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trn.Feature.Article.Models;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Links;
using Sitecore.Data;
using Trn.Foundation.Publishing.Services;
using Sitecore.SecurityModel;

namespace Trn.Feature.Article.Repositories
{
    public class TrnCommentRepository : ITrnCommentRepository
    {
        public Comment InitializeCoomment()
        {
            Comment comment = new Comment
            {
                UserName = "",
                UserEmailId = "",
                UserComments = "",
            };
            return comment;
        }
        public void AddComment(Comment inputComment)
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
                trnPublishing.DoTrnPublish(createdItem, masterDatabase, web);
            }
        }
        public ListOfComments GetComments()
        {
            var contextItem = Sitecore.Context.Item;
            var ListOfComments = contextItem.GetChildren()
                                      .Select(Comment => new Comment
                                      {
                                          UserComments = Comment.Fields["UserComments"].Value,
                                          UserName = Comment.Fields["UserName"].Value,

                                      }).ToList();

            ListOfComments comment = new ListOfComments
            {
                comments = ListOfComments
            };
            return comment;
        }
    }
}