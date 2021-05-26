using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Project.TrnSite.Models;

namespace Trn.Project.TrnSite.Controllers
{
    public class ListingController : Controller
    {
        // GET: Listing
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            var studentsList = contextItem
            .GetChildren()
            .Select(std => new Card
            {
                cardTitle = std.Fields["name"].Value,
                cardImage = new HtmlString(FieldRenderer.Render(std, "Avtar")),
                url = LinkManager.GetItemUrl(std)
            }).ToList();

            Listing listing = new Listing
            {
                cardList = studentsList
            };
            return View(listing);
        }
    }
}