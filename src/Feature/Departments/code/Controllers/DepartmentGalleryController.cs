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
    public class DepartmentGalleryController : Controller
    {
        // GET: DepartmentGallery
        public ActionResult Index()
        {
            var contextitem = Sitecore.Context.Item;

            MultilistField symposiums = contextitem.Fields["symposiums"];

            List<SymposiumCard> symposiumCards = symposiums
                                                    .GetItems()
                                                    .Select(x => new SymposiumCard
                                                    {
                                                        cardTitle = x.Name,
                                                        cardImage = new HtmlString(getImageFromItem(x)),
                                                        url = LinkManager.GetItemUrl(x),
                                                    }).ToList();

            return View(symposiumCards);
        }

        public string getImageFromItem(Sitecore.Data.Items.Item item)
        {
            var childImage = item.GetChildren().First();
            return FieldRenderer.Render(childImage, "ImageGallery");
        }
    }
}