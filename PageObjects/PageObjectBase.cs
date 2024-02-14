using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
public class PageObjectBase
{
    protected IWebDriver driver;
    protected By mainLocator;
    protected string URL;
    protected string Login;
    protected string Password;

    public PageObjectBase()
    {
        driver = WebDriverManager.driver;
        driver.Manage().Window.Maximize();

        //set path to your credential json file or use env variables form local device:

        //URL = Environment.GetEnvironmentVariable("URL");
        //Login = Environment.GetEnvironmentVariable("Login");
        //Password = Environment.GetEnvironmentVariable("Password");

        string path = @"C:\Coding\SeleniumCode\ReplyRecruitmentTask\config.json";
        dynamic config = JObject.Parse(File.ReadAllText(path));
        URL = config.URL;
        Login = config.Login;
        Password = config.Password;

        
    }
}