namespace JSONCovidDash.Models
{
    public interface IViewSupportLog
    {
        /// <summary>
        /// Delegado que define a assinatura do método que retorna os logs que serão apresentados no ecrã
        /// </summary>
        /// <returns></returns>
        delegate string SolicitarLogs();

        /// <summary>
        /// subscritor para injectar o método que fornece os logs que necessitam de ser apresentados
        /// </summary>
        event SolicitarLogs SolicitacaoDeLogs;

        /// <summary>
        /// Ativar a janela de logs
        /// </summary>
        void AtivarLogViewer();

        /// <summary>
        /// Notificar a escrita de logs
        /// </summary>
        void NotificarASolicitacaoDeLogs();
    }

}
