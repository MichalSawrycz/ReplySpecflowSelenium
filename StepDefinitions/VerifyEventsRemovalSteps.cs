using ReplyRecruitmentTask.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace ReplyRecruitmentTask.StepDefinitions
{
    [Binding]
    public class VerifyEventsRemovalSteps
    {
        [Given(@"I am logged in")]
        public void GivenUserIsOnLoginPage()
        {
            var loginPage = new LoginPage();
            loginPage.NavigateTo()
            .performLoginAction()
            .VerifyIfUserIsLogged();
        }

        [When(@"User navigate to Reports and Settings section")]
        public void GoToReportsAndSettingsPage()
        {
            var homePage = new HomePage();
            homePage.GoToReportsAndSettingsPage();
        }

        [When(@"I find Project Profitability report")]
        public void SearchReport()
        {
            var reportsAndSettingsPage = new RaportsAndSettingsPage();
            reportsAndSettingsPage.SearchReport();
        }

        [Then(@"I run the report and verify results were returned")]
        public void RunAndVerifyRaport()
        {
            var reportsAndSettingsPage = new RaportsAndSettingsPage();
            reportsAndSettingsPage.RunAndVerifyRaport();
        }
    }
}
