using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsQA_1.SpecflowPages.Pages
{
    public class SkillShare : Driver
    {

       // get value of listing already added and generate unique title of listing 
        public void GetExcelValue()
        {
            
            String[] linkText = new String[15];

            
           
                //Storing List elements text into String array
                for (int i = 0; i < 10; i++)
                {

                try
                {

                    int j = i + 1;

                    IWebElement links = driver.FindElement(By.XPath("//table/tbody/tr[" + j + "]/td[3]"));
                    Console.WriteLine(links.Text);
                    linkText[i] = links.Text;
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }

                }
            
               
               // save data of excel in collection

            ExcelLibHelper.PopulateInCollection(@"C:\Users\Nancy\Desktop\Competition\Competition1\MarsQA-1\SpecflowTests\Data\TestData.xlsx", "Sheet1");
            
            // check title already added against excel sheet of available title list

            for (int n = 2; n < 10; n++)
            {
                String TitleKey1 = ExcelLibHelper.ReadData(n, "Title");

                if (!linkText.Contains(ExcelLibHelper.ReadData(n, "Title")))
                {

                    Console.WriteLine(TitleKey1 + " can be added");
                    k = n;
                    break;

                }
                else
                {
                    Console.WriteLine(TitleKey1+ " was already added");

                }

            }
            // value of title to be added
              TitleKey = ExcelLibHelper.ReadData(k, "Title");



        }

        public String TitleKey1;

        public int k;
        public int getVariablek()
        {
            return k;
        }
        public String getTitleKey()

        {
            return TitleKey;

        }
        public String TitleKey;


        public void AddListing()
        {

           

            // add a description
            IWebElement description = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(2) > div > div.ui.twelve.wide.column > div.field > textarea"));
            description.SendKeys("description of the Listing");

            // Select Category dropdown

            IWebElement Category = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(3) > div.twelve.wide.column > div > div:nth-child(1) > select"));

            Category.Click();


            //select Category by value
            Wait.ElementVisible(driver, "XPath", "//*[text()='Programming & Tech']", 10);
            driver.FindElement(By.XPath("//*[text()='Programming & Tech']")).Click();



            // Select SubCategory dropdown

            IWebElement SubCategory = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(3) > div.twelve.wide.column > div > div:nth-child(2) > div:nth-child(1) > select"));
            var selectElement1 = new SelectElement(SubCategory);
            SubCategory.Click();

            //select SubCategory by value
            Wait.ElementVisible(driver, "XPath", "//*[text()='QA']", 10);
            driver.FindElement(By.XPath("//*[text()='QA']")).Click();


            // add tag 

            IWebElement tag = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(4) > div.twelve.wide.column > div > div > div > div > input"));
            tag.SendKeys("tag1");
            tag.SendKeys(Keys.Return);

            // Select Service Type as Hourly basis 

            string RadioSelectXpath1 = "//*[text()='Hourly basis service']/preceding-sibling::*";
            string RadioSelectXpath2 = "//*[text()='One-off service']/preceding-sibling::*";


            IWebElement serviceType = driver.FindElement(By.XPath(RadioSelectXpath1));
            serviceType.Click();




            // Select Location Type as On-site 


            string locationType1 = "//*[text()='On-site']/preceding-sibling::*";
            string locationType2 = "//*[text()='Online']/preceding-sibling::*";


            IWebElement SelectLocation = driver.FindElement(By.XPath(locationType1));
            SelectLocation.Click();

            // Select Available days
            // Select start and end date
            IWebElement StartDate = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(1) > div:nth-child(2) > input[type=date]"));
            StartDate.SendKeys("28062022");

          

            IWebElement EndDate = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(1) > div:nth-child(4) > input[type=date]"));
            EndDate.SendKeys("28072022");

            

            // select day of the week and corresponding time
            int a;
            string[] DayOfWeek = { "Monday", "Tuesday" };
            // to select monday Set a= "2" and for tuesday set a ="3"
            // to select Wednedday Set a= "4" and for Thursday set a ="5"
            // to select Friday Set a= "6" and for Saturday set a ="7"
            // to select Sunday Set a= "8" 



            string day1 = "Monday";


            if (DayOfWeek.Any(day1.Contains))
            {
                a = 3;
                IWebElement Day = driver.FindElement(By.XPath("//*[text()='Mon']/preceding-sibling::*"));
                Day.Click();

                IWebElement StartTime = driver.FindElement(By.XPath("//*[text()='Mon']/following::*[2]"));
                StartTime.SendKeys("0200PM");

                IWebElement EndTime = driver.FindElement(By.XPath("//*[text()='Mon']/following::*[4]"));
                EndTime.SendKeys("0500PM");
            }
            string day2 = "Tuesday";
            if (DayOfWeek.Any(day2.Contains))
            {
                a = 4;
                IWebElement Day = driver.FindElement(By.XPath("//*[text()='Tue']/preceding-sibling::*"));
                Day.Click();

                IWebElement StartTime = driver.FindElement(By.XPath("//*[text()='Tue']/following::*[2]"));
                StartTime.SendKeys("0200PM");

                IWebElement EndTime = driver.FindElement(By.XPath("//*[text()='Tue']/following::*[2]"));
                EndTime.SendKeys("0500PM");
            }
            string day3 = "Wednesday";
            if (DayOfWeek.Any(day3.Contains))
            {
                a = 5;
                IWebElement Day = driver.FindElement(By.XPath("//*[text()='Wed']/preceding-sibling::*"));
                Day.Click();

                IWebElement StartTime = driver.FindElement(By.XPath("//*[text()='Wed']/following::*[2]"));
                StartTime.SendKeys("0200PM");

                IWebElement EndTime = driver.FindElement(By.XPath("//*[text()='Wed']/following::*[2]"));
                EndTime.SendKeys("0500PM");

            }
            string day4 = "Thursday";
            if (DayOfWeek.Any(day4.Contains))
            {
                a = 6;
                IWebElement Day = driver.FindElement(By.XPath("//*[text()='Thu']/preceding-sibling::*"));
                Day.Click();

                IWebElement StartTime = driver.FindElement(By.XPath("//*[text()='Thu']/following::*[2]"));
                StartTime.SendKeys("0200PM");

                IWebElement EndTime = driver.FindElement(By.XPath("//*[text()='Thu']/following::*[2]"));
                EndTime.SendKeys("0500PM");

            }
            string day5 = "Friday";
            if (DayOfWeek.Any(day5.Contains))
            {
                a = 7;
                IWebElement Day = driver.FindElement(By.XPath("//*[text()='Fri']/preceding-sibling::*"));
                Day.Click();

                IWebElement StartTime = driver.FindElement(By.XPath("//*[text()='Fri']/following::*[2]"));
                StartTime.SendKeys("0200PM");

                IWebElement EndTime = driver.FindElement(By.XPath("//*[text()='Fri']/following::*[2]"));
                EndTime.SendKeys("0500PM");

            }
            string day6 = "Saturday";
            if (DayOfWeek.Any(day6.Contains))
            {
                a = 8;
                IWebElement Day = driver.FindElement(By.XPath("//*[text()='Fri']/preceding-sibling::*"));
                Day.Click();

                IWebElement StartTime = driver.FindElement(By.XPath("//*[text()='Fri']/following::*[2]"));
                StartTime.SendKeys("0200PM");

                IWebElement EndTime = driver.FindElement(By.XPath("//*[text()='Fri']/following::*[2]"));
                EndTime.SendKeys("0500PM");

            }
            string day7 = "Sunday";
            if (DayOfWeek.Any(day7.Contains))
            {
                a = 2;
                IWebElement Day = driver.FindElement(By.XPath("//*[text()='Sun']/preceding-sibling::*"));
                Day.Click();

                IWebElement StartTime = driver.FindElement(By.XPath("//*[text()='Sun']/following::*[2]"));
                StartTime.SendKeys("0200PM");

                IWebElement EndTime = driver.FindElement(By.XPath("//*[text()='Sun']/following::*[2]"));
                EndTime.SendKeys("0500PM");

            }


            // Select Skill Trade as credit


            string creditRadiobtn1 = "//*[text()='Credit']/preceding-sibling::*";
            string creditRadiobtn2 = "//*[text()='Skill-exchange']/preceding-sibling::*";



            IWebElement SkillTrade = driver.FindElement(By.XPath(creditRadiobtn2));
            SkillTrade.Click();



            // add Skill-Exchange tags 

            IWebElement SkillExchange = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(8) > div:nth-child(4) > div > div > div > div > div > input"));
            SkillExchange.SendKeys("Skill-Exchange1");
            SkillExchange.SendKeys(Keys.Return);

            //add Work Sample 

            driver.FindElement(By.XPath("//*[@id='selectFile']")).SendKeys(@"C:\Users\Nancy\Desktop\Competition\Competition1\MarsQA-1\SpecflowTests\Data\Work Sample.txt");


            // Select Active Status 



            string Active = "//label[text()='Active']/preceding-sibling::*";
            string Hidden = "//label[text()='Hidden']/preceding-sibling::*";


            IWebElement Status = driver.FindElement(By.XPath(Active));
            Status.Click();

            // Save the listings
            IWebElement Save = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div.ui.vertically.padded.right.aligned.grid > div > input.ui.teal.button"));
            Save.Click();



        }

        public void UpdateListing()
        {
            // Update  Title

            IWebElement Title = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div.tooltip-target.vertically.padded.ui.grid > div > div.ui.twelve.wide.column > div > div.field > input[type=text]"));
            Title.Clear();
            Title.SendKeys("Updated Title of the Listing");

            // add a description
            IWebElement description = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(2) > div > div.ui.twelve.wide.column > div.field > textarea"));
            description.Clear();
            description.SendKeys("Updated description of the Listing");

            // Select Category dropdown

            IWebElement Category = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(3) > div.twelve.wide.column > div > div:nth-child(1) > select"));

            Category.Click();


            //select  updated Category by value
            Wait.ElementVisible(driver, "XPath", "//*[text()='Programming & Tech']", 10);

            driver.FindElement(By.XPath("//*[text()='Business']")).Click();




            // Select  updated SubCategory dropdown

            IWebElement SubCategory = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(3) > div.twelve.wide.column > div > div:nth-child(2) > div:nth-child(1) > select"));
            var selectElement1 = new SelectElement(SubCategory);
            SubCategory.Click();

            //select SubCategory by value
            Wait.ElementVisible(driver, "XPath", "//*[text()='Other']", 10);
            driver.FindElement(By.XPath("//*[text()='Other']")).Click();



            var removeTags = driver.FindElements(By.XPath("//*[text()='×']"));
            foreach (var element in removeTags)
            {

                // If element properties match your selection
                element.Click();

            }


            // add tag 

            IWebElement tag = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(4) > div.twelve.wide.column > div > div > div > div > input"));

            tag.SendKeys("UpdatedTag");
            tag.SendKeys(Keys.Return);

            // Select Service Type as Hourly basis 

            string RadioSelectXpath1 = "//*[text()='Hourly basis service']/preceding-sibling::*";
            string RadioSelectXpath2 = "//*[text()='One-off service']/preceding-sibling::*";


            IWebElement serviceType = driver.FindElement(By.XPath(RadioSelectXpath1));
            serviceType.Click();




            // Select Location Type as On-site 


            string locationType1 = "//*[text()='On-site']/preceding-sibling::*";
            string locationType2 = "//*[text()='Online']/preceding-sibling::*";



            // Select Skill Trade as credit


            string creditRadiobtn1 = "//*[text()='Credit']/preceding-sibling::*";
            string creditRadiobtn2 = "//*[text()='Skill-exchange']/preceding-sibling::*";



            IWebElement SkillTrade = driver.FindElement(By.XPath(creditRadiobtn2));
            SkillTrade.Click();



            // add Skill-Exchange tags 

            IWebElement SkillExchange = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(8) > div:nth-child(4) > div > div > div > div > div > input"));
            SkillExchange.SendKeys("Updated-Skill");
            SkillExchange.SendKeys(Keys.Return);


            //add Work Sample 

            driver.FindElement(By.XPath("//*[@id='selectFile']")).SendKeys(@"C:\Users\Nancy\Desktop\Competition\Competition1\MarsQA-1\SpecflowTests\Data\Work Sample.txt");
            



            // Select Active Status 



            string Active = "//label[text()='Active']/preceding-sibling::*";
            string Hidden = "//label[text()='Hidden']/preceding-sibling::*";


            IWebElement Status = driver.FindElement(By.XPath(Active));
            Status.Click();

           

            // Save the listings
            IWebElement Save = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div.ui.vertically.padded.right.aligned.grid > div > input.ui.teal.button"));
            Save.Click();



        }
        public void dropdown ()
        {
            // Select Category dropdown

            IWebElement Category = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(3) > div.twelve.wide.column > div > div:nth-child(1) > select"));

            Category.Click();
             Value1 = "Programming & Tech";
             Value2 = "QA";

            //select Category by value
            Wait.ElementVisible(driver, "XPath", "//*[text()='"+Value1+"']", 10);
            driver.FindElement(By.XPath("//*[text()='" + Value1 + "']")).Click();



            // Select SubCategory dropdown

            IWebElement SubCategory = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(3) > div.twelve.wide.column > div > div:nth-child(2) > div:nth-child(1) > select"));
            var selectElement1 = new SelectElement(SubCategory);
            SubCategory.Click();

            //select SubCategory by value
            Wait.ElementVisible(driver, "XPath", "//*[text()='QA']", 10);
            driver.FindElement(By.XPath("//*[text()='"+Value2+"']")).Click();




        }

       public String Value1;
       public String Value2;
        

    }
}
