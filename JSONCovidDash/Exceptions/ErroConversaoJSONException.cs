using System;


namespace JSONCovidDash.Exceptions
{
    /// <summary>
    /// Este é deve ser utilizado para marcar os erros que decorreção da falta de configurações da aplicação
    /// </summary>
    class ErroConversaoJSONException : ExceptionBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="nomeConfiguracao"></param>
        public ErroConversaoJSONException(string mensagem, Exception exception = null)
            : base("E007", string.Format(Properties.Resources.FalhouConversaoJSON, mensagem), exception)
        {

        }
    }
}

