using System;


namespace JSONCovidDash.Exceptions
{
    /// <summary>
    /// Este é deve ser utilizado para marcar os erros que decorreção da comunicação com a Web API que alimentara a aplicação
    /// </summary>
    class ErroPedidoApiAbortadoException : ExceptionBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="mensagem"></param>
        public ErroPedidoApiAbortadoException(string mensagem, Exception exception = null)
            : base("E008", string.Format(Properties.Resources.FalhouComunicacaoWebAPI, mensagem), exception)
        {

        }
    }
}

