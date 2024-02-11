using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class WebDriverManager
{
    private static IWebDriver _driver;

    public static IWebDriver Driver
    {
        get
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver();
            }
            return _driver;
        }
    }
}

