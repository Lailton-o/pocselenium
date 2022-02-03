using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class SimulacaoDeProdutosSteps
    {
        private IWebDriver driver;
        public WebDriverWait Wait;

        public SimulacaoDeProdutosSteps(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
        }

        [Given(@"Que eu preencha dados basicos do cliente")]
        public void DadoQueEuPreenchaDadosBasicosDoCliente()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='CPF']"))).SendKeys("59075029080");
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Name("birthday"))).SendKeys("08/12/1990");
            //Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Data de Nascimento'])[1]/following::div[6]"))).SendKeys("teste@teste.com");
            EsperaAparecerClicaEscreve(driver, By.XPath("//label[@for='state_id']/preceding-sibling::div[contains(@class, 'vd-input-suggestion')]//div[contains(@class, 'vd-input-suggestion__input')]/input"), "PARANA");
            EsperaAparecerClica(driver, By.XPath("//div[contains(@class, 'vd-input-suggestion__option')][text()='PARANA']"));
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@class='radio-list__label' and contains(text(),'Masculino')]"))).Click();

        }
        
        [Given(@"que eu acesse o cotador")]
        public void DadoQueEuAcesseOCotador()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='profile_form']/div/div/div[1]/div[2]/div/div[2]/button"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains (text(),'Sua família')]//following-sibling::button[contains (text(),'Ir para o cotador')]"))).Click();
        }
        
        [Given(@"que eu preencha os dados da cotacao do cliente")]
        public void DadoQueEuPreenchaOsDadosDaCotacaoDoCliente()
        {

            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[contains(@class,'loading')]")));
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@for='quoter_form__your-data__gender__2' and contains(text(),'Feminino')]"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='quoter_form__your-data__occupation__input']"))).Click();
            //Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='quoter_form__your-data__occupation__input']"))).SendKeys("Empregado em empresa privada");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'Empregado em empresa privada')]"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='quoter_form__your-data__works_as__input']"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='quoter_form__your-data__works_as__input']"))).SendKeys("Advogado");
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'vd-input-suggestion__option')][text()='Advogado']"))).Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Sua renda mensal']"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Sua renda mensal']"))).SendKeys("R$ 6.000,00");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@class='radio-list__label' and @for='quoter_form__your-data__has_companion__1']"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='quoter_form__your-data__companion_birthday']"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='quoter_form__your-data__companion_birthday']"))).SendKeys("01/09/1993");
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@for='quoter_form__your-data__companion_gender__2' and contains(text(),'Feminino')]"))).Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='quoter_form']/div/div/div/div[2]/div/div[2]/button"))).Click();
            //EsperaAparecerClica(driver, By.XPath("//*[@id='quoter_form__your - data__occupation__input']"), 45);
            //EsperaAparecerClica(driver, By.XPath("//div[contains(text(), 'Empregado em empresa privada')]"), 45);
            //EsperaAparecerClicaEscreve(driver, By.XPath("//input[@id='quoter_form__your-data__works_as__input']"), "Advogado");
            //EsperaAparecerClica(driver, By.XPath("//div[contains(@class, 'vd-input-suggestion__option')][text()='Advogado']"));
        }
        
        [Given(@"que eu selecione")]
        public void DadoQueEuSelecione()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Given(@"que eu cote")]
        public void DadoQueEuCote()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Given(@"que eu clico em gerar estudo")]
        public void DadoQueEuClicoEmGerarEstudo()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"obtenho um pdf")]
        public void EntaoObtenhoUmPdf()
        {
            //ScenarioContext.Current.Pending();
        }

        public virtual void EsperaAparecerClicaEscreve(IWebDriver driver, By by, string text, int tempo = 100)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            if (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by)).Displayed && element.TagName != null)
            {
                element.Click();
                element.SendKeys(text);
            }
        }

        public virtual void EsperaAparecerClica(IWebDriver driver, By by, int tempo = 70)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            if (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by)).Displayed && element.TagName != null)
            {
                element.Click();
            }
        }

        public virtual bool EsperarCarregar(IWebDriver driver, By by, int tempo = 120)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
            wait.Timeout = TimeSpan.FromSeconds(45);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            wait.Timeout = TimeSpan.FromSeconds(tempo);
            if (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by)))
            {
                return true;
            }
            else
                return false;
        }
    }
}
