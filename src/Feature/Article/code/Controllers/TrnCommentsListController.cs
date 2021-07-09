using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data;
using Trn.Feature.Article.Models;

namespace Trn.Feature.Article.Controllers
{
    public class TrnCommentsListController : Controller
    {
        // GET: TrnArticleList
        public ActionResult Index()
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

            return View(comment);
        }
       
    }
}