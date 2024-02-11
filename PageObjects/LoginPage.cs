using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReplyRecruitmentTask.PageObjects
{
    public class LoginPage : PageObjectBase
    {
        IWebDriver driver;
        public LoginPage() : base()
        {
            this.driver = new ChromeDriver();
        }

        #region WebElements
        public IWebElement UserNameInput => driver.FindElement(By.Id("login_user"));
        public IWebElement UserPasswordInput => driver.FindElement(By.Id("login_pass"));
        public IWebElement LoginBtn => driver.FindElement(By.Id("login_button"));
        public IWebElement UserToolsBtn => driver.FindElement(By.Id("module-tools"));

        #endregion WebElements

        public LoginPage NavigateTo()
        {
            driver.Navigate().GoToUrl("https://demo.1crmcloud.com/login.php?login_module=Home&login_action=index");
            return this;
        }

        public LoginPage performLoginAction()
        {
            UserNameInput.SendKeys("admin");
            UserPasswordInput.SendKeys("admin");
            LoginBtn.Click();
            return this;
        }

        public bool VerifyIfUserIsLogged()
        {
            Thread.Sleep(10000);
            bool AreUserToolsDisplayed = UserToolsBtn.Displayed; 
            return AreUserToolsDisplayed; 
        }
    }
}
