using NUnit.Framework;
using System;

namespace Trn.Feature.Unit.Test
{
    [TestFixture]
    public class Article
    {
        [Test]
        public void TestSample()
        {
            string x = "true";
            string y = string.Empty;
            string z = "Admin";
            Assert.AreEqual("Admin", z);
        }
    }
}
