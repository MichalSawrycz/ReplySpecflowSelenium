using OpenQA.Selenium;
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

        string SalesAndMarketingSectionBtnSelector = "grouptab-1";
        string SalesAndMarketingContactSectionBtnSelector = "//a[contains(@href, 'Contacts')]";
        string ReportsAndSettingsSectionBtnSelector = "//a[contains(@href, 'Reports')]";
        string ReportsAndSettingsTab = "grouptab-5";

        #endregion WebElements

        #region Methods
        public void GoToSalesAndMarketingContactPage()
        {
            
            Actions action = new Actions(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(SalesAndMarketingSectionBtnSelector)));

            action.MoveToElement(SalesAndMarkietingSectionBtn).Perform();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SalesAndMarketingContactSectionBtnSelector)));
            SalesAndMarkietingContactSectionBtn.Click();
        }
        public void GoToReportsAndSettingsPage()
        {

            Actions action = new Actions(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(ReportsAndSettingsTab)));

            action.MoveToElement(ReportsAndSettingsSectionBtn).Perform();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ReportsAndSettingsSectionBtnSelector)));
            ReportsAndSettingsSectionBtn.Click();
        }
        #endregion Methods


    }
}
