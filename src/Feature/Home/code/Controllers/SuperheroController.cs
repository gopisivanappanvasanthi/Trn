using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Home.Models;

namespace Trn.Feature.Home.Controllers
{
    public class SuperheroController : Controller
    {
        // GET: Superhero
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            Superhero superhero = new Superhero();
            superhero.SuperheroTitle = new HtmlString(FieldRenderer.Render(contextItem, "SuperheroTitle"));
            return View(superhero);
           
        }
    }
}