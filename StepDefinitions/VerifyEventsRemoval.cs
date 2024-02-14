using ReplyRecruitmentTask.PageObjects;
using AventStack.ExtentReports;

namespace ReplyRecruitmentTask;

[Binding]
public class VerifyEventsRemovalSteps
{
    private ExtentReports _extent = ExtentManager.GetInstance();
    private ExtentTest _test;

    [BeforeScenario]
    public void BeforeScenario()
    {
        _test = _extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
    }

    [Given(@"User is login into app")]
    public void GivenUserIsOnLoginPage()
    {
        var loginPage = new LoginPage();
        loginPage.NavigateTo()
        .performLoginAction()
        .VerifyIfUserIsLogged();
        _test.Log(Status.Info, "User is login into app");
    }

    [When(@"User navigate to Reports & Settings")]
    public void GoToReportsAndSettingsPage()
    {
        var homePage = new HomePage();
        homePage.GoToReportsAndSettingsPage();
        _test.Log(Status.Info, "User navigate to Reports & Settings");
    }

    [When(@"User select the first 3 items in the table")]
    public void SelectingItems()
    {
        var SalesAndMarketingPage = new SalesAndMarketingPage();
        SalesAndMarketingPage.SelectCheckboxes(4);
        _test.Log(Status.Info, "User select the first 3 items in the table");
    }

    [Then(@"User click Actions Amd Delete and verify if items were removed")]
    public void RemovingItems()
    {
        var SalesAndMarketingPage = new SalesAndMarketingPage();
        SalesAndMarketingPage.DeleteCheckboxes();
        _test.Log(Status.Info, "User click Actions Amd Delete and verify if items were removed");
        ExtentManager.FlushReport();
    }
}
