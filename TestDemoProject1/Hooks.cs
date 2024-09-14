using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemoProject1
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            // Initialize global objects before each scenario
            GlobalObjects.BrowserInit = new BrowserInit();
           GlobalObjects.BrowserInit.Init();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Close the browser after each scenario
            GlobalObjects.BrowserInit.CloseBrowser();
        }
    }

    
}

