using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Project.TrnSite.Models;

namespace Trn.Project.TrnSite.Controllers
{
    public class BreadcrumbNavController : Controller
    {
        // GET: Breadcrumb
        public ActionResult Index()
        {
        
            var siteStartItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            List<NavigationItem> navItems = new List<NavigationItem>();
            var currentItem = Sitecore.Context.Item;
            ItemUrlBuilderOptions itemUrlBuilderOptions = new ItemUrlBuilderOptions
            {
                LowercaseUrls = true
            };
            var ancestorList = currentItem
                                    .Axes.GetAncestors()
                                    .Where(i => i.Axes.IsDescendantOf(siteStartItem))
                                    .Concat(new List<Sitecore.Data.Items.Item> { currentItem })
                                    .Select(sitecoreitem => new NavigationItem
                                    {
                                      navTitle = sitecoreitem.DisplayName,
                                      navUrl = LinkManager.GetItemUrl(sitecoreitem,itemUrlBuilderOptions)
            });
            return View(ancestorList);
        }
    }
}