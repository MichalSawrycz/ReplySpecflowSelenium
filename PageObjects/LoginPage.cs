using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ReplyRecruitmentTask.PageObjects
{
    public class LoginPage : PageObjectBase
    {
        public LoginPage() : base()
        {
        }

        #region WebElements
        public IWebElement UserNameInput => driver.FindElement(By.Id("login_user"));
        public IWebElement UserPasswordInput => driver.FindElement(By.Id("login_pass"));
        public IWebElement LoginBtn => driver.FindElement(By.Id("login_button"));
        public IWebElement UserToolsBtn => driver.FindElement(By.Id("module-tools"));

        #endregion WebElements

        #region Methods
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("module-tools")));
            bool AreUserToolsDisplayed = UserToolsBtn.Displayed; 
            return AreUserToolsDisplayed; 
        }
        #endregion Methods
    }
}
