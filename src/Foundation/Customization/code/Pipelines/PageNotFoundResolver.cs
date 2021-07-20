using Sitecore.Data.Items;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Trn.Foundation.Customization.Pipelines
{
    public class PageNotFoundResolver : Sitecore.Pipelines.HttpRequest.HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            string filePath = HttpContext.Current.Server.MapPath(args.Url.FilePath);
            if (IsValidItem()
                || args.LocalPath.Contains("/sitecore")
                || File.Exists(filePath))
                return;

            Sitecore.Context.Item = Get404Page();

            if (Sitecore.Context.Item != null)
                Sitecore.Context.Item["is404page"] = "true";

        }

        private bool IsValidItem()
        {
            if ((Sitecore.Context.Item is null) || (Sitecore.Context.Item.Versions.Count == 0))
                return false;
            if (Sitecore.Context.Item.Visualization.Layout == null)
                return false;
            return true;
        }

        private Item Get404Page()
        {
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            Item pageNotFoundItem = homeItem?.Axes.GetDescendants()
                .Where(x => x.TemplateID == new Sitecore.Data.ID("{92B6789A-FACA-4DE0-BE6A-7128A13A7BB5}"))
                ?.FirstOrDefault();

            return pageNotFoundItem;
        }
    }
}