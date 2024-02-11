using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReplyRecruitmentTask.PageObjects
{
    public class SalesAndMarketingPage : PageObjectBase
    {
        IWebDriver driver;
        public SalesAndMarketingPage() : base()
        {
            this.driver = new ChromeDriver();
        }

        #region WebElements
        IWebElement element => driver.FindElement(By.CssSelector("li[data-tab-id='LBL_TABGROUP_SALES_MARKETING']"));
        #endregion WebElements


    }
}
