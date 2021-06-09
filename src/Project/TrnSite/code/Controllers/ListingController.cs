using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Project.TrnSite.Models;
using Trn.Project.TrnSite.Services;

namespace Trn.Project.TrnSite.Controllers
{
    public class ListingController : Controller
    {
        // GET: Listing
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            ListingServices listingServices = new ListingServices();
            return View(listingServices.GetChildListing(contextItem));
        }
    }
}