using OpenQA.Selenium;

public class PageObjectBase
{
    protected IWebDriver Driver;

    public PageObjectBase()
    {
        Driver = WebDriverManager.Driver;
    }
}