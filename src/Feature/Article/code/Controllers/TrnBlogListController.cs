using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Article.Models;

namespace Trn.Feature.Article.Controllers
{
    public class TrnBlogListController : Controller
    {
        // GET: TrnBlogList
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            var blogsinput = contextItem
            .GetChildren()
            .Select(std => new BlogCard
            {
                blogTitle = std.Fields["Title"].Value,
                blogImage = new HtmlString(FieldRenderer.Render(std, "Image")),
                blogurl = LinkManager.GetItemUrl(std)
            }).ToList();

            BlogListInfo listing = new BlogListInfo
            {
                blogsList = blogsinput
            };
            return View(listing);
        }
    }
}