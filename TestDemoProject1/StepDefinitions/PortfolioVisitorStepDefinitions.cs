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

        public PortfolioVisitorStepDefinitions(BrowserInit browserInit) { 
            this.browserInit = browserInit;
            portfolio = new Portfolio(browserInit.GetDriver());

        }
        [Given(@"Driver is initiated for portfolio website")]
        public void GivenDriverIsInitiatedForPortfolioWebsite()
        {
            try { }
            catch(Exception e) {
                Console.WriteLine(e.ToString());
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
    }
}
