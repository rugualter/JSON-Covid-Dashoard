using JSONCovidDash.Models;

namespace JSONCovidDash.Proxies
{
    public interface ICovidApiService
    {

        /// <summary>
        /// Retornar a resposta do pedido em formato JSON
        /// </summary>
        /// <returns></returns>
        string GetListaConcelhos();

        /// <summary>
        /// Retornar a resposta dos pedidos de estatisticas
        /// </summary>
        /// <param name="criterios"></param>
        /// <returns></returns>
        string GetDadosEstatisticos(Criterios criterios);


    }
}
