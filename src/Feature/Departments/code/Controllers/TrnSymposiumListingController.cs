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
    public class TrnSymposiumListingController : Controller
    {
        // GET: TrnSymposiumListing
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            MultilistField symposiums = contextItem.Fields["Symposiums"];
            List<SymposiumCard> symposiumCards = symposiums
                                                   .GetItems()
                                                   .Select(std => new SymposiumCard
                                                   {
                                                       PageTitle = FieldRenderer.Render(std, "PageTitle"),
                                                       ImageGallery = new HtmlString(getImageFromItem(std)),
                                                      
                                                       url = LinkManager.GetItemUrl(std),
                                                   }).ToList();

            SymposiumListingInfo symposiumListingInfo = new SymposiumListingInfo
            {
                SymposiumCards = symposiumCards
            };

            return View(symposiumListingInfo);

        }

        public string getImageFromItem(Sitecore.Data.Items.Item item)
        {

            var firstChildImage = item.GetChildren().First();
            return FieldRenderer.Render(firstChildImage, "ImageGallery");
        }


        //var studentsList = contextItem
        //.GetChildren()
        //.Select(std => new SymposiumCard
        //{
          //ImageGalleryMainTitle = FieldRenderer.Render(std, "ImageGalleryMainTitle"),
            //    ImageGalleryMainTitle = std.Fields["ImageGalleryMainTitle"].Value,
            //    ImageGallery = new HtmlString(FieldRenderer.Render(std, "ImageGallery")),
            //    ImageGallerySubTitle = std.Fields["ImageGallerySubTitle"].Value
            //}).ToList();

            //SymposiumListingInfo listing = new SymposiumListingInfo
            //{
            //    cardList = studentsList
            //};
            //return View(listing);
            
        
    }
}