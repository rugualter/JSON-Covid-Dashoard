using System;

namespace JSONCovidDash.Exceptions
{
    abstract class ExceptionBase : Exception
    {
        /// <summary>
        /// Guardar o código do erro
        /// </summary>
        public string ErrorCode { get; private set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public ExceptionBase(string errorCode, string message, Exception exception)
            : base(message, exception)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Retornar a mensagem completa
        /// </summary>
        /// <returns></returns>
        public string RetornarMensagemCompleta()
        {
            string fullMessage = string.Empty;
                
            if (this.InnerException != null)
            {
                fullMessage = this.RetornarMensagem(this.InnerException);
            }

            return string.Format("{0}-{1}{2}{3}", this.ErrorCode, this.Message, Environment.NewLine, fullMessage);
        }

        /// <summary>
        /// Retornar as mensagens armazenadas em cascata
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private string RetornarMensagem(Exception exception)
        {
            string message = string.Empty;

            if (exception != null)
            {
                message = string.Concat(message, Environment.NewLine, exception.Message, Environment.NewLine, 
                    this.RetornarMensagem(exception.InnerException));
            }

            return message;
        }
    }
}
