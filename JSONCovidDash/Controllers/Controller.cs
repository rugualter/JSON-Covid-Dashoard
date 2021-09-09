using System;
using System.Collections.Generic;

using JSONCovidDash.Events;
using JSONCovidDash.Models;
using JSONCovidDash.Proxies;
using JSONCovidDash.Views;
using JSONCovidDash.Exceptions;
using JSONCovidDash.Wrapper;


namespace JSONCovidDash.Controllers
{
    public class Controller
    {
        /// <summary>
        /// Mantém o objeto da Model
        /// </summary>
        private Model Model { get; set; }

        /// <summary>
        /// Mantém o objeto do LogModel
        /// </summary>
        private LogModel LogModel { get; set; }

        /// <summary>
        /// Mantém o objeto da Model
        /// </summary>
        private IDashboardCovidView View { get; set; }

        /// <summary>
        /// Mantém o objeto para efetuar as chamadas a dados externos à aplicação
        /// </summary>
        private ICovidApiService CovidApiClientProxy { get; set; }

        /// <summary>
        /// Variable interna para controlar a saida da aplicação
        /// </summary>
        private bool Sair { get; set; }

        /// <summary>
        /// Subscrever todos os elementos necessários no projeto
        /// </summary>
        public Controller()
        {
            this.Sair = false;
            this.View = new View(this.Model);
            this.Model = new Model(this.View);

            //Instanciar a model para manter os logs
            this.LogModel = new LogModel();
            this.Model.Log = this.LogModel;

            //Proxy para obter dados
            this.CovidApiClientProxy = new CovidApiClientProxy();
            
            //Subscrever o evento de fecho da aplicação
            this.View.ClosedApplication += ViewClosedApplication;

            //Subscrever o evento que informa o controller que os criterios de pesquisa foram alterados pelo utilizador
            this.View.AlteracaoCriterioPesquisa += this.UtilizadorAlterouCriterioPesquisa;
            this.View.AlteracaoCriterioPrincipal += this.UtilizadorDesmarcouAOpcaoPortugal;

            //Enviar para a view os dados disponiveis na Model
            this.View.SolicitacaoDeDadosEstatisticos += this.Model.SolicitarDadosEstatisticos;
            this.View.SolicitacaoDeDadosDaConcelhiaEstatisticos += this.Model.SolicitarDadosEstatisticos;
            this.View.ReceberListaConcelhos += this.Model.SolicitarConcelhos;

            //Notificar View da Alteração de Dados na Model
            this.Model.DadosEstatisticosConcelhiaRecebidos += this.View.AtualizarDashboardConcelhos;
            this.Model.DadosEstatisticosRecebidos += this.View.AtualizarDashboard;
            this.Model.ListaConcelhosRecebidos += this.View.AtualizarConcelhos;

            //Subscrever eventos e delegados relacionados com a janela de log
            this.SubscreberEventosLog(false);

        }

        /// <summary>
        /// Arrancar a aplicação e ativar o interface com os critérios por omissão
        /// </summary>
        public void IniciarAplicacao()
        {
            do
            {
                try
                {
                    this.View.AtivarInterFace(this.Model.Criterios);
                }
                catch (Exception ex)
                {
                    this.View.AtivarLogViewer();
                    this.ReportarLog(LogEntryCategory.Erro, ex.Message, ex);

                    //Faz Reset aos critérios para iniciar 
                    this.Model.ResetCriterios();
                }
            } while (!this.Sair);
        }

        /// <summary>
        /// Responde ao pedido da alteração de um dos filtros principais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void UtilizadorDesmarcouAOpcaoPortugal(object sender, EventArgs args)
        {
            try
            {
                if (this.Model == null)
                {
                    throw new NullReferenceException("O Model é nulo");
                }

                if (this.Model.Criterios == null)
                {
                    throw new NullReferenceException("O Model.Criterios é nulo");
                }

                //Chamar o proxy que trata da chamada a API
                string json = this.CovidApiClientProxy.GetListaConcelhos();

                //Converter os dados relativos aos concelhos
                List<string> concelhos = JSONNetWrapper.ConverterListaConcelhos(json);

                //Processar a lista de concelhos
                this.Model.ProcessarListaConcelhos(concelhos);
            }
            catch (Exception ex)
            {
                ErroPedidoApiAbortadoException exception =
                    new ErroPedidoApiAbortadoException("Ocorreu um erro na obtenção de dados externos", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Responder ao pedido de alteração de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void UtilizadorAlterouCriterioPesquisa(object sender, CriterioPesquisaEventArgs  args)
        {
            try
            {
                if (args == null)
                {
                    throw new ArgumentNullException("O CriterioPesquisaEventArgs é nulo");
                }

                if (this.Model == null)
                {
                    throw new NullReferenceException("O Model é nulo");
                }

                if (this.Model.Criterios == null)
                {
                    throw new NullReferenceException("O Model.Criterios é nulo");
                }

                //Prepara a pesquisa a nível de NACIONAL
                this.Model.Criterios.Data = args.Date;
                this.Model.Criterios.Regiao = string.Empty;

                //Chamar o proxy que trata da chamada a API
                string json = this.CovidApiClientProxy.GetDadosEstatisticos(this.Model.Criterios);

                //Converter os dados - Json.NET
                Dictionary<string, Dictionary<string, string>> dados = JSONNetWrapper.ConvertDadosEstatisticos<Dictionary<string, Dictionary<string, string>>>(json);

                //processar dados convertidos
                this.Model.ProcessarDados(dados);

                //Prepara a pesquisa a nível de Concelhia
                if (string.IsNullOrEmpty(args.Region) == false)
                {
                    this.Model.Criterios.Regiao = args.Region;

                    //Chamar o proxy que trata da chamada a API
                    string jsonConcelho = this.CovidApiClientProxy.GetDadosEstatisticos(this.Model.Criterios);

                    List<Dictionary<string, string>> dadosConcelho = JSONNetWrapper.ConvertDadosEstatisticos<List<Dictionary<string, string>>>(jsonConcelho);

                    this.Model.ProcessarDados(dadosConcelho);
                }
                
            }
            catch (Exception ex)
            {
                ErroPedidoApiAbortadoException exception =
                    new ErroPedidoApiAbortadoException("Ocorreu um erro na obtenção de dados externos", ex);

                throw exception;
            }
            
        }

        /// <summary>
        /// Remover referencias dos objetos ao fechar a aplicação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewClosedApplication(object sender, EventArgs e)
        {
            this.CovidApiClientProxy = null;

            this.Sair = true;
            this.View.Encerrar();
        }

        /// <summary>
        /// Subscrever eventos relacionados com os logs
        /// </summary>
        /// <param name="simples"></param>
        private void SubscreberEventosLog(bool simples)
        {
            //Remover todas as assinaturas que possam existir
            this.View.SolicitacaoDeLogs -= this.LogModel.SolicitarLogsSimples;
            this.View.SolicitacaoDeLogs -= this.LogModel.SolitarLogsCompletos;
            this.LogModel.LogAlterado -= this.View.NotificarASolicitacaoDeLogs;

            //Enviar os logs que dem de ser apresentados
            if (simples)
                this.View.SolicitacaoDeLogs += this.LogModel.SolicitarLogsSimples;
            else
                this.View.SolicitacaoDeLogs += this.LogModel.SolitarLogsCompletos;

            //Notificar a view que a lista de logs foi alterada
            this.LogModel.LogAlterado += this.View.NotificarASolicitacaoDeLogs;
        }

        /// <summary>
        /// Reportar uma nova entrada de Log
        /// </summary>
        /// <param name="category"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        private void ReportarLog(LogEntryCategory category, string message, Exception exception = null)
        {
            this.View.AtivarLogViewer();
            this.Model.AddLog(category, message, exception);
        }
    }
}
