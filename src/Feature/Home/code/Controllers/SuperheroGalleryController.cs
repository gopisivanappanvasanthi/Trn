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
using Trn.Feature.Home.Models;

namespace Trn.Feature.Home.Controllers
{
    public class SuperheroGalleryController : Controller
    {
        // GET: SuperheroGallery
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            MultilistField multilistField = contextItem.Fields["SuperheroCarousel"];
            List<SuperheroGal> superheroGals = multilistField
                                             .GetItems()
                                               .Select(std => new SuperheroGal
                                               {
                                                   ImageSrc = GetImageSrc(std),
                                                   ImageAlt = GetImageAlt(std),
                                                   ImageIsActive = "",


                                               }).ToList();

            SuperheroGal firstImage = superheroGals.First();
            firstImage.ImageIsActive = "active";

            return View(superheroGals);
        }

        private string GetImageSrc(Sitecore.Data.Items.Item item)
        {
            ImageField imageField = item.Fields["SuperheroImage"];
            var src = MediaManager.GetMediaUrl(imageField.MediaItem);

            return src;
        }

        private string GetImageAlt(Sitecore.Data.Items.Item item)
        {
            ImageField imageField = item.Fields["SuperheroImage"];
            var src = MediaManager.GetMediaUrl(imageField.MediaItem);

            return imageField.Alt;
        }
    }
}