using Trn.Feature.Events.Models;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trn.Feature.Events.Controllers
{
    public class TrnEventsController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            EventsInfo eventsInfo = new EventsInfo();


            eventsInfo.EventDate = new HtmlString(FieldRenderer.Render(contextItem, "EventDate"));
            eventsInfo.EventDuration = new HtmlString(FieldRenderer.Render(contextItem, "EventDuration"));
            eventsInfo.EventPOC = new HtmlString(FieldRenderer.Render(contextItem, "EventPOC"));
            eventsInfo.EventAgenda = new HtmlString(FieldRenderer.Render(contextItem, "EventAgenda"));

            return View(eventsInfo);
        }
    }
}