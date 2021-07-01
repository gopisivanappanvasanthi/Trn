using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Article.Models;

namespace Trn.Feature.Article.Controllers
{
    public class FeaturedArticleController : Controller
    {
        // GET: FeaturedArticle
        public ActionResult Index()
        {

            var contextItem = RenderingContext.Current.Rendering.Item;

            ArticleInfo articleInfo1 = new ArticleInfo
            {
                Title = new HtmlString(FieldRenderer.Render(contextItem, "Title")),
                Image = new HtmlString(FieldRenderer.Render(contextItem, "Image")),
                Url = LinkManager.GetItemUrl(contextItem)
            };
            return View(articleInfo1);
        }
    }
}