using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Foundation.Publishing.Services
{
    public class TrnPublishing
    {
        
        public void DoTrnPublish(Sitecore.Data.Items.Item item,Sitecore.Data.Database masterDatabase,Sitecore.Data.Database web) {
            Sitecore.Publishing.PublishOptions publishOptions = new Sitecore.Publishing.PublishOptions(masterDatabase,
                                           web,
                                           Sitecore.Publishing.PublishMode.SingleItem,
                                           item.Language,
                                           System.DateTime.Now);

            Sitecore.Publishing.Publisher publisher = new Sitecore.Publishing.Publisher(publishOptions);

            publisher.Options.RootItem = item;

            publisher.Options.Deep = true;

            publisher.Publish();


        }
       
    }
}