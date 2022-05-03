using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsQA_1.Helpers;
using OpenQA.Selenium;

namespace MarsQA_1.SpecflowPages.Pages
{
    public  class HomePage : Driver  
    {
        // click on Skill Share icon
        public void ClickonSkillshare()
        {
            IWebElement ShareSkill = driver.FindElement(By.XPath("//*[text()='Share Skill']"));
            ShareSkill.Click();


        }
        // click on manage listing icon
        public void ClickOnManageListings()
        {

            IWebElement ManageListing = driver.FindElement(By.XPath("//*[text()='Manage Listings']"));
            ManageListing.Click();



        }
         

    }
}
