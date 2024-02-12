using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ReplyRecruitmentTask.PageObjects
{
    public class HomePage : PageObjectBase
    {
        public HomePage() : base()
        {
        }

        #region WebElements
        IWebElement SalesAndMarkietingSectionBtn => driver.FindElement(By.Id("grouptab-1"));
        IWebElement SalesAndMarkietingContactSectionBtn => driver.FindElement(By.XPath("//a[contains(@href, 'Contacts')]"));
        IWebElement ReportsAndSettingsSectionBtn => driver.FindElement(By.XPath("//a[contains(@href, 'Reports')]"));

        #endregion WebElements

        #region Methods
        public void GoToSalesAndMarketingContactPage()
        {
            
            Actions action = new Actions(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("grouptab-1")));

            action.MoveToElement(SalesAndMarkietingSectionBtn).Perform();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@href, 'Contacts')]")));
            SalesAndMarkietingContactSectionBtn.Click();
        }
        public void GoToReportsAndSettingsPage()
        {

            Actions action = new Actions(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("grouptab-5")));

            action.MoveToElement(ReportsAndSettingsSectionBtn).Perform();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@href, 'Reports')]")));
            ReportsAndSettingsSectionBtn.Click();
        }
        #endregion Methods


    }
}
