using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class AccessSteps
    {
        private IWebDriver driver;
        public WebDriverWait Wait;

        public AccessSteps(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
        }

        [Given(@"Acessar o Venda Digital")]
        public void DadoAcessarOVendaDigital()
        {
            driver.Navigate().GoToUrl($"https://hmgdigital.mag.com.br/");
            SessionStorageSetItem(driver);
            driver.Manage().Window.Maximize();

            var btnAccept = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id='onetrust-accept-btn-handler']")));
            btnAccept.Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'loading')]")));
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[contains(@class,'loading')]")));
                       
        }

        [Given(@"Clicar na parceria (.+)")]
        [When(@"Clicar na parceria (.+)")]
        public void QuandoClicarNaParceria(string parceria)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//label[contains(text(), '{parceria}')]"))).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='button-default']"))).Click();
        }

        //TODO Clicar em hierarquia
        
        [Given(@"Confirmo parceria e hierarquia")]
        [Then(@"Confirmo parceria e hierarquia")]
        public void EntaoAvancarDePagina()
        {
            Wait.Until(ExpectedConditions.UrlMatches("/home"));
            Assert.Equal("https://hmgdigital.mag.com.br/home", driver.Url);
        }

        private void SessionStorageSetItem(IWebDriver driver)
        {
            string sessionKey = "oidc.user:https://identidadehmg.mongeralaegon.com.br/:VendaDigitalSPAHmg";
            string sessionValue = "{\"id_token\":\"eyJhbGciOiJSUzI1NiIsImtpZCI6Ijc5NTE1MUUxNjI0QkU3QTc3NjZGMTAzRjg4Q0ExQTZDMjFFRUI5QjgiLCJ0eXAiOiJKV1QiLCJ4NXQiOiJlVkZSNFdKTDU2ZDJieEFfaU1vYWJDSHV1YmcifQ.eyJuYmYiOjE2NDM4OTM5NzgsImV4cCI6MTY0Mzg5NDI3OCwiaXNzIjoiaHR0cHM6Ly9pZGVudGlkYWRlaG1nLm1vbmdlcmFsYWVnb24uY29tLmJyIiwiYXVkIjoiVmVuZGFEaWdpdGFsU1BBSG1nIiwiaWF0IjoxNjQzODkzOTc4LCJhdF9oYXNoIjoiWWwtVkM5ekdOT0lrMm5pNmhMRDdnUSIsInNfaGFzaCI6IjE4Zmd4d0hhblh6RExFQlR2M25qaUEiLCJzaWQiOiJ0UUFCUW9ROEVnWEd6YkxhQmYtLWlBIiwic3ViIjoiNjk1ODE0MjQwMzIiLCJhdXRoX3RpbWUiOjE2NDM2NTU2NDgsImlkcCI6ImxvY2FsIiwiZW1haWwiOiJjYW5haXNkaWdpdGFpc0BtYWcuY29tLmJyIiwicGhvbmVfbnVtYmVyIjoiKDIxKTk5OTk5OTk5OSIsIm5hbWUiOiJUZXN0ZSBDYW5haXMgRGlnaXRhaXMiLCJyb2xlIjpbIkJlbmVmaWNpb3MiLCJBUEkuRmF0dXJhbWVudG8iLCJBUEkgUHJvZHV0byIsIkFQSSBBdGVuZGltZW50byIsIkFQSS5Cb2xldG8iLCJBUEkuRGViaXRvQ29udGEiLCJBUEkgQ2xpZW50ZSAzNjAiLCJBUEkuUXVlc3Rpb25hcmlvIiwiQVBJIERvY3VtZW50byIsIkFQSSBDYXJ0YW8gZGUgQ3JlZGl0byIsIkFQSS5FbnJpcXVlY2ltZW50b0RhZG9zIiwiQ29udHJvbGVBY2Vzc29TZXJ2aWNlIiwiQVBJLlZlbmRhIiwiTGVhZC5BUEkiLCJBUEkuQmVuZWZpY2lhcmlvIiwiRVNCLkNFUCIsIkFQSSBNYWdQYXkiLCJBUEkuU2VndXJhZG9yYSIsIklkZW50aXR5IFNlcnZlciIsIkFQSSBNb25nZXJhbCBBZWdvbiIsIkFQSS5DcmVkaXRvQ29udGEiLCJBUEkgUHJldmlkZW5jaWEiLCJBUEkgQmVtIEVzdGFyIiwiQVBJIFN1YnNjcmljYW8iLCJBUEkuU2FsZXMiLCJBUEkgTm90aWZpY2Fkb3IgRXZlbnRvIDM2MCJdLCJhZHZhbmNlZFNhbGUiOiIwIiwiY3BmIjoiNjk1ODE0MjQwMzIiLCJPQXV0aDIuQ2xpZW50QWxsb3dlZFNjb3BlcyI6WyJhcGljbGllbnRlIiwiYXBpc2VndXJhZG9yYSJdLCJ0aXBvUGVzc29hIjoiRmlzaWNhIiwiY29kUHJvZHV0b3IiOiIyNzAwMjYyOCIsImVtcHJlc2EiOiIzMzYwODMwODAwMDE3MyIsImdvb2dsZUNhbGVuZGFyaW9JZCI6Im9ubmV2MmR0MnNkMzkxbGRlMGljZG9qbms0QGdyb3VwLmNhbGVuZGFyLmdvb2dsZS5jb20iLCJhbXIiOlsicHdkIl19.PR7kTvGnxPM6OuoqrD2cw236LVwA_i3zYWQ9tekSFC8MCLZgThCvJgab8RQOnUODjOZgl3h9T2d6O3CVEy7QtG4hJ0gyI0PZdm6UJ50OsLdjZfKG0GFhxdnOpFnaGU7ehrYGMbdqVn-NDE5p3M_fQX5eUWUKJKra_rNtsbM-3dJljuCY8rFi4CD3fc01gyrMnj1GgqhWQdjQRCf7uZ0JOlcQfR8FTk_HllJuSs0RpUCVlAbsnqIPZdAW4BnUTpGFCdxp-tJ-8clvPp3E0sITyFOVz6i-3E42xRuSbmNWC9ebU6-PQdXL1Kw83GTthCyO2PZAzzjdiqg4UWLjlR6NFg\",\"session_state\":\"oYKFsN4Pb6el3Jn9hN9qA6RT8mktxS8bys6Vy6PNf5k.FwbrMP4gTakuP8sStmB2Xg\",\"access_token\":\"eyJhbGciOiJSUzI1NiIsImtpZCI6Ijc5NTE1MUUxNjI0QkU3QTc3NjZGMTAzRjg4Q0ExQTZDMjFFRUI5QjgiLCJ0eXAiOiJKV1QiLCJ4NXQiOiJlVkZSNFdKTDU2ZDJieEFfaU1vYWJDSHV1YmcifQ.eyJuYmYiOjE2NDM4OTM5NzgsImV4cCI6MTY0Mzk4MDM3OCwiaXNzIjoiaHR0cHM6Ly9pZGVudGlkYWRlaG1nLm1vbmdlcmFsYWVnb24uY29tLmJyIiwiYXVkIjpbImh0dHBzOi8vaWRlbnRpZGFkZWhtZy5tb25nZXJhbGFlZ29uLmNvbS5ici9yZXNvdXJjZXMiLCI1YzUzOTdiZC1mZjBmLTRhYzQtOWQwNi0wNDZiZTJhNzlmNGUiLCI3OTBmMmMyOC0wMDIzLTQ2MDAtODMwZS0xNWUwYzZjNDhmNzkiLCI5MmM2ZWE5NC04MjlmLTRkODAtOGM3Zi0xYTA3NzNlNzllNmQiLCIyYTI4MTMxMC0wZTU0LTQyNzMtODc1Yy0xZDI2MDEwNjExM2IiLCIyY2M3YWNmYy04YTQzLTQ4MDItYjU5Ny04ZmRlNTc0ZWY0NmEiLCI2M2I1MzEwZi00ZjRjLTRkNTYtOWMxZi1hZDdkYTc4MDFjZTgiLCJjYjAxYTA2ZC0zZjdhLTQyZDgtYjViYi1hZWQ1MjJhZWNlZTIiLCJkZjc3YmYyZS0yODgzLTQxOGItYmZlMy1iNjJjNDliYzIzZjAiLCIyZjc3OTE0ZC0wZGQwLTRkZjYtYWUwMS1iYzJkNzRmOTA5YzEiLCJkNTQ3M2E5Mi0wYzY2LTRlODMtYjFiNS1jMmJkYWJmYmIyMjkiLCI3ODkzMWU1YS0wYmJhLTRmOTYtYjBlOS1kNGU2YWU4Mzk1ZmYiXSwiY2xpZW50X2lkIjoiVmVuZGFEaWdpdGFsU1BBSG1nIiwic3ViIjoiNjk1ODE0MjQwMzIiLCJhdXRoX3RpbWUiOjE2NDM2NTU2NDgsImlkcCI6ImxvY2FsIiwiZW1haWwiOiJjYW5haXNkaWdpdGFpc0BtYWcuY29tLmJyIiwicGhvbmVfbnVtYmVyIjoiKDIxKTk5OTk5OTk5OSIsIm5hbWUiOiJUZXN0ZSBDYW5haXMgRGlnaXRhaXMiLCJyb2xlIjpbIkJlbmVmaWNpb3MiLCJBUEkuRmF0dXJhbWVudG8iLCJBUEkgUHJvZHV0byIsIkFQSSBBdGVuZGltZW50byIsIkFQSS5Cb2xldG8iLCJBUEkuRGViaXRvQ29udGEiLCJBUEkgQ2xpZW50ZSAzNjAiLCJBUEkuUXVlc3Rpb25hcmlvIiwiQVBJIERvY3VtZW50byIsIkFQSSBDYXJ0YW8gZGUgQ3JlZGl0byIsIkFQSS5FbnJpcXVlY2ltZW50b0RhZG9zIiwiQ29udHJvbGVBY2Vzc29TZXJ2aWNlIiwiQVBJLlZlbmRhIiwiTGVhZC5BUEkiLCJBUEkuQmVuZWZpY2lhcmlvIiwiRVNCLkNFUCIsIkFQSSBNYWdQYXkiLCJBUEkuU2VndXJhZG9yYSIsIklkZW50aXR5IFNlcnZlciIsIkFQSSBNb25nZXJhbCBBZWdvbiIsIkFQSS5DcmVkaXRvQ29udGEiLCJBUEkgUHJldmlkZW5jaWEiLCJBUEkgQmVtIEVzdGFyIiwiQVBJIFN1YnNjcmljYW8iLCJBUEkuU2FsZXMiLCJBUEkgTm90aWZpY2Fkb3IgRXZlbnRvIDM2MCJdLCJhZHZhbmNlZFNhbGUiOiIwIiwiY3BmIjoiNjk1ODE0MjQwMzIiLCJPQXV0aDIuQ2xpZW50QWxsb3dlZFNjb3BlcyI6WyJhcGljbGllbnRlIiwiYXBpc2VndXJhZG9yYSJdLCJ0aXBvUGVzc29hIjoiRmlzaWNhIiwiY29kUHJvZHV0b3IiOiIyNzAwMjYyOCIsImVtcHJlc2EiOiIzMzYwODMwODAwMDE3MyIsImdvb2dsZUNhbGVuZGFyaW9JZCI6Im9ubmV2MmR0MnNkMzkxbGRlMGljZG9qbms0QGdyb3VwLmNhbGVuZGFyLmdvb2dsZS5jb20iLCJqdGkiOiJxRVVBblFaTUl6NmtpWDl5ZWswUmN3Iiwic2NvcGUiOlsib3BlbmlkIiwiZW1haWwiLCJwcm9maWxlIiwiYXBpdmVuZGEiLCJmYXR1cmFtZW50byIsImNhcnRhb2NyZWRpdG8iLCJjbGllbnRlMzYwIiwiYXBpc2VndXJhZG9yYSIsImRlYml0b2NvbnRhIiwiYXBpZG9jdW1lbnRvcyIsInN1YnNjcmljYW8iLCJwcm9ncmFtYWRpZ2l0YWxsb2dpbiIsInNhbGVzIl0sImFtciI6WyJwd2QiXX0.wjHlslzKT5wXPdHPi5UiEDBRepuZwVeAe-4LCSTwY7jOA9i8hsDykkCrWw7AMtUC_NgWbJRixB_tlSD7GgTAPqTybAtB_EPjFzgTvllmLJ27tKvzYCk4qYXtkO7OWp31BarVfzzBaXNVTOWxqsfvZjzxo-_X24XNpOM7Z0xsxmCDBCOkgdpcNKeCRvSu3OawDrpEyTw862FzLqouuhK8gAKf-L08xQtZZysjZch43Pa7dfPNbLy9sCR4A45O6o2S9cxtKKW-cDGexzm_RhUszyDxU8fRL9qp8BXFDaCw2PL_i6L5VxdEBbUIQcjUQmr0ykEWgMpiUCA1SgIQLRy7eg\",\"token_type\":\"Bearer\",\"scope\":\"openid email profile apiseguradora apivenda programadigitallogin subscricao cliente360 apidocumentos sales faturamento cartaocredito debitoconta\",\"profile\":{\"s_hash\":\"18fgxwHanXzDLEBTv3njiA\",\"sid\":\"tQABQoQ8EgXGzbLaBf--iA\",\"sub\":\"69581424032\",\"auth_time\":1643655648,\"idp\":\"local\",\"email\":\"canaisdigitais@mag.com.br\",\"phone_number\":\"(21)999999999\",\"name\":\"Teste Canais Digitais\",\"role\":[\"Beneficios\",\"API.Faturamento\",\"API Produto\",\"API Atendimento\",\"API.Boleto\",\"API.DebitoConta\",\"API Cliente 360\",\"API.Questionario\",\"API Documento\",\"API Cartao de Credito\",\"API.EnriquecimentoDados\",\"ControleAcessoService\",\"API.Venda\",\"Lead.API\",\"API.Beneficiario\",\"ESB.CEP\",\"API MagPay\",\"API.Seguradora\",\"Identity Server\",\"API Mongeral Aegon\",\"API.CreditoConta\",\"API Previdencia\",\"API Bem Estar\",\"API Subscricao\",\"API.Sales\",\"API Notificador Evento 360\"],\"advancedSale\":\"0\",\"cpf\":\"69581424032\",\"OAuth2.ClientAllowedScopes\":[\"apicliente\",\"apiseguradora\"],\"tipoPessoa\":\"Fisica\",\"codProdutor\":\"27002628\",\"empresa\":\"33608308000173\",\"googleCalendarioId\":\"onnev2dt2sd391lde0icdojnk4@group.calendar.google.com\",\"amr\":[\"pwd\"]},\"expires_at\":1643980377}";

            ((IJavaScriptExecutor)driver).ExecuteScript($"window.sessionStorage.setItem('{sessionKey}', '{sessionValue}');");
        }
    }
}
