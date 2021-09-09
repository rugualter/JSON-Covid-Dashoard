using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using JSONCovidDash.Exceptions;
using JSONCovidDash.Models;

namespace JSONCovidDash.Proxies
{
    public class CovidApiClientProxy : ICovidApiService
    {

        /// <summary>
        /// Mantém a parte comum do endereço url para a API
        /// </summary>
        private string URL { get; set; }

        /// <summary>
        /// Mantém a instancia para fazer os pedidos HTTP
        /// </summary>
        private static HttpClient Client { get; set; }

        /// <summary>
        /// Construtor do proxy
        /// </summary>
        public CovidApiClientProxy()
        {
            this.URL = Properties.Settings.Default.CovidAPIHostAddress;

            if (string.IsNullOrEmpty(this.URL))
            {
                //Fazer excepção
                throw new ErroConfiguracaoEmFaltaException("URL");
            }
        }

        /// <summary>
        /// Retornar a resposta do pedido em formato JSON
        /// </summary>
        /// <returns></returns>
        public string GetListaConcelhos()
        {
            string comandoURL = string.Concat(this.URL, "Requests/get_county_list");
            return FazPedido(comandoURL);//.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retornar a resposta dos pedidos de estatisticas
        /// </summary>
        /// <param name="criterios"></param>
        /// <returns></returns>
        public string GetDadosEstatisticos(Criterios criterios)
        {
            if (criterios == null)
            {
                throw new ArgumentNullException("Criterios é nulo");
            }

            string resposta = string.Empty;

            //Obter os dados de acordo com o valor atribuido no criterio
            if (string.IsNullOrEmpty(criterios.Regiao))
            {
                resposta = this.GetDadosEstatisticosGlobais(criterios.Data);
            }
            else
            {
                resposta = this.GetDadosEstatisticosConcelho(criterios.Data, criterios.Regiao);
            }

            return resposta;
        }

        /// <summary>
        /// Fazer o pedido à API
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        //private static async Task<string> FazPedido(string url)
        private static string FazPedido(string url)
        {
            string resposta = String.Empty;

            try
            {
                //Validar Argumentos
                if (string.IsNullOrEmpty(url))
                    throw new ArgumentNullException("url");

                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var client1 = new WebClient();
                client1.Proxy = new WebProxy("proxy_url");
                client1.Proxy.Credentials = new NetworkCredential("proxy_user", "proxy_pass");
                resposta = client1.DownloadString(url);

                if (string.IsNullOrEmpty(resposta))
                    throw new HttpRequestException(Properties.Resources.ApiEstaInacessivel);

                /*
                 * Maneira normal de se fazer o pedido
                //Construir cliente HTTP, para fazer os pedidos
                if (Client == null)
                    Client = new HttpClient();

                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                Client.BaseAddress = new Uri(url);
                
                //Definir o endereço do pedido
                //Executar o pedido e resgatar a resposta, em caso de erro aborta com uma excepção
                Task<HttpResponseMessage> responseTask = Client.GetAsync(url);
                responseTask.Wait();
                responseTask.Result.EnsureSuccessStatusCode();
                if (responseTask.Result.IsSuccessStatusCode)
                {
                    Task<string> taskString = responseTask.Result.Content.ReadAsStringAsync();
                    resposta = taskString.Result;
                }
                else 
                    */

            }
            catch (Exception ex)
            {
                resposta = string.Empty;
                throw new ErroPedidoApiAbortadoException(ex.Message);
            }
            finally
            {
                Client = null;
            }
            
            return resposta;
        }

        /// <summary>
        /// Retornar os dados de Portugal para um dia especifico
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private string GetDadosEstatisticosGlobais(DateTime date)
        {
            if (date < new DateTime(2020, 1, 1) || date > new DateTime(2022, 12, 31))
            {
                throw new ArgumentOutOfRangeException("date");
            }
            
            DateTime beginDate = date.AddDays(-2);
            DateTime endDate = date;
            
            string urlPart = string.Format("Requests/get_entry/{0}_until_{1}", beginDate.ToString("dd-MM-yyyy"), endDate.ToString("dd-MM-yyyy"));
            string comandoURL = string.Concat(this.URL, urlPart);

            return FazPedido(comandoURL);//.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retornar os dados do concelho especifico por data e concelho
        /// </summary>
        /// <param name="date"></param>
        /// <param name="concelho"></param>
        /// <returns></returns>
        private string GetDadosEstatisticosConcelho(DateTime date, string concelho)
        {
            if (string.IsNullOrEmpty(concelho))
            {
                throw new ArgumentNullException("concelho");
            }

            if (date < new DateTime(2020, 1, 1) || date > new DateTime(2022, 12, 31))
            {
                throw new ArgumentOutOfRangeException("date");
            }

            //Os criterios de data são ignorados pela API, uma vez que nem todos os concelhos reportam dados
            DateTime beginDate = new DateTime(2020, 1, 1); 
            DateTime endDate = date;
            string comandPart = string.Format("Requests/get_entry_county/{0}_until_{1}_{2}", beginDate.ToString("dd-MM-yyyy"),
                    endDate.ToString("dd-MM-yyyy"), concelho);

            string comandoURL = string.Concat(this.URL, comandPart);
            return FazPedido(comandoURL);//.GetAwaiter().GetResult();
        }

    }
}
