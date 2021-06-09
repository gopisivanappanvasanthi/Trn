using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.FakeDb;
using NUnit.Framework;
using System;
using Trn.Feature.Students.Models;
using Trn.Feature.Students.Services;

namespace Trn.Feature.StudentsTest
{
    [TestClass]
    public class SubjectInformationControllerTest
    {
        [TestMethod]
        public void Test_SubjectsInfo_Data()
        {
            var fakeSite = new Sitecore.FakeDb.Sites.FakeSiteContext(
                                new Sitecore.Collections.StringDictionary
                                {
                                    { "name", "website" }, {"language", "en"}
                                });
            using (new Sitecore.Sites.SiteContextSwitcher(fakeSite))
            {
                using (Db db = new Db
                                {
                                    new DbItem("Home")
                                                {
                                                    { "mainsub", "TestSubject1" },
                                                    { "alliedsub", "TestSubject2" }
                                                }
                                })
                {
                    Item item = db.GetItem("/sitecore/content/Home");
                    SubjectDataServices subjectDataServices = new SubjectDataServices();
                    var sub = subjectDataServices.GetSubjectInfo(item);

                    NUnit.Framework.Assert.IsInstanceOf<SubjectsInfo>(sub);
                }
            }

        }
    }
}
