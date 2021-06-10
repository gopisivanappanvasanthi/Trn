
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Article.Models;
using Sitecore.Web.UI.WebControls;


namespace Trn.Feature.Article.Controllers
{
    public class TrnArticleController : Controller
    {
        // GET: article
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            ArticleInfo article = new ArticleInfo
            {
                Title = new HtmlString(FieldRenderer.Render(contextItem, "Title")),
                Description = new HtmlString(FieldRenderer.Render(contextItem, "Description")),
                Image = new HtmlString(FieldRenderer.Render(contextItem, "Image"))
            };

            return View(article);
        }
    }
}
