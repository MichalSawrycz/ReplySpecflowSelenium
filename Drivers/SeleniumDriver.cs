using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ShowfieldsSpecFlow.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;


        public IWebDriver Setup(string browserName)
        {

            dynamic browserConfigCapability = GetBrowserConfig(browserName);
            dynamic browserDriverCapability = GetBrowserDriver(browserName);

            new DriverManager().SetUpDriver(browserConfigCapability);
            driver = browserDriverCapability;

            _scenarioContext.Set(driver, "WebDriver");

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }

        private dynamic GetBrowserConfig(string browserName)
        {
            if (browserName.ToLower() == "chrome")
            {
                return new ChromeConfig();
            }
            if (browserName.ToLower() == "firefox")
            {
                return new FirefoxConfig();
            }
            if (browserName.ToLower() == "edge")
            {
                return new EdgeConfig();
            }

            //If non, return ChromeConfig
            return new ChromeConfig();
        }

        private dynamic GetBrowserDriver(string browserName)
        {
            if (browserName.ToLower() == "chrome")
            {
                return new ChromeDriver();
            }
            if (browserName.ToLower() == "firefox")
            {
                return new FirefoxDriver();
            }
            if (browserName.ToLower() == "edge")
            {
                return new EdgeDriver();
            }

            //If non, return ChromeDriver
            return new ChromeDriver();
        }
    }
}