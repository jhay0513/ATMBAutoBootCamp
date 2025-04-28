
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Module5
{
    public class Tests
    {
        private IWebDriver Driver;
        private WebDriverWait Wait;

        private IWebElement FullNameInput => Driver.FindElement(By.Id("userName"));
        private IWebElement EmailInput => Driver.FindElement(By.Id("userEmail"));
        private IWebElement CurrentAddressInput => Driver.FindElement(By.Id("currentAddress"));
        private IWebElement PermanentAddressInput => Driver.FindElement(By.Id("permanentAddress"));
        private IWebElement SubmitButton => Driver.FindElement(By.XPath("//button[text()='Submit']"));
        private IWebElement NameLabel => Driver.FindElement(By.Id("name"));
        private IWebElement EmailLabel => Driver.FindElement(By.Id("email"));
        private IWebElement CurrentAddressLabel => Driver.FindElement(By.XPath("//p[@id='currentAddress']"));
        private IWebElement PermanentAddresslabel => Driver.FindElement(By.XPath("//p[@id='permanentAddress']"));

        [SetUp]
        public void InitEach()
        {
            // Create Edge WebDriver
            Driver = new EdgeDriver();

            // Set implicit wait
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100);

            // Set explicit wait
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            // Navigate to URL
            Driver.Navigate().GoToUrl("https://demoqa.com/text-box");
        }

        [TearDown]
        public void CleanEach()
        {
            // Wait for 5 seconds
            Thread.Sleep(5000);

            // Close the browser window
            Driver.Close();

            // Quit the browser
            Driver.Quit();
        }

        [Test]
        public void EnterNameTest()
        {
            /***** Arrange *****/
            var name = "Jason Eligio";

            /***** Act *****/
            // Type Full Name input field
            FullNameInput.SendKeys(name);

            // Click Submit button
            Wait.Until(ExpectedConditions.ElementToBeClickable(SubmitButton));
            SubmitButton.Click();

            /***** Assert *****/
            Assert.That(NameLabel.Text, Is.EqualTo("Name:Jason Eligio"), "Name not matched!");
        }

        [Test]
        public void EnterEmailTest()
        {
            /***** Arrange *****/
            var email = "jason.eligio@anytimemailbox.com";

            /***** Act *****/
            // Type Email input field
            EmailInput.SendKeys(email);

            // Click Submit button
            Wait.Until(ExpectedConditions.ElementToBeClickable(SubmitButton));
            SubmitButton.Click();

            /***** Assert *****/
            Assert.That(EmailLabel.Text, Is.EqualTo("Email:jason.eligio@anytimemailbox.com"), "Email not matched!");
        }

        [Test]
        public void EnterAddressTest()
        {
            /***** Arrange *****/
            var address = "bulacan";

            /***** Act *****/
            // Type current address input field
            CurrentAddressInput.SendKeys(address);
            // Type permanent address input field
            PermanentAddressInput.SendKeys(address);

            // Click Submit button
            Wait.Until(ExpectedConditions.ElementToBeClickable(SubmitButton));
            SubmitButton.Click();

            /***** Assert *****/
            Assert.Multiple(() =>
            {
                Assert.That(CurrentAddressLabel.Text, Is.EqualTo("Current Address :bulacan"), "Current Address not matched!");
                Assert.That(PermanentAddresslabel.Text, Is.EqualTo("Permananet Address :bulacan"), "Permanent Address not matched!");
            });
        }
    }
}