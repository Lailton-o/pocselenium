using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject1
{
    public class Util
    {
        private readonly string USER = "cicerojunior_udUCFM";
        private readonly string KEY = "Zp3C9Z6FxXY4xuWTyqRL";

        public IWebDriver BrowserStack(string fluxo = "Teste")
        {
            return new ChromeDriver();
            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "latest";
            Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            browserstackOptions.Add("os", "Windows");
            browserstackOptions.Add("osVersion", "10");
            browserstackOptions.Add("local", "false");
            browserstackOptions.Add("seleniumVersion", "4.1.0");
            browserstackOptions.Add("userName", "cicerojunior_udUCFM");
            browserstackOptions.Add("accessKey", "Zp3C9Z6FxXY4xuWTyqRL");
            browserstackOptions.Add("buildName", "Tropa de Elite");
            capabilities.AddAdditionalOption("bstack:options", browserstackOptions);

            IWebDriver driver;
            //OpenQA.Selenium.Chrome.ChromeOptions capability = new OpenQA.Selenium.Chrome.ChromeOptions();
            //capability.AddAdditionalCapability("os_version", "10", true);
            //capability.AddAdditionalCapability("browser", "Chrome", true);
            //capability.AddAdditionalCapability("browser_version", "latest", true);
            //capability.AddAdditionalCapability("os", "Windows", true);
            //capability.AddAdditionalCapability("name", "Chrome", true);//Nomear
            //capability.AddAdditionalCapability("build", "Windows", true);//Nomear
            //capability.AddAdditionalCapability("browserstack.debug", "true", true);
            //capability.AddAdditionalCapability("browserstack.user", USER, true);
            //capability.AddAdditionalCapability("browserstack.key", KEY, true);
            //capability.AddAdditionalCapability("browserstack.networkProfile", "4g-lte-advanced-good", true);
            driver = new RemoteWebDriver(new Uri("https://hub-cloud.browserstack.com/wd/hub/"), capabilities);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionName\", \"arguments\": {\"name\":\"" + fluxo + "\"}}");

            return driver;
        }
    }
}
