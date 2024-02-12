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



        #endregion WebElements

        #region Methods
        public void SearchReport()
        {
            driver.Wait().Visible(By.Id("filter_text"));
            ReportsAndSettingsSearchInput.SendKeys("Project Profitability");
            Thread.Sleep(5000);
            ReportsAndSettingsSearchInput.SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            SearchResult.Click();
        }

        public void RunAndVerifyRaport()
        {
            Thread.Sleep(5000);
            RunReportBtn.Click();
            Thread.Sleep(5000);
            bool IsRaportResultsVisibler = driver.FindElement(By.XPath("//*[contains(text(), '2 Tall Stores')]")).Displayed;
            Assert.IsTrue(IsRaportResultsVisibler);
        }
        #endregion Methods
    }
}
