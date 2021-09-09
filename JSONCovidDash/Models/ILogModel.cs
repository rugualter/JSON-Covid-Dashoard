using System;

namespace JSONCovidDash.Models
{
    public interface ILogModel
    {
        public event LogModel.NotificarAlteracaoLog LogAlterado;

        /// <summary>
        /// Adiciona uma mensagem especifica de Log
        /// </summary>
        /// <param name="category"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void AddLogEntry(LogEntryCategory category, string message, Exception exception = null);

        /// <summary>
        /// Retornar os logs simples em formato de texto
        /// </summary>
        /// <returns></returns>
        string SolicitarLogsSimples();

        /// <summary>
        /// Retornar os logs completos em formato de texto
        /// </summary>
        /// <returns></returns>
        string SolitarLogsCompletos();
    }
}