namespace JSONCovidDash.Events
{
    /// <summary>
    /// Evento utilizado para notificar as partes que os criterios de pesquisa foram alterados
    /// </summary>
    /// <param name="e"></param>
    public delegate void AlteracaoCriterioPesquisaEventHandler(object sender, CriterioPesquisaEventArgs e);
}
