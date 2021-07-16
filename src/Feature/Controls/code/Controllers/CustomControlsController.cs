using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Feature.Controls.Models;

namespace Trn.Feature.Controls.Controllers
{
    public class CustomControlsController : Controller
    {
        // GET: CustomControls
        public ActionResult Index()
        {
            //var keyValuePairs = new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("Key1", "Value1"),
            //    new KeyValuePair<string, string>("Key2", "Value2"),
            //    new KeyValuePair<string, string>("Key3", "Value3"),
            //    new KeyValuePair<string, string>("Key4", "Value4"),
            //    new KeyValuePair<string, string>("Key5", "Value5"),
            //};
            
            return View();
        }
    }
}