using JSONCovidDash.Exceptions;
using System;

namespace JSONCovidDash.Models
{
    
    public enum LogEntryCategory { Informacao, Aviso, Erro, Critico }

    public class LogEntry : ILogEntry
    {
        public LogEntryCategory Category { get; private set; }
        
        public DateTime DateTime { get; private set; }

        public string Message { get; private set; }

        public string FullMessage { get; private set; }

        /// <summary>
        /// Construtor Simples
        /// </summary>
        /// <param name="category"></param>
        /// <param name="message"></param>
        public LogEntry(LogEntryCategory category, string message) : this(category, message, null)
        {

        }

        /// <summary>
        /// Construtor Completo
        /// </summary>
        /// <param name="category"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public LogEntry(LogEntryCategory category, string message, Exception exception)
        {
            this.DateTime = DateTime.Now;
            this.Category = category;
            this.Message = message;

            //Obter a mensagem completa que se encontra nas excepções
            if (exception != null)
            {
                string exceptionMessage = string.Empty;

                if (exception is ExceptionBase)
                {
                    exceptionMessage = ((ExceptionBase)exception).RetornarMensagemCompleta();
                }
                else
                {
                    exceptionMessage = exception.Message;
                }

                this.FullMessage = string.Format("{0}{1}{2}", this.Message, Environment.NewLine, exceptionMessage);
            }
        }

        public string RetornaMensagemSimples()
        {
            return this.Message;
        }

        public string RetornaMensagemCompleta()
        {
            return string.Format("{0}|{1}|{2}{3}{4}", this.DateTime.ToString(), this.Category.ToString(), this.Message, Environment.NewLine,
                    this.FullMessage);
        }

    }
}
