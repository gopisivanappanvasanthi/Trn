using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trn.Project.TrnSite.Models;

namespace Trn.Project.TrnSite.Services
{
    public class ListingServices
    {
        public Listing GetChildListing(Sitecore.Data.Items.Item parentItem)
        {
            var studentsList = parentItem
            .GetChildren()
            .Select(std => new Card
            {
                cardTitle = std.Fields["name"].Value,
                cardImage = new HtmlString(std.Fields["Avtar"].Value),
                url = LinkManager.GetItemUrl(std)
            }).ToList();

            Listing listing = new Listing
            {
                cardList = studentsList
            };

            return listing;
        }
    }
}