using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class BaixarPDFSteps
    {
        private IWebDriver driver;
        public WebDriverWait Wait;

        public BaixarPDFSteps(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
        }

        [Given(@"Que eu acessei o status da proposta")]
        public void DadoQueEuAcesseiOStatusDaProposta()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/div/header/button"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/div/aside/nav/a[8]"))).Click();
        }
        
        [Given(@"encontrei a proposta de numero (.*)")]
        public void DadoEncontreiAPropostaDeNumero(int numeroProposta)
        {
           Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//p[contains(text(),'{numeroProposta}')]")));
        }

        [Then(@"realizo o download (.*)")]
        public void EntaoRealizoODownload(int numeroProposta)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//p[contains(text(),'{numeroProposta}')]//ancestor::*[@class='proposal-status-entry proposal-status-entry--finished']//span[contains(text(),'Baixar proposta')]"))).Click();
        }
    }
}
