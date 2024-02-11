using NUnit.Framework;
using OpenQA.Selenium;
using ReplyRecruitmentTask.PageObjects;


namespace ReplyRecruitmentTask;

[Binding]
public class LoginSteps
{
    [Given("User is logged in")]
    public void GivenUserIsOnLoginPage()
    {
        var loginPage = new LoginPage();
        loginPage.NavigateTo()
        .performLoginAction()
        .VerifyIfUserIsLogged();
    }

    [When("User navigate to Contracts tab in Sales & Marketing section")]
    public void WhenUserEntersValidCredentials()
    {
        var homePage = new HomePage();
        homePage.GoToSalesAndMarketingPage();
    }

    [Then("U¿ytkownik jest zalogowany")]
    public void ThenUserIsLoggedIn()
    {
        
    }
}
