using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemoProject1
{
    public class GlobalObjects
    {
        public static BrowserInit BrowserInit { get; set; }
        public static void Initialize() { 
            BrowserInit = new BrowserInit();
            BrowserInit.Init();
        }


    }
}
