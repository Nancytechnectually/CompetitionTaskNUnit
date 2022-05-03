using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsQA_1.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MarsQA_1.SpecflowPages.Pages
{
    public class ManageListings : Driver
    {

       public String Title1;
        // click on view listing icon
        public void ViewListingIcon()
        {
            

            IWebElement ViewListing = driver.FindElement(By.XPath("//table/tbody/tr/td[8]/div/button"));
            ViewListing.Click();


        }
        
        public string getTitle1()
        {
            return Title1;
        }
        // click on update listing icon
        public void UpdateIcon()
        {
            IWebElement UpdateListing = driver.FindElement(By.XPath("//table/tbody/tr/td[8]/div/button[2]"));
            UpdateListing.Click();


        }

        public String Title;
        // click on delete listing icon and delete listing 
        public void DeleteListingIcon()

        {

            try
            {
                IWebElement Listing = driver.FindElement(By.CssSelector("#listing-management-section > div:nth-child(3) > div:nth-child(2) > div:nth-child(1) > table > tbody > tr:nth-child(1) > td:nth-child(3)"));
                Title = Listing.ToString();



                IWebElement UpdateListing = driver.FindElement(By.XPath("//table/tbody/tr/td[8]/div/button[3]"));
                UpdateListing.Click();



                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[text()='Yes']")).Click();

                Console.WriteLine(Title + " has been deleted");


            }
            catch (Exception NoListing)
            {
                Console.WriteLine(@"Error occurred Deleting Listing");


            }

        }

        public String getlistingBeforeDelete()
        {
            return Title;
        }




    }
}
