using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class PagamentoSteps
    {
        [Given(@"Simulacao private")]
        public void DadoSimulacaoPrivate()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Dado Simulacao")]
        public void DadoDadoSimulacao()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Selecionar opcao boleto")]
        public void QuandoSelecionarOpcaoBoleto()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Deve exibir selecao do dia")]
        public void EntaoDeveExibirSelecaoDoDia()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
