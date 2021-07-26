using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.ContentSearch.Models;

namespace Trn.Feature.ContentSearch.Controllers
{
    public class ArticleResultController : Controller
    {
        // GET: ArticleResult
        public ActionResult Index()
        {
            var searchterm = Request.QueryString["searchterm"];

            ISearchIndex index = ContentSearchManager.GetIndex("sitecore_master_index");
            List<SearchResultItem> searchResultItems;
            using (IProviderSearchContext context = index.CreateSearchContext())
            {
                searchResultItems = context.GetQueryable<SearchResultItem>()
                                     .Where(x => x.Content.Contains(searchterm))
                                     .Where(x => x.TemplateId == new Sitecore.Data.ID("{12C87B25-3E60-49F6-A1A6-86E4AC4591C1}"))
                                     .ToList();
            }

            List<ArticleResultInfo> searchResults = searchResultItems.Select(x => new ArticleResultInfo
            {
                ResultTitle = x.Fields["title_t"].ToString(),
                ResultDescription = x.Fields["description_t"].ToString(),
                ResultRefUrl = x.Url,
                // ResultImageCard = (HtmlString)x.Fields["Ima"],
                // ResultImageCard = new HtmlString(FieldRenderer.Render(x, "Image")),
                //ResultImageCard = new HtmlString(x.Fields["image_t_en"].ToString())
            }).ToList();

            return View(searchResults);
        }
    }
}