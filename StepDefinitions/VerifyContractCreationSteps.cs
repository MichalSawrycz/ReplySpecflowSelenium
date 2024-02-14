using ReplyRecruitmentTask.PageObjects;
using AventStack.ExtentReports;


namespace ReplyRecruitmentTask;

[Binding]
public class LoginSteps
{
    [Given("User is logged into app")]
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
        var SalesAndMarketingContactPage = new SalesAndMarketingPage();
        SalesAndMarketingContactPage.CreateNewContact();
    }

    [Then(@"I open the created contact and verify its data")]
    public void VerifyCreatedContact()
    {
        var SalesAndMarketingContactPage = new SalesAndMarketingPage();
        SalesAndMarketingContactPage.VerifyCreatedContact();
    }
}
