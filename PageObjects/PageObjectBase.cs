using OpenQA.Selenium;

public class PageObjectBase
{
    protected IWebDriver driver;
    protected By mainLocator;

    public PageObjectBase()
    {
        driver = WebDriverManager.driver;
        driver.Manage().Window.Maximize();
    }
}