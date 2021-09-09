using JSONCovidDash.Events;
using JSONCovidDash.Models;
using System;
using System.Collections.Generic;

namespace JSONCovidDash.Views
{
    public class View : IDashboardCovidView
    {

        /// <summary>
        /// Referencia para a instancia da Model
        /// </summary>
        private Model Model { get; set; }

        /// <summary>
        /// Objecto que desenha o interface para apresentar os logs
        /// </summary>
        private ViewLog ViewLog { get; set; }

        /// <summary>
        /// Objecto que desenha todo o interface
        /// </summary>
        private Dashboard Dashboard { get; set; }

        /// <summary>
        /// Informar os subscritores que o utilizador clicou no botão search
        /// </summary>
        public event AlteracaoCriterioPesquisaEventHandler AlteracaoCriterioPesquisa;

        /// <summary>
        /// Informar os subscritores que o utilizador desmarcou a opção portugal e ainda não existem concelhos carregados
        /// </summary>
        public event AlteracaoCriterioPrincipalEventHandler AlteracaoCriterioPrincipal;

        /// <summary>
        /// Informar os subscritores que o utilizador clicou em fechar a aplicação
        /// </summary>
        public event EventHandler ClosedApplication;

        /// <summary>
        /// Delegado que define a assinatura do método que retorna os dados para apresentar no interface
        /// </summary>
        /// <param name="dados"></param>
        public delegate void SolicitarDadosEstatisticos(ref Dados dados);

        /// <summary>
        /// subscritor para injectar o método que fornece os dados
        /// </summary>
        public event IDashboardCovidView.SolicitarDadosEstatisticos SolicitacaoDeDadosEstatisticos;

        /// <summary>
        /// Delegado que define a assinatura do método que retorna os dados para apresentar no interface
        /// </summary>
        /// <param name="dados"></param>
        public delegate void SolicitarDadosConcelhiaEstatisticos(ref Dados dados);

        /// <summary>
        /// subscritor para injectar o método que fornece os dados
        /// </summary>
        public event IDashboardCovidView.SolicitarDadosConcelhiaEstatisticos SolicitacaoDeDadosDaConcelhiaEstatisticos;

        /// <summary>
        /// Delegado que define a assinatura do método que retorna a lista de concelhos
        /// </summary>
        /// <param name="concelhos"></param>
        public delegate void SolicitarListaConcelhos(ref List<string> concelhos);

        /// <summary>
        /// subscritor para injectar o método que fornece a lista de concelhos
        /// </summary>
        public event IDashboardCovidView.SolicitarListaConcelhos ReceberListaConcelhos;

        /// <summary>
        /// Delegado que define a assinatura do método que retorna os logs que serão apresentados no ecrã
        /// </summary>
        /// <returns></returns>
        public delegate string SolicitarLogs();

        /// <summary>
        /// subscritor para injectar o método que fornece os logs que necessitam de ser apresentados
        /// </summary>
        public event IViewSupportLog.SolicitarLogs SolicitacaoDeLogs;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="model"></param>
        internal View(Model model)
        {
            this.Model = model;

            //Iniciar View que mantêm a janela dependente que apresentar os logs
            this.ViewLog = new ViewLog(this.Dashboard);
        }

        /// <summary>
        /// Ativar a interface, método default
        /// </summary>
        public void AtivarInterFace()
        {
            this.AtivarInterFace(new Criterios());
        }

        /// <summary>
        /// Ativar a interface, método com os critérios necessários
        /// </summary>
        /// <param name="criterios"></param>
        public void AtivarInterFace(Criterios criterios)
        {
            //Construir o interface, definir critérios e apresentar ao utilizador o ecrã
            this.Dashboard = new Dashboard();
            this.Dashboard.View = this;
            this.ApresentarCriterios(criterios);
            this.Dashboard.ShowDialog();
        }

        /// <summary>
        /// Ativar a janela de logs
        /// </summary>
        public void AtivarLogViewer()
        {
            this.ViewLog.ConstruirLogViewer();
        }

        /// <summary>
        /// Apresentar os critérios no interface construido
        /// </summary>
        /// <param name="criterios"></param>
        public void ApresentarCriterios(Criterios criterios)
        {
            // Definir os criterios no form
            this.Dashboard.AtribuirCriterios(criterios);
        }

        /// <summary>
        /// Atualizar os indicadores no interface
        /// </summary>
        /// <param name="dados"></param>
        public void AtualizarDashboardConcelhos(DadosConcelhoIndicador dados)
        {
            this.Dashboard.AtualizarDadosConcelhos(dados);
        }

        /// <summary>
        /// Atualizar os indicadores no interface
        /// </summary>
        /// <param name="dados"></param>
        public void AtualizarDashboard(Dados dados)
        {
            this.Dashboard.AtualizarDados(dados);
        }

        /// <summary>
        /// Atualizar os indicadores no interface
        /// </summary>
        /// <param name="dados"></param>
        public void AtualizarConcelhos(List<string> concelhos)
        {
            this.Dashboard.AtualizarConcelhos(concelhos);
        }

        /// <summary>
        /// Notificar os subscritores que o criterio de pesquisa foi alterado
        /// </summary>
        /// <param name="region"></param>
        /// <param name="date"></param>
        public void NotificarAlteracaoCriterioPesquisa(string region, DateTime date)
        {
            if (this.AlteracaoCriterioPesquisa != null)
                this.AlteracaoCriterioPesquisa(this, new CriterioPesquisaEventArgs(region, date));
        }

        /// <summary>
        /// Notificar os subscritores que o criterio de pesquisa principal foi alterado
        /// </summary>
        public void NotificarAlteracaoCriterioPrincipal()
        {
            if (this.AlteracaoCriterioPrincipal != null)
                this.AlteracaoCriterioPrincipal(this, new EventArgs());
        }

        /// <summary>
        /// Notificar o fecho da aplicação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NotificarOFechoDaAplicacao(object sender, EventArgs e)
        {
            if (this.ClosedApplication != null)
                this.ClosedApplication(sender, e);
        }

        /// <summary>
        /// Notificar a escrita de logs
        /// </summary>
        public void NotificarASolicitacaoDeLogs()
        {
            this.ViewLog.EscreverLog(this.SolicitacaoDeLogs());
        }

        /// <summary>
        /// Encerrar a aplicação
        /// </summary>
        public void Encerrar()
        {
            this.Dashboard.Encerrar();
        }
    }
}
