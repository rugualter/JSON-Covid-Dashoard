using System;

namespace JSONCovidDash.Events
{
    /// <summary>
    /// Evento utilizado para notificar as partes que o criterio principal foi desmarcado, 
    /// isso significa que a lista de concelhos deverá ser alterada
    /// </summary>
    /// <param name="e"></param>
    public delegate void AlteracaoCriterioPrincipalEventHandler(object sender, EventArgs e);
}
