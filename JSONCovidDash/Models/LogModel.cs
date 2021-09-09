using System;
using System.Collections.Generic;
using System.Text;

namespace JSONCovidDash.Models
{
    public class LogModel : ILogModel
    {
        /// <summary>
        /// Método delegado utilizado para Informar o seu subscritor que os logs foram alterados
        /// </summary>
        public delegate void NotificarAlteracaoLog();

        /// <summary>
        /// Subscritor para ser injetado com os novos dados
        /// </summary>
        public event NotificarAlteracaoLog LogAlterado;

        /// <summary>
        /// Manter a lista de logs
        /// </summary>
        private List<ILogEntry> Logs { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public LogModel()
        {
            this.Logs = new List<ILogEntry>();
        }

        /// <summary>
        /// Retornar os logs simples em formato de texto
        /// </summary>
        /// <returns></returns>
        public string SolicitarLogsSimples()
        {
            return this.RetornarLogs(true);
        }

        /// <summary>
        /// Retornar os logs completos em formato de texto
        /// </summary>
        /// <returns></returns>
        public string SolitarLogsCompletos()
        {
            return this.RetornarLogs(false);
        }

        /// <summary>
        /// Adiciona uma mensagem especifica de Log
        /// </summary>
        /// <param name="category"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void AddLogEntry(LogEntryCategory category, string message, Exception exception = null)
        {
            //Adicionar uma nova entrada de log
            ILogEntry logEntry = new LogEntry(category, message, exception);
            this.Logs.Add(logEntry);

            //Notificar a alteração dos logs
            this.NotificarLogAlterado();
        }

        /// <summary>
        /// Avisar o subscritor que a lista de logs foi alterada
        /// </summary>
        private void NotificarLogAlterado()
        {
            if (this.LogAlterado != null)
                this.LogAlterado();
        }

        /// <summary>
        /// Retornar a string com o log completo
        /// </summary>
        /// <param name="simples"></param>
        /// <returns></returns>
        private string RetornarLogs(bool simples)
        {
            StringBuilder log = new StringBuilder();

            if (this.Logs != null && this.Logs.Count > 0)
            {
                foreach (ILogEntry logEntry in this.Logs)
                {
                    //Adicionar cada log numa nova linha
                    log.AppendLine(simples ? logEntry.RetornaMensagemSimples() : logEntry.RetornaMensagemCompleta());
                }
            }

            return log.ToString();
        }
    }
}
