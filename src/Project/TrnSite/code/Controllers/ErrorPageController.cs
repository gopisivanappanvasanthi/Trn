using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Project.TrnSite.Models;

namespace Trn.Project.TrnSite.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            ErrorPageInfo errorPage = new ErrorPageInfo();
            errorPage.Title = new HtmlString(FieldRenderer.Render(contextItem,"Title"));
            errorPage.Description = new HtmlString(FieldRenderer.Render(contextItem, "Description"));
            errorPage.Image = new HtmlString(FieldRenderer.Render(contextItem, "Image"));
            return View(errorPage);
        }
    }
}