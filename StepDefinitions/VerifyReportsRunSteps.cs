using ReplyRecruitmentTask.PageObjects;
using AventStack.ExtentReports;

namespace ReplyRecruitmentTask.StepDefinitions
{
    [Binding]
    public class VerifyReportsRunSteps
    {
        private ExtentReports _extent = ExtentManager.GetInstance();
        private ExtentTest _test;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _test = _extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [Given(@"User has completed login")]
        public void GivenUserIsOnLoginPage()
        {
            var loginPage = new LoginPage();
            loginPage.NavigateTo()
            .performLoginAction()
            .VerifyIfUserIsLogged();
            _test.Log(Status.Info, "User has completed login");
        }

        [When(@"User navigate to Reports and Settings section")]
        public void GoToReportsAndSettingsPage()
        {
            var homePage = new HomePage();
            homePage.GoToReportsAndSettingsPage();
            _test.Log(Status.Info, "User navigate to Reports and Settings section");
        }

        [When(@"I find Project Profitability report")]
        public void SearchReport()
        {
            var reportsAndSettingsPage = new RaportsAndSettingsPage();
            reportsAndSettingsPage.SearchReport();
            _test.Log(Status.Info, "I find Project Profitability report");
        }

        [Then(@"I run the report and verify results were returned")]
        public void RunAndVerifyRaport()
        {
            var reportsAndSettingsPage = new RaportsAndSettingsPage();
            reportsAndSettingsPage.RunAndVerifyRaport();
            _test.Log(Status.Info, "I run the report and verify results were returned");
            ExtentManager.FlushReport();
        }
    }
}
