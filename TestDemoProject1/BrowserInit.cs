using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using System.Configuration;

namespace TestDemoProject1
{
    public class BrowserInit
    {
        public static IWebDriver driver;
        
        public void Init()
        {
            InitializeBrowser();
        }

        private void InitializeBrowser()
        {
            // Set up browser options if needed
            var options = new ChromeOptions();
            // Additional options can be configured here

            // Initialize the ChromeDriver
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        public void NavigateToUrl(string environment)
        {
            // Read URL from ConfigurationManager based on the provided environment
            
            string url = BaseURL(environment);

            // Log the retrieved URL
            Console.WriteLine($"Navigating to URL: {url}");

            // Check for null references before navigating
            if (driver != null)
            {
                // Navigate to the specified URL
                driver.Navigate().GoToUrl(url);
            }
            else
            {
                // Log an error if the driver is null
                Console.WriteLine("Error: WebDriver is null. Make sure it's properly initialized.");
            }
        }

        public string BaseURL(string environment)
        {
            var config = TestConfigHelper.GetSettings();
            string baseUrl = config[environment];
            return baseUrl;
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void CloseBrowser()
        {
            // Close the browser when needed
            if (driver != null)
            {
                driver.Quit();
            }
            else
            {
                // Log an error if the driver is null
                Console.WriteLine("Error: WebDriver is null. Unable to close the browser.");
            }

        }
    }
}
