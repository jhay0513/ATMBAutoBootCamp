using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

class Program
{
    static void Main()
    {
        // Create Edge WebDriver
        IWebDriver driver = new EdgeDriver();

        // Set implicit wait
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100);

        // Set explicit wait
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        // Navigate to URL
        driver.Navigate().GoToUrl("https://demoqa.com/text-box");

        // Find Full Name input field
        IWebElement fullNameInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("userName")));

        // Find Submit button
        IWebElement submitButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Submit']")));

        // Type Full Name input field
        fullNameInput.SendKeys("Jason Eligio");

        // Click Submit button
        submitButton.Click();

        // Wait for 5 seconds
        Thread.Sleep(5000);

        // Close the browser
        driver.Quit();
    }
}
