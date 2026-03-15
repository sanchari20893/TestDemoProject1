using System;
using TechTalk.SpecFlow;
using TestDemoProject1.PageObject;

namespace TestDemoProject1.StepDefinitions
{
    [Binding]
    public class PortfolioVisitorStepDefinitions
    {
        private BrowserInit browserInit;
        private readonly Portfolio portfolio;
        private readonly NewPortfolio newPortfolio;

        public PortfolioVisitorStepDefinitions(BrowserInit browserInit) { 
            this.browserInit = browserInit;
            portfolio = new Portfolio(browserInit.GetDriver());
            newPortfolio = new NewPortfolio(browserInit.GetDriver());

        }
        [Given(@"Driver is initiated for portfolio website")]
        public void GivenDriverIsInitiatedForPortfolioWebsite()
        {
            // Browser init is handled by Hooks.BeforeScenario()
            if (browserInit.GetDriver() == null)
            {
                throw new Exception("WebDriver was not initialized in BeforeScenario hook.");
            }
        }

        [When(@"Verify the portfolio page is open for the '(.*)'")]
        public void WhenVerifyThePortfolioPageIsOpenForThe(string SITE)
        {
            browserInit.NavigateToUrl(SITE);

        }


        [Then(@"Verify the portfolio page content")]
        public void ThenVerifyThePortfolioPageContent()
        {
            portfolio.VerifyName();
            portfolio.VerifySkills();
        }

        [Then(@"Verify the new portfolio page content")]
        public void ThenVerifyTheNewPortfolioPageContent()
        {
            if (!newPortfolio.VerifyAllSections())
            {
                throw new Exception("New portfolio page content validation failed.");
            }
        }
    }
}
