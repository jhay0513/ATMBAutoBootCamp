using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

class Program
{
    static void Main()
    {
        // Create Edge WebDriver
        IWebDriver driver = new EdgeDriver();

        // Navigate to URL
        driver.Navigate().GoToUrl("https://demoqa.com/text-box");

        // Find Full Name input field
        IWebElement fullNameInput = driver.FindElement(By.Id("userName"));

        // Find Submit button
        IWebElement submitButton = driver.FindElement(By.XPath("//button[text()='Submit']"));

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
