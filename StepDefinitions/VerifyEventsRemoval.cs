using ReplyRecruitmentTask.PageObjects;
using AventStack.ExtentReports;

namespace ReplyRecruitmentTask.StepDefinitions
{
    [Binding]
    public class VerifyEventsRemovalSteps
    {
        [Given(@"User is login into app")]
        public void GivenUserIsOnLoginPage()
        {
            var loginPage = new LoginPage();
            loginPage.NavigateTo()
            .performLoginAction()
            .VerifyIfUserIsLogged();
        }

        [When(@"I navigate to Reports & Settings")]
        public void GoToReportsAndSettingsPage()
        {
            var homePage = new HomePage();
            homePage.GoToReportsAndSettingsPage();
        }

        [When(@"I select the first 3 items in the table")]
        public void SelectingItems()
        {
            var SalesAndMarketingPage = new SalesAndMarketingPage();
            SalesAndMarketingPage.SelectCheckboxes(3);
        }

        [Then(@"I click Actions Amd Delete and verify if items were removed")]
        public void RemovingItems()
        {
            var SalesAndMarketingPage = new SalesAndMarketingPage();
            SalesAndMarketingPage.DeleteCheckboxes();
        }
    }
}
