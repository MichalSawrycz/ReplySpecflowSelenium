using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ReplyRecruitmentTask.Assets
{
    public static class IWebDriverWaitHelpers
    {
        public static WaitHelper Wait(this IWebDriver driver)
        {
            return new WaitHelper(driver);
        }
    }

    public class WaitHelper
    {
        private IWebDriver driver;
        private const int DefaultWait = 5;

        public WaitHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Waiting for element to be visible
        public IWebDriver Visible(By locator, uint waitSeconds = DefaultWait, bool expectException = false)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

            if (!expectException)
            {
                Assert.DoesNotThrow(() =>
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(locator));
                }, "Exception - element is not visible.");
            }
            else
            {
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }

            return driver;
        }

        //Waiting for element to be clickable
        public IWebDriver Clickable(By locator, uint waitSeconds = DefaultWait, bool expectException = false)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

            if (!expectException)
            {
                Assert.DoesNotThrow(() =>
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                }, "Exception - element is not visible.");
            }
            else
            {
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }

            return driver;
        }
    }
}

