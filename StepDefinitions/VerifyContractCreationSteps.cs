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
        homePage.GoToSalesAndMarketingContactPage();
    }

    [When(@"I create a new contact")]
    public void CreateNewContact()
    {
        var SalesAndMarketingContactPage = new SalesAndMarketingContactPage();
        SalesAndMarketingContactPage.CreateNewContact();
    }

    [Then(@"I open the created contact and verify its data")]
    public void VerifyCreatedContact()
    {
        var SalesAndMarketingContactPage = new SalesAndMarketingContactPage();
        SalesAndMarketingContactPage.VerifyCreatedContact();
    }
}
