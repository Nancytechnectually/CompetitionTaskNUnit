using System;
using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsFramework
{
    public class ShareSkillTests
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Driver 
        {
            HomePage Homepageobj = new HomePage();
           SkillShare  SkillShareobj = new SkillShare();

            public String TitleExists = "No";
            




            [SetUp]
            public void Setup1()
            {
                CommonMethods.ExtentReports();

                CommonMethods.test = CommonMethods.Extent.StartTest("Test");



                //launch the browser

                Initialize();
                ExcelLibHelper.PopulateInCollection(@"C:\Users\Nancy\Desktop\Competition - part2\Competition1\MarsQA-1\Excel Data\Data\Mars.xlsx", "Credentials");



                //call the SignIn class
                SignIn.SigninStep();


            }




            [Test]
            public void TC_001_01_Click_ShareSkill()
            {
                Homepageobj.ClickonSkillshare();

                String TitleExists = "No";
                try
                {

                    IWebElement CheckPage =driver.FindElement(By.XPath("//*[text()= 'Title']"));
                    TitleExists = "Yes";


                }
                catch
                {

                    Console.WriteLine("SkillShare Button Did not Worked");


                }

                Assert.That(TitleExists == "Yes", "User Unable to click skillShare Tab");


            }
            [Test]
            public void TC_002_01_Add_Title()
            {
                //Click on Manage Listings

                Homepageobj.ClickOnManageListings();
               
                //Check Listings already added and assign new value to Listing Title
                SkillShareobj.GetExcelValue();

                //Click on Skillshare to Add new listing 

                Homepageobj.ClickonSkillshare();

                // Add new listing Title
                string SelectedTitle = SkillShareobj.getTitleKey();

                IWebElement Title = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div.tooltip-target.vertically.padded.ui.grid > div > div.ui.twelve.wide.column > div > div.field > input[type=text]"));
                Title.SendKeys(SelectedTitle);

                string TestTitle = Title.GetAttribute("value");

                Assert.That(TestTitle == SelectedTitle);


            }

            [Test]
            public void TC_004_01_Select_category()
            {
                //Click on Skillshare to Add new listing 

                Homepageobj.ClickonSkillshare();

                SkillShareobj.dropdown();

                SelectElement Category = new SelectElement(driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(3) > div.twelve.wide.column > div > div:nth-child(1) > select")));
                String Check1= Category.SelectedOption.Text;


                SelectElement SubCategory = new SelectElement(driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(3) > div.twelve.wide.column > div > div:nth-child(2) > div:nth-child(1) > select")));
                String Check2 = SubCategory.SelectedOption.Text;


                Assert.That(Check1 == "Programming & Tech", "Category Value was not selected");
                Assert.That(Check2 == "QA", "Sub-Category Value was not selected");



            }
            [Test]
            public void Add_DemoListing()
            {
                //Click on Manage Listings

                Homepageobj.ClickOnManageListings();

                //Check Listings already added and assign new value to Listing Title
                SkillShareobj.GetExcelValue();

                //Click on Skillshare to Add new listing 

                Homepageobj.ClickonSkillshare();

                // Add new listing Title
                string SelectedTitle = SkillShareobj.getTitleKey();

                IWebElement Title = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div.tooltip-target.vertically.padded.ui.grid > div > div.ui.twelve.wide.column > div > div.field > input[type=text]"));
                Title.SendKeys(SelectedTitle);

                // add rest of the listing details and save

                SkillShareobj.AddListing();


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
                CommonMethods.Extent.EndTest(CommonMethods.test);

                // calling Flush writes everything to the log file (Reports)
                CommonMethods.Extent.Flush();



            }

        }
    }
}