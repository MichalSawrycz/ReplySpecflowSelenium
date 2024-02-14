using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ReplyRecruitmentTask.Assets;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace ReplyRecruitmentTask.PageObjects
{
    public class RaportsAndSettingsPage : PageObjectBase
    {
        public RaportsAndSettingsPage() : base()
        {
        }

        #region WebElements
        IWebElement ReportsAndSettingsSearchInput => driver.FindElement(By.Id("filter_text"));
        IWebElement SearchResult => driver.FindElement(By.ClassName("listViewNameLink"));
        IWebElement RunReportBtn => driver.FindElement(By.Name("FilterForm_applyButton"));

        string ReportsAndSettingsSearchInputSelector = "filter_text";
        string StartingSoonReportResult = "//*[contains(text(), 'Starting Soon')]";

        #endregion WebElements

        string ItemName = "Project Profitability";

        #region Methods
        public void SearchReport()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Wait().Visible(By.Id(ReportsAndSettingsSearchInputSelector));
            ReportsAndSettingsSearchInput.SendKeys(ItemName);
            Thread.Sleep(500);
            ReportsAndSettingsSearchInput.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            SearchResult.Click();
        }

        public void RunAndVerifyRaport()
        {
            Thread.Sleep(1000);
            RunReportBtn.Click();
            bool IsRaportResultsVisibler = driver.FindElement(By.XPath(StartingSoonReportResult)).Displayed;
            Assert.IsTrue(IsRaportResultsVisibler);
        }
        #endregion Methods
    }
}
