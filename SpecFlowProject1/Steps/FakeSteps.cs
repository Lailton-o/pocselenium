using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class FakeSteps
    {
        [Given(@"the first number is (.*)")]
        public void DadoTheFirstNumberIs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the second number is (.*)")]
        public void DadoTheSecondNumberIs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the two numbers are added")]
        public void QuandoTheTwoNumbersAreAdded()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be (.*)")]
        public void EntaoTheResultShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
