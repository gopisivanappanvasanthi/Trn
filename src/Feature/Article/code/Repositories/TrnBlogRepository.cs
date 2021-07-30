using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trn.Feature.Article.Models;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Links;

namespace Trn.Feature.Article.Repositories
{
    public class TrnBlogRepository : ITrnBlogRepository
    {
        public BlogListInfo GetBlogsList()
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
            return listing;
        }
    }
}