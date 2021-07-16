using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Search.Models;

namespace Trn.Feature.Search.Controllers
{
    public class ResultsController : Controller
    {
        // GET: Results
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

            List<TrnSearchResult> searchResults = searchResultItems.Select(x => new TrnSearchResult
            {
                ResultTitle = x.Fields["title"].ToString(),
                ResultDescription = x.Fields["description"].ToString(),
                ResultRefUrl = x.Url,
                //ResultImageCard = new HtmlString(x.Fields["image_t_en"].ToString())
            }).ToList();

            return View(searchResults);
        }
    }
}