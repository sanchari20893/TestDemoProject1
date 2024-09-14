using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemoProject1
{
    public class TestConfigHelper
    {
        public static IConfigurationRoot GetConfigurationBase() {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true).Build();
        }
        public static IConfigurationRoot GetSettings()
        {
            var iTestConfigurationRoot = GetConfigurationBase();
            return iTestConfigurationRoot;
        }
    }
}
