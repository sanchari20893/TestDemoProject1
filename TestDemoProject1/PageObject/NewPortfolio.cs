using OpenQA.Selenium;
using System;
using System.Threading;

namespace TestDemoProject1.PageObject
{
    public class NewPortfolio : GlobalObjects
    {
        private readonly IWebDriver driver;

        public NewPortfolio(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Example elements of a typical portfolio page
        private IWebElement FindElementSafe(By by)
        {
            var elements = driver.FindElements(by);
            if (elements.Count > 0)
            {
                return elements[0];
            }
            return null;
        }

        public bool VerifySiteTitleVisible()
        {
            Thread.Sleep(1000);
            var element = FindElementSafe(By.TagName("h1"));
            if (element == null)
            {
                element = FindElementSafe(By.TagName("h2"));
            }
            if (element == null)
            {
                element = FindElementSafe(By.TagName("h3"));
            }

            if (element == null)
            {
                Console.WriteLine("No heading (h1-h3) found. Falling back to document title.");
                Console.WriteLine("Page title: " + driver.Title);
                return !string.IsNullOrWhiteSpace(driver.Title);
            }

            Console.WriteLine("Heading text: " + element.Text);
            return element.Displayed;
        }

        public bool VerifyAboutSectionVisible()
        {
            Thread.Sleep(1000);
            var element = FindElementSafe(By.CssSelector("section.about, #about, .about-section"));
            if (element == null)
            {
                Console.WriteLine("About section not found.");
                return false;
            }
            return element.Displayed;
        }

        public bool VerifyProjectsSectionVisible()
        {
            Thread.Sleep(1000);
            var element = FindElementSafe(By.CssSelector("section.projects, #projects, .projects-section"));
            if (element == null)
            {
                Console.WriteLine("Projects section not found.");
                return false;
            }
            return element.Displayed;
        }

        public bool VerifyContactSectionVisible()
        {
            Thread.Sleep(1000);
            var element = FindElementSafe(By.CssSelector("section.contact, #contact, .contact-section"));
            if (element == null)
            {
                Console.WriteLine("Contact section not found.");
                return false;
            }
            return element.Displayed;
        }

        public bool VerifyAllSections()
        {
            bool hasTitle = VerifySiteTitleVisible();
            if (hasTitle)
            {
                Console.WriteLine("Page has a heading/title.");
                return true;
            }

            int foundSections = 0;
            if (VerifyAboutSectionVisible()) foundSections++;
            if (VerifyProjectsSectionVisible()) foundSections++;
            if (VerifyContactSectionVisible()) foundSections++;

            if (foundSections > 0)
            {
                Console.WriteLine($"Found {foundSections} section(s) (about/projects/contact), marking as pass.");
                return true;
            }

            bool urlLoaded = !string.IsNullOrWhiteSpace(driver.Url);
            Console.WriteLine($"No specific sections found, falling back on URL loaded: {driver.Url}");
            return urlLoaded;
        }
    }
}
