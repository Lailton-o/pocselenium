using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class WebDriver
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private Util helper;
        private IObjectContainer _objectContainer;

        public WebDriver(IObjectContainer objectContainer)
        {
            helper = new Util();
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = new ChromeDriver();// helper.BrowserStack();
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [BeforeStep]
        public void BeforeStep(ScenarioContext scenarioContext, IWebDriver webDriver)
        {
            var stepContext = scenarioContext.StepContext;
            var text = "browserstack_executor: {\"action\": \"annotate\", \"arguments\": {\"data\":\"" + stepContext.StepInfo.Text + "\", \"level\": \"info" + "\"}}";
            //((IJavaScriptExecutor)webDriver).ExecuteScript(text);
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext, IWebDriver webDriver)
        {
            if (null != scenarioContext.TestError)
            {
                //((IJavaScriptExecutor)webDriver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" Erro no cenário - " + scenarioContext.ScenarioInfo.Title + " | " + scenarioContext.TestError.Message + "\"}}");
            }
            else
            {
                //((IJavaScriptExecutor)webDriver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" Sucesso no cenário - " + scenarioContext.ScenarioInfo.Title  + "\"}}");
            }
            //webDriver.Quit();
        }
    }
}
