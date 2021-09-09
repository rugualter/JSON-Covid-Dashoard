using System;


namespace JSONCovidDash.Exceptions
{
    /// <summary>
    /// Este é deve ser utilizado para marcar os erros que decorreção da falta de configurações da aplicação
    /// </summary>
    class ErroConfiguracaoEmFaltaException : ExceptionBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="nomeConfiguracao"></param>
        public ErroConfiguracaoEmFaltaException(string nomeConfiguracao)
            : base("E009", string.Format(Properties.Resources.ConfiguracaoEmFalta, nomeConfiguracao), null)
        {

        }
    }
}
