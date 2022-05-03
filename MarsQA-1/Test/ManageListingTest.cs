using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using TechTalk.SpecFlow;

namespace MarsFramework
{
    public class ManageListingTest

    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Driver 
        {

            ManageListings ManageListingobj = new ManageListings();
            HomePage HomePageobj = new HomePage();
            SkillShare SkillShareobj= new SkillShare(); 



            [SetUp]
            public void Setup1()
            {

                CommonMethods.ExtentReports();

                CommonMethods.test = CommonMethods.Extent.StartTest( "Test" );


                //launch the browser

                Initialize();
                ExcelLibHelper.PopulateInCollection(@"C:\Users\Nancy\Desktop\Competition - part2\Competition1\MarsQA-1\Excel Data\Data\Mars.xlsx", "Credentials");



                //call the SignIn class
                SignIn.SigninStep();


            }



            [Test]
            public void TC_002_01_view_listings()
            {
                HomePageobj.ClickOnManageListings();

                 //save the text of listing title which is to be viewed

               IWebElement ViewListingTitle = driver.FindElement(By.XPath("//table/tbody/tr/td[3]"));
               String  Title1 = ViewListingTitle.Text;
                

                // click on view listing icon

                ManageListingobj.ViewListingIcon();
               
                // check if the correct listing is being viewed by user

                IWebElement body = driver.FindElement(By.TagName("body"));
                // Assert.IsTrue(body.Text.Contains(Title1));


                //check if we are on view listing details page
                IWebElement ChatIcon = driver.FindElement(By.XPath("//*[text()= 'Chat']"));
                Assert.That(ChatIcon.Text == "Chat", "Test failed");



            }


            [Test]
            public void TC_004_02_edit_listings()
            {
                HomePageobj.ClickOnManageListings();


                //click on update listing icon
                ManageListingobj.UpdateIcon();


                // update the listing details
                SkillShareobj.UpdateListing();

                HomePageobj.ClickOnManageListings();


                // check listing has been updated successfully
                IWebElement CheckTitle = driver.FindElement(By.CssSelector("#listing-management-section > div:nth-child(3) > div:nth-child(2) > div:nth-child(1) > table > tbody > tr:nth-child(1) > td:nth-child(3)"));

                Assert.That(CheckTitle.Text == "Updated Title of the Listing", "Listing was not added");



            }


            [Test]
            public void TC_005_01_delete_listings()
            {
                
                HomePageobj.ClickOnManageListings();


                // click on delete listing icon 
                ManageListingobj.DeleteListingIcon();
                // click on manage listing tab

                HomePageobj.ClickOnManageListings();
                // check title of listing to be deleted

                string Title = ManageListingobj.getlistingBeforeDelete();

                // check if listing has been deleted

                String bodyText = driver.FindElement(By.TagName("body")).Text;
                Assert.IsFalse(bodyText.Contains(Title), "Listing was not Deleted");




            }


            [TearDown]
            public void Teardowm1()
            {

                // Screenshot
                string img = CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
               CommonMethods.test.Log(LogStatus.Info, "Snapshot below: " + CommonMethods.test.AddScreenCapture(img));
                //Close the browser
                Close();

                // end test. (Reports)
                CommonMethods.Extent.EndTest( CommonMethods.test);

                // calling Flush writes everything to the log file (Reports)
                CommonMethods.Extent.Flush();



            }



        }
    }
}