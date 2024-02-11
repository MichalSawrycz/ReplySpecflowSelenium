using TechTalk.SpecFlow;
using NUnit.Framework;
using ReplyRecruitmentTask.PageObjects;

namespace YourNamespace
{
    [Binding]
    public class LoginSteps
    {
        private LoginPage loginPage;

        [Given("U¿ytkownik znajduje siê na stronie logowania")]
        public void GivenUserIsOnLoginPage()
        {
            loginPage = new LoginPage();
            loginPage.NavigateTo();
        }

        [When("U¿ytkownik wprowadza poprawne dane logowania")]
        public void WhenUserEntersValidCredentials()
        {
            loginPage.EnterCredentials("username", "password");
            loginPage.ClickLoginButton();
        }

        [Then("U¿ytkownik jest zalogowany")]
        public void ThenUserIsLoggedIn()
        {
            Assert.IsTrue(loginPage.IsLoggedIn());
        }
    }
}
