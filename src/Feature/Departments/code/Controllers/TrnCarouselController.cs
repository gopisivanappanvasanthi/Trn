using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Departments.Models;

namespace Trn.Feature.Departments.Controllers
{
    public class TrnCarouselController : Controller
    {
        // GET: Listing
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            MultilistField multilistField = contextItem.Fields["CarouselItems"];
            var multilistItemsFromCarousel = multilistField
                                               .GetItems()
                                               .Select(std => new GalleryInfo
                                               {
                                                   ImageGallery = new HtmlString(FieldRenderer.Render(std, "ImageGallery")),
                                                   ImageGalleryMainTitle = new HtmlString(FieldRenderer.Render(std, "ImageGalleryMainTitle")),
                                                   ImageGallerySubTitle = new HtmlString(FieldRenderer.Render(std, "ImageGallerySubTitle"))

                                               });
                         
            return View(multilistItemsFromCarousel);
        }
    }
}