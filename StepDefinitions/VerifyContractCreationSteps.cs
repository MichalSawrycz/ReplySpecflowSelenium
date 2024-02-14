using ReplyRecruitmentTask.PageObjects;
using AventStack.ExtentReports;

namespace ReplyRecruitmentTask;

[Binding]
public class LoginSteps
{
    private ExtentReports _extent = ExtentManager.GetInstance();
    private ExtentTest _test;

    [BeforeScenario]
    public void BeforeScenario()
    {
        _test = _extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
    }

    [Given("User is logged into app")]
    public void GivenUserIsOnLoginPage()
    {
        var loginPage = new LoginPage();
        loginPage.NavigateTo()
        .performLoginAction()
        .VerifyIfUserIsLogged();
        _test.Log(Status.Info, "User is logged into app");
    }

    [When("User navigate to Contracts tab in Sales & Marketing section")]
    public void WhenUserEntersValidCredentials()
    {
        var homePage = new HomePage();
        homePage.GoToSalesAndMarketingContactPage();
        _test.Log(Status.Info, "User navigate to Contracts tab in Sales & Marketing section");
    }

    [When(@"User create a new contact")]
    public void CreateNewContact()
    {
        var SalesAndMarketingContactPage = new SalesAndMarketingPage();
        SalesAndMarketingContactPage.CreateNewContact();
        _test.Log(Status.Info, "User create a new contact");
    }

    [Then(@"User open the created contact and verify its data")]
    public void VerifyCreatedContact()
    {
        var SalesAndMarketingContactPage = new SalesAndMarketingPage();
        SalesAndMarketingContactPage.VerifyCreatedContact();
        _test.Log(Status.Info, "User open the created contact and verify its data");
        ExtentManager.FlushReport();
    }
}
