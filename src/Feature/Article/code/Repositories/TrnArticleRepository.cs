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
    public class TrnArticleRepository : ITrnArticleRepository
    {
        public ArticleInfo GetArticleInfo(bool IsFeaturedArticle = false)
        {
            ArticleInfo article = new ArticleInfo();
            if (IsFeaturedArticle)
            {
                var contextItem = RenderingContext.Current.Rendering.Item;
                article = new ArticleInfo
                {
                    Title = new HtmlString(FieldRenderer.Render(contextItem, "Title")),
                    Image = new HtmlString(FieldRenderer.Render(contextItem, "Image")),
                    Url = LinkManager.GetItemUrl(contextItem)
                };
            }
            else
            {
                Item contextItem = Sitecore.Context.Item;
                article = new ArticleInfo
                {
                    Title = new HtmlString(FieldRenderer.Render(contextItem, "Title")),
                    Description = new HtmlString(FieldRenderer.Render(contextItem, "Description")),
                    Image = new HtmlString(FieldRenderer.Render(contextItem, "Image"))
                };
            }
            return article;
        }
    }
}