using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

class Program
{
    static void Main()
    {
        IWebDriver driver = new EdgeDriver();
        driver.Navigate().GoToUrl("https://atmbqa1.wpenginepowered.com/");
        driver.Quit();
    }
}
