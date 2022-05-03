using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MarsQA_1.SpecflowPages.Helpers
{
    public class Wait
    {


        public static void ClickableElement(IWebDriver driver, String locator, String locatorValue, int seconds)
        {
            var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

            if (locator == "XPath")
            {

                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }
            else if (locator == "Cssselector")
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));

            }

        }


        public static void ElementVisible(IWebDriver driver, String locator, String locatorValue, int seconds)
        {
            var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

            if (locator == "XPath")
            {

                Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            }
            else if (locator == "Cssselector")
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));

            }
        }


            public static void NotClickableElement(IWebDriver driver, String locator, String locatorValue, int seconds)
            {
                var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

                if (locator == "XPath")
                {

                    Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(locatorValue)));
                }
                else if (locator == "Cssselector")
                {
                    Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(locatorValue)));

                }

       
            }   
        
     }



}

