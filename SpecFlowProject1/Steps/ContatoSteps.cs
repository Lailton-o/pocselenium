using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class ContatoSteps
    {
        private IWebDriver driver;
        public WebDriverWait Wait;

        public ContatoSteps(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(45));
        }

        [Given(@"Que eu adiciono novo contato")]
        public void DadoPreencherDados()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/div/header/button"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/div/aside/nav/a[6]"))).Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='lead__lead-form__lead-name']"))).SendKeys("Paletada alternada");
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='lead__lead-form__lead-email']"))).SendKeys("teste@teste.com");
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='lead__lead-form__lead-cellphone']"))).SendKeys("(19) 99841-0090");
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='css-1hwfws3 react-select__value-container']"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Telemarketing')]"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[contains(text(),'Origem')]//preceding-sibling::div[1]"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Base Mongeral')]"))).Click();            
        }
        
        [Then(@"Confirmo cadastro de novo contato")]
        public void EntaoConfirmoCadastro()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[contains(text(),'Adicionar contato')]"))).Click();
        }
    }
}
