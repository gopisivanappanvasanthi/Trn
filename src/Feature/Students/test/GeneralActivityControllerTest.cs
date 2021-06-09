using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Web.UI.WebControls;
using System;
using Trn.Feature.Students.Models;
using Trn.Feature.Students.Services;
using Assert = NUnit.Framework.Assert;

namespace Trn.Feature.StudentsTest
{
    [TestClass]
    public class GeneralActivityControllerTest
    {
        [TestMethod]
        public void Test_GeneralActivity_Data()
        {
            //Create a fake item which resembles Sitecore Item
            //Arrange

            var contextItemID = ID.NewID;
            var database = Substitute.For<Database>();
            var definition = new ItemDefinition(contextItemID, "GeneralActivity", ID.NewID, ID.NewID);
            var contextItemData = new ItemData(definition, Language.Current, Sitecore.Data.Version.First, new FieldList());
            var contextItem = Substitute.For<Item>(contextItemID, contextItemData, database);

            var activityTitleFieldID = ID.NewID;
            var activityDescriptionFieldID = ID.NewID;

            Field activityTitleField = Substitute.For<Field>(activityTitleFieldID, contextItem);
            activityTitleField.Value = "Title";
            Field activityDescriptionField = Substitute.For<Field>(activityDescriptionFieldID, contextItem);
            activityDescriptionField.Value = "Description";

            FieldCollection fieldCollection = Substitute.For<FieldCollection>(contextItem);

            contextItem.Fields.Returns(fieldCollection);
            contextItem.Fields["activityTitle"].Returns(activityTitleField);
            contextItem.Fields["activityDescription"].Returns(activityDescriptionField);

            //Pass the fake item to the service and get response. 
            //Act
            GeneralActivityServices generalActivityServices = new GeneralActivityServices();
            var gen = generalActivityServices.GetGeneralActivityData(contextItem);

            //Assert the response with the expected output.

            Assert.IsInstanceOf<General>(gen);
            Assert.That(gen.activityTitle.ToString(), Is.EqualTo("Title"));
            Assert.That(gen.activityDescription.ToString(), Is.EqualTo("Description"));
        }
    }
}
