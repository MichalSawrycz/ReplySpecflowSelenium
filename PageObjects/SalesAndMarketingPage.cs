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

        IWebElement CatogriesFormInput => driver.FindElement(By.Id("DetailFormcategories-input"));
        IWebElement CustomerCategory => driver.FindElement(By.XPath("//*[contains(text(), 'Customers')]"));
        IWebElement DetailFormCategoryInput => driver.FindElement(By.Id("DetailFormcategories-input"));
        IWebElement DetailFormCategorySearchInput => driver.FindElement(By.CssSelector("div#DetailFormcategories-input-search-text > input.input-text"));
        IWebElement SuppliersCaterory => driver.FindElement(By.XPath("//*[contains(text(), 'Suppliers')]"));
        IWebElement SupplierRoleBtn => driver.FindElement(By.Id("DetailFormbusiness_role-input"));
        IWebElement MISRoleOption => driver.FindElement(By.XPath("//div[contains(@class,'option-cell') and text()='MIS']"));
        IWebElement CreatedUser => driver.FindElement(By.XPath("//a[contains(text(), 'John Doe')]"));
        IWebElement RoleSaveBtn => driver.FindElement(By.Id("DetailForm_save"));
        IWebElement CreatedSupplierCategories => driver.FindElement(By.XPath("(//ul[contains(@class, 'summary-list')])[2]/li[1]"));
        IWebElement AvailableCheckboxesContainer => driver.FindElement(By.CssSelector("div.listview-status > span:nth-of-type(2)"));
        IWebElement ActionsOptions => driver.FindElement(By.CssSelector("[id*='ActionButtonHead']"));
        IWebElement DeleteOption => driver.FindElement(By.XPath("//div[contains(@class,'option-cell') and text()='Delete']"));

        string ContactCreationBtnSelector = "SubPanel_create";
        string FirstNameInputSelector = "first_name";
        string LastNameInputSelector = "last_name";
        string CustomerCategorySelector = "//*[contains(text(), 'Customers')]";
        string SuppliersCaterorySelector = "//*[contains(text(), 'Suppliers')]";
        string SupplierRoleBtnSelector = "DetailFormbusiness_role-input";
        string CreatedUserSelector = "//a[contains(text(), 'John Doe')]";
        string CategoriesVerification = "Category\r\nCustomers, Suppliers";


        #endregion WebElements

        #region Methods
        #endregion Methods

        public void CreateNewContact()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Wait().Clickable(By.Name(ContactCreationBtnSelector));
            Thread.Sleep(500); 
            ContactCreationBtn.Click();

            driver.Wait().Visible(By.Name(FirstNameInputSelector));
            FirstNameInput.SendKeys("John");

            driver.Wait().Visible(By.Name(LastNameInputSelector));
            LastNameInput.SendKeys("Doe");
            Thread.Sleep(1000);
            CatogriesFormInput.Click();
            Thread.Sleep(1000);
            driver.Wait().Visible(By.XPath(CustomerCategorySelector));
            Thread.Sleep(1000);
            CustomerCategory.Click();
            Thread.Sleep(500);
            DetailFormCategoryInput.Click();
            Thread.Sleep(500);
            DetailFormCategorySearchInput.SendKeys("Suppliers");
            Thread.Sleep(500);

            driver.Wait().Visible(By.XPath(SuppliersCaterorySelector));
            SuppliersCaterory.Click();
            driver.Wait().Clickable(By.Id(SupplierRoleBtnSelector));
            SupplierRoleBtn.Click();
            MISRoleOption.Click();
            RoleSaveBtn.Click();

        }

        public void VerifyCreatedContact()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Wait().Visible(By.XPath(CreatedUserSelector));
            CreatedUser.Click();
            string liText = CreatedSupplierCategories.Text;
            Assert.AreEqual(CategoriesVerification, liText);
        }

        public void SelectCheckboxes(int numberOfCheckboxes)
        {
            for (int i = 1; i < numberOfCheckboxes; i++)
            {
                Thread.Sleep(1000);
                IWebElement ItemListElement = driver.FindElement(By.XPath($"//table/tbody/tr[{i}]"));
                Thread.Sleep(1000);
                ItemListElement.Click();
            }
        }

        public void DeleteCheckboxes()
        {
            string CheckBoxesBeforeRemoval = AvailableCheckboxesContainer.Text;
            int NumberOfCheckBoxesBeforeRemoval = int.Parse(CheckBoxesBeforeRemoval);
            ActionsOptions.Click();
            DeleteOption.Click();


            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            Thread.Sleep(1000);
            string CheckBoxesAfterRemoval = AvailableCheckboxesContainer.Text;
            int NumberOfCheckBoxesAfterRemoval = int.Parse(CheckBoxesAfterRemoval);

            Assert.Less(NumberOfCheckBoxesAfterRemoval, NumberOfCheckBoxesBeforeRemoval);
        }
    }
}
