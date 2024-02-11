using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReplyRecruitmentTask.PageObjects
{
    public class HomePage : PageObjectBase
    {
        IWebDriver driver;
        public HomePage() : base()
        {
            this.driver = new ChromeDriver();
        }

        #region WebElements
        IWebElement SalesAndMarkietingSectionBtn => driver.FindElement(By.CssSelector("li[data-tab-id='LBL_TABGROUP_SALES_MARKETING']"));

        #endregion WebElements

        #region methods
        public SalesAndMarketingPage GoToSalesAndMarketingPage()
        {
            Thread.Sleep(10000);
            SalesAndMarkietingSectionBtn.Click();
            return new SalesAndMarketingPage();
        }
        #endregion methods


    }
}
