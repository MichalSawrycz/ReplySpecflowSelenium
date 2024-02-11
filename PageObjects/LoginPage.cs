using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ReplyRecruitmentTask.PageObjects
{
    public class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "login_user")]
        private IWebElement LoginUserNameInput;

        [FindsBy(How = How.Id, Using = "login_pass")]
        private IWebElement LoginUserPasswordInput;

        [FindsBy(How = How.Id, Using = "login_button")]
        private IWebElement LoginUserButton;

        private void performLoginAction()
        {
            LoginUserNameInput.SendKeys("admin");
            LoginUserPasswordInput.SendKeys("admin");
            LoginUserButton.Click();
        }
    }
}
