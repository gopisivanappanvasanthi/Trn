using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.FakeDb;
using Sitecore.Resources.Media;
using System;
using Trn.Project.TrnSite.Services;

namespace Trn.Project.TrnSite.Test
{
    [TestClass]
    public class ListingServiceTest
    {
        ID mediaItemId = ID.NewID;
        ID testItemId = ID.NewID;
        ID mediaFieldId = ID.NewID;
        [TestMethod]
        public void Test_ListingService_Data()
        {
            const string MyImageUrl = "~/media/myimage.ashx";

            var fakeSite = new Sitecore.FakeDb.Sites.FakeSiteContext(
                new Sitecore.Collections.StringDictionary
                {
                    { "name", "website" }, {"language", "en"}
                });
            using (new Sitecore.Sites.SiteContextSwitcher(fakeSite))
            {
                using (Db db = new Db
                {
                  new DbItem("Home") { { "Page Title", "Welcome!" } },
                  new DbItem("MediaSource", mediaItemId)
                })
                {
                    Item home = db.GetItem("/sitecore/content/home");
                    SetItemForDatasource(db);

                    MediaProvider mediaProvider = Substitute.For<MediaProvider>();

                    mediaProvider.GetMediaUrl(Arg.Is<MediaItem>(i => i.ID == mediaItemId))
                                 .Returns(MyImageUrl);

                    using (new Sitecore.FakeDb.Resources.Media.FakeMediaProvider())
                    {
                        ListingServices listingServices = new ListingServices();
                        listingServices.GetChildListing(home);
                    }
                }
            }
        }

        public void SetItemForDatasource(Sitecore.FakeDb.Db db)
        {
            db.Add(new DbItem("Student-1", testItemId)
            {
                { "name", "Student-1" },
                { mediaFieldId,$"<link linktype=\"media\" mediaid=\"{mediaItemId}\" height=\"50\" width=\"50\" />"},
            });
            db.Add(new DbItem("Student-2", testItemId)
            {
                { "name", "Student-2 " },
                { mediaFieldId,$"<link linktype=\"media\" mediaid=\"{mediaItemId}\" height=\"50\" width=\"50\" />"},
            });


        }
    }
}
