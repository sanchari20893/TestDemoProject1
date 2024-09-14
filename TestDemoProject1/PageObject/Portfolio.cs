using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestDemoProject1.PageObject
{
    public class Portfolio : GlobalObjects
    {
        private readonly IWebDriver driver;

        public Portfolio(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement Name => driver.FindElement(By.XPath("//*[@id=\"uXnzLPYebxEtkB1v\"]"));
        public bool VerifyName() {
            Thread.Sleep(1000);
            Console.WriteLine(Name.Text); 
            return true;
        }
        public IWebElement TechnicalSkills => driver.FindElement(By.XPath("//*[@id=\"Kgk5crYjX1FCBjlI\"]"));

        public IWebElement footer => driver.FindElement(By.ClassName("footer-container"));
        public bool VerifySkills() {
            Thread.Sleep(7000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", footer);
           
            Console.WriteLine(TechnicalSkills.Text);
            return true;
        }

    }
}
