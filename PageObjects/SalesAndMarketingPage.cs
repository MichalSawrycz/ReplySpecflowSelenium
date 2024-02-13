using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ReplyRecruitmentTask.Assets;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using AngleSharp.Text;

namespace ReplyRecruitmentTask.PageObjects
{
    public class SalesAndMarketingPage : PageObjectBase
    {
        public SalesAndMarketingPage() : base()
        {
        }

        #region WebElements
        IWebElement ContactCreationBtn => driver.FindElement(By.Name("SubPanel_create"));
       
        IWebElement FirstNameInput => driver.FindElement(By.Name("first_name"));
        IWebElement LastNameInput => driver.FindElement(By.Name("last_name"));
        IList<IWebElement> CheckboxesOnSite => driver.FindElements(By.XPath("//table/tbody/tr"));


        #endregion WebElements

        #region Methods
        #endregion Methods

        public void CreateNewContact()
        {
            driver.Wait().Clickable(By.Name("SubPanel_create"));
            Thread.Sleep(1000);
            ContactCreationBtn.Click();

            driver.Wait().Visible(By.Name("first_name"));
            FirstNameInput.SendKeys("John");

            driver.Wait().Visible(By.Name("last_name"));
            LastNameInput.SendKeys("Doe");

            Thread.Sleep(1000);
            driver.FindElement(By.Id("DetailFormcategories-input")).Click();
            driver.Wait().Visible(By.XPath("//*[contains(text(), 'Customers')]"));
            driver.FindElement(By.XPath("//*[contains(text(), 'Customers')]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("DetailFormcategories-input")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("div#DetailFormcategories-input-search-text > input.input-text")).SendKeys("Suppliers");

            driver.Wait().Visible(By.XPath("//*[contains(text(), 'Suppliers')]"));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[contains(text(), 'Suppliers')]")).Click();
            //driver.Wait().Clickable(By.Id("DetailFormbusiness_role-input"));
            //driver.FindElement(By.Id("DetailFormbusiness_role-input")).Click();
            //driver.FindElement(By.Id("DetailFormbusiness_role-input")).Click();
            //Actions action = new Actions(driver);
            //action.MoveToElement(driver.FindElement(By.Id("DetailFormbusiness_role-input"))).ClickAndHold();
            //Thread.Sleep(5000);
            //driver.Wait().Visible(By.XPath("//*[contains(text(), 'CEO')]"));
            //driver.FindElement(By.XPath("//*[contains(text(), 'CEO')]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("DetailForm_save")).Click();

        }

        public void VerifyCreatedContact()
        {
            Thread.Sleep(1000);
            driver.Wait().Visible(By.XPath("//a[contains(text(), 'John Doe')]"));
            driver.FindElement(By.XPath("//a[contains(text(), 'John Doe')]")).Click();
            Thread.Sleep(2000);
            string liText = driver.FindElement(By.XPath("(//ul[contains(@class, 'summary-list')])[2]/li[1]")).Text;
            Assert.AreEqual("Category\r\nCustomers, Suppliers", liText);
        }

        public void SelectCheckboxes(int numberOfCheckboxes)
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//table/tbody/tr[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//table/tbody/tr[2]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//table/tbody/tr[3]")).Click();
        }

        public void DeleteCheckboxes()
        {
            string CheckBoxes1 = driver.FindElement(By.CssSelector("div.listview-status > span:nth-of-type(2)")).Text;
            int CheckBoxes1Int = int.Parse(CheckBoxes1);
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("[id*='ActionButtonHead']")).Click();
            Thread.Sleep(200);
            driver.FindElement(By.XPath("//div[contains(@class,'option-cell') and text()='Delete']")).Click();
            Thread.Sleep(1000);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            Thread.Sleep(5000);
            string CheckBoxes2 = driver.FindElement(By.CssSelector("div.listview-status > span:nth-of-type(2)")).Text;
            int CheckBoxes2Int = int.Parse(CheckBoxes2);

            Assert.Less(CheckBoxes2Int, CheckBoxes1Int);
        }
    }
}
