using JSONCovidDash.Events;
using JSONCovidDash.Models;
using System;
using System.Collections.Generic;

namespace JSONCovidDash.Views
{
    public interface IDashboardCovidView : ICommonView, IViewSupportLog
    {
        /// <summary>
        /// Informar os subscritores que o utilizador clicou no botão search
        /// </summary>
        event AlteracaoCriterioPesquisaEventHandler AlteracaoCriterioPesquisa;

        /// <summary>
        /// Informar os subscritores que o utilizador desmarcou a opção portugal e ainda não existem concelhos carregados
        /// </summary>
        event AlteracaoCriterioPrincipalEventHandler AlteracaoCriterioPrincipal;

        /// <summary>
        /// Delegado que define a assinatura do método que retorna os dados para apresentar no interface
        /// </summary>
        /// <param name="dados"></param>
        delegate void SolicitarDadosEstatisticos(ref Dados dados);

        /// <summary>
        /// subscritor para injectar o método que fornece os dados
        /// </summary>
        event SolicitarDadosEstatisticos SolicitacaoDeDadosEstatisticos;

        /// <summary>
        /// Delegado que define a assinatura do método que retorna os dados para apresentar no interface
        /// </summary>
        /// <param name="dados"></param>
        delegate void SolicitarDadosConcelhiaEstatisticos(ref Dados dados);

        /// <summary>
        /// subscritor para injectar o método que fornece os dados
        /// </summary>
        event SolicitarDadosConcelhiaEstatisticos SolicitacaoDeDadosDaConcelhiaEstatisticos;

        /// <summary>
        /// Delegado que define a assinatura do método que retorna a lista de concelhos
        /// </summary>
        /// <param name="concelhos"></param>
        delegate void SolicitarListaConcelhos(ref List<string> concelhos);

        /// <summary>
        /// subscritor para injectar o método que fornece a lista de concelhos
        /// </summary>
        event SolicitarListaConcelhos ReceberListaConcelhos;

        /// <summary>
        /// Ativar a interface, método com os critérios necessários
        /// </summary>
        /// <param name="criterios"></param>
        void AtivarInterFace(Criterios criterios);

        /// <summary>
        /// Apresentar os critérios no interface construido
        /// </summary>
        /// <param name="criterios"></param>
        void ApresentarCriterios(Criterios criterios);

        /// <summary>
        /// Atualizar os indicadores no interface
        /// </summary>
        /// <param name="dados"></param>
        void AtualizarDashboardConcelhos(DadosConcelhoIndicador dados);

        /// <summary>
        /// Atualizar os indicadores no interface
        /// </summary>
        /// <param name="dados"></param>
        void AtualizarDashboard(Dados dados);

        /// <summary>
        /// Atualizar os indicadores no interface
        /// </summary>
        /// <param name="dados"></param>
        void AtualizarConcelhos(List<string> concelhos);

        /// <summary>
        /// Notificar os subscritores que o criterio de pesquisa foi alterado
        /// </summary>
        /// <param name="region"></param>
        /// <param name="date"></param>
        void NotificarAlteracaoCriterioPesquisa(string region, DateTime date);

        /// <summary>
        /// Notificar os subscritores que o criterio de pesquisa principal foi alterado
        /// </summary>
        void NotificarAlteracaoCriterioPrincipal();

    }
}
