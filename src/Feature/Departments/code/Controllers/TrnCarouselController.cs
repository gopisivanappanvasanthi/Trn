using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;
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

            List<GalleryInfo> galleryInfos = multilistField
                                               .GetItems()
                                               .Select(std => new GalleryInfo
                                               {
                                                   ImageSrc = GetImageSrc(std),
                                                   ImageAlt = GetImageAlt(std),
                                                   ImageIsActive = "",
                                                   ImageGalleryMainTitle = new HtmlString(FieldRenderer.Render(std, "ImageGalleryMainTitle")),
                                                   ImageGallerySubTitle = new HtmlString(FieldRenderer.Render(std, "ImageGallerySubTitle"))

                                               }).ToList();

            GalleryInfo firstImage = galleryInfos.First();
            firstImage.ImageIsActive = "active";


            return View(galleryInfos);
        }

        private string GetImageSrc(Sitecore.Data.Items.Item item)
        {
            ImageField imageField = item.Fields["ImageGallery"];
            var src = MediaManager.GetMediaUrl(imageField.MediaItem);

            return src;
        }

        private string GetImageAlt(Sitecore.Data.Items.Item item)
        {
            ImageField imageField = item.Fields["ImageGallery"];
            var src = MediaManager.GetMediaUrl(imageField.MediaItem);

            return imageField.Alt;
        }
    }
}