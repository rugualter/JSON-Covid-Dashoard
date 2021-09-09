using JSONCovidDash.Views;
using JSONCovidDash.Exceptions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace JSONCovidDash.Models
{
    public class Model
    {
        /// <summary>
        /// Referencia interna para a view
        /// </summary>
        private IDashboardCovidView View { get; set; }

        /// <summary>
        /// Manter a instancia do model dos logs
        /// </summary>
        public ILogModel Log { get; set; }

        /// <summary>
        /// Mantém o ultimo resultado da pesquisa apresentado no interface
        /// </summary>
        public Dados Dados { get; private set; }

        /// <summary>
        /// Mantém a lista de concelhos
        /// </summary>
        public List<string> Concelhos { get; private set; }

        /// <summary>
        /// Mantém os criterios utilizados na última pesquisa
        /// </summary>
        public Criterios Criterios { get; private set; }

        /// <summary>
        /// Método delegado utilizado para Informar o seu subscritor que os dados estatisticos 
        /// </summary>
        /// <param name="dados"></param>
        public delegate void DadosEstatisticosAlterados(Dados dados);

        /// <summary>
        /// Subscritor para ser injetado os dados estatisticos
        /// </summary>
        public event DadosEstatisticosAlterados DadosEstatisticosRecebidos;

        /// <summary>
        /// Método delegado utilizado para Informar o seu subscritor que os dados estatisticos do concelho
        /// </summary>
        /// <param name="dados"></param>
        public delegate void DadosEstatisticosConcelhiaAlterados(DadosConcelhoIndicador dados);

        /// <summary>
        /// Subscritor para ser injetado os dados estatisticos
        /// </summary>
        public event DadosEstatisticosConcelhiaAlterados DadosEstatisticosConcelhiaRecebidos;

        /// <summary>
        /// Método delegado utilizado para Informar o seu subscritor da lista de concelhos
        /// </summary>
        /// <param name="concelhos"></param>
        public delegate void ListaConcelhosAlterada(List<string> concelhos);

        /// <summary>
        /// Subscritor para ser injetado a lista de concelhos
        /// </summary>
        public event ListaConcelhosAlterada ListaConcelhosRecebidos;

        /// <summary>
        /// Construtor por Defeito
        /// </summary>
        /// <param name="view"></param>
        public Model(IDashboardCovidView view)
        {
            this.View = view;
            this.ResetCriterios();
            this.Dados = new Dados();
            this.Concelhos = new List<string>();
        }

        /// <summary>
        /// Analisar a lista de concelhos e garantir que pode ser usada
        /// </summary>
        /// <param name="concelhos"></param>
        public void ProcessarListaConcelhos(List<string> concelhos)
        {
            try
            {
                if (concelhos == null)
                    throw new ArgumentNullException("concelhos");

                if (concelhos.Count == 0)
                    throw new ArgumentOutOfRangeException("concelhos não pode ser vazia");

                //Adicionar a lista para manter uma copia interna
                this.Concelhos.AddRange(concelhos);

                //Notificar que a lista foi atualizada
                this.NotificarListaConcelhosRecebida(this.Concelhos);
            }
            catch (Exception ex)
            {
                ErroConversaoJSONException exception =
                    new ErroConversaoJSONException("Ocorreu um erro na conversão do ficheiro Json no objeto Dados", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Extrair os dados necessários para se construir os indicadores
        /// </summary>
        /// <param name="dados"></param>
        public void ProcessarDados(Dictionary<string, Dictionary<string, string>> dados)
        {
            try
            {
                if (dados == null)
                {
                    throw new ArgumentNullException("dados");
                }

                //Obter a indicadação das datas extraidas, para obtermos as chaves usadas para filtrar os dados nos próximos passos
                Dictionary<string, string> dataDados = ExtrairElementosDaExtrutura(dados, "data_dados");

                //Obter a lista de chaves - a chave é a contagem do número de dias desde que a pandemeia começou
                //Mantém a ordem para facilitar as etapas seguintes
                string chave = string.Empty;
                string chaveAnterior = string.Empty;
                List<string> chaves = dataDados.Distinct<KeyValuePair<string, string>>().Select(x => x.Key).ToList();
                chaves = chaves.OrderBy(x => x).ToList();
                this.ExtrairAsDuasUltimasChaves(chaves, ref chave, ref chaveAnterior);

                //Iniciar o repositorio de dados do indicador
                this.Dados = new Dados();

                //Obter da data da ultima utilização dos dados recolhidos
                string ultimaAtualizacao = this.ExtrairChaveDaEstrutura(dados, "data", chave);
                this.Dados.UltimaAtualizacao = Convert.ToDateTime(ultimaAtualizacao);

                //Obter dados para os indicadores
                this.Dados.Norte = this.ObterIndicadorRegiao(dados, "arsnorte", chave, chaveAnterior);
                this.Dados.Centro = this.ObterIndicadorRegiao(dados, "arscentro", chave, chaveAnterior);
                this.Dados.ValeTejo = this.ObterIndicadorRegiao(dados, "arslvt", chave, chaveAnterior);
                this.Dados.Alentejo = this.ObterIndicadorRegiao(dados, "arsalentejo", chave, chaveAnterior);
                this.Dados.Algarve = this.ObterIndicadorRegiao(dados, "arsalgarve", chave, chaveAnterior);
                this.Dados.Acores = this.ObterIndicadorRegiao(dados, "acores", chave, chaveAnterior);
                this.Dados.Madeira = this.ObterIndicadorRegiao(dados, "madeira", chave, chaveAnterior);

                this.Dados.Confirmados = this.ObterIndicador(dados, "confirmados", chave, chaveAnterior);
                this.Dados.Recuperados = this.ObterIndicador(dados, "recuperados", chave, chaveAnterior);
                this.Dados.Ativos = this.ObterIndicador(dados, "ativos", chave, chaveAnterior);
                this.Dados.Obitos = this.ObterIndicador(dados, "obitos", chave, chaveAnterior);
                this.Dados.Internados = this.ObterIndicador(dados, "internados", chave, chaveAnterior);
                this.Dados.InternadosUCI = this.ObterIndicador(dados, "internados_uci", chave, chaveAnterior);
                this.Dados.InternadosEnfermaria = this.ObterIndicador(dados, "internados_enfermaria", chave, chaveAnterior);
                this.Dados.Vigilancia = this.ObterIndicador(dados, "vigilancia", chave, chaveAnterior);
                this.Dados.IncidenciaNacional = this.ObterIndicador(dados, "incidencia_nacional", chave, chaveAnterior);
                this.Dados.RTNacional = this.ObterIndicador(dados, "rt_nacional", chave, chaveAnterior);

                //Notificar que os dados estão processados
                this.NotificarDadosEstatisticosRecebidos(this.Dados);

            }
            catch (Exception ex)
            {
                ErroConversaoJSONException exception =
                    new ErroConversaoJSONException("Ocorreu um erro na conversão do ficheiro Json no objeto Dados", ex);
                
                throw exception;
            }
        }

        /// <summary>
        /// Extrair os dados necessários para se construir os indicadores
        /// </summary>
        /// <param name="dados"></param>
        public void ProcessarDados(List<Dictionary<string, string>> dados)
        {
            try
            {
                if (dados == null)
                {
                    throw new ArgumentNullException("dados");
                }

                //Seleciona o dicionario que será selecionado
                Dictionary<string, string> dicionario = null;

                //Como os dados chegam ordenados por ordem crescente irei buscar o bloco de dados imediatamente antes da data do criterio
                foreach (Dictionary<string, string> pairs in dados)
                {
                    string date = string.Empty;
                    if (pairs.TryGetValue("data", out date) == false)
                    {
                        throw new ErroConversaoJSONException(string.Format("O resposta em JSON não fornece a chave {0}.", "data"));
                    }

                    //Seleciona o ultimo elemento antes da data indicada no criterio
                    if (dicionario == null || (Convert.ToDateTime(date) <= this.Criterios.Data && Convert.ToDateTime(dicionario["data"]) <= Convert.ToDateTime(date)))
                    {
                        dicionario = pairs;
                    }
                }

                //Verificar se ficou algum dicionario de dados selecionado
                if (dicionario != null)
                {
                    this.Dados.DadosConcelhos = new DadosConcelhoIndicador();

                    this.Dados.DadosConcelhos.NCasos = Convert.ToInt32(dicionario["casos_14dias"]);
                    this.Dados.DadosConcelhos.NomeConcelho = dicionario["concelho"].ToString();
                    this.Dados.DadosConcelhos.Incidencia =  Convert.ToInt32(dicionario["incidencia"]);
                    this.Dados.DadosConcelhos.Categoria = dicionario["incidencia_categoria"].ToString();
                    this.Dados.DadosConcelhos.Risco =  dicionario["incidencia_risco"].ToString();
                    this.Dados.DadosConcelhos.UltimaAtualizacao = Convert.ToDateTime(dicionario["data"]);

                }

                //Notificar que os dados estão processados
                this.NotificarDadosEstatisticosDoConcelhoRecebidos(this.Dados.DadosConcelhos);
            }
            catch (Exception ex)
            {
                ErroConversaoJSONException exception =
                    new ErroConversaoJSONException("Ocorreu um erro na conversão do ficheiro Json no objeto Dados", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Envia os dados para o subscritor do metodo delegado
        /// </summary>
        /// <param name="dados"></param>
        public void SolicitarDadosEstatisticos(ref Dados dados)
        {
            if (dados == null)
                dados = new Dados();

            dados = this.Dados.Clone();
        }

        /// <summary>
        /// Enviar lista de concelhos para o subscritor
        /// </summary>
        /// <param name="dados"></param>
        public void SolicitarConcelhos(ref List<string> concelhos)
        {
            if (concelhos == null)
                concelhos = new List<string>();

            foreach (string concelho in this.Concelhos)
            {
                concelhos.Add(concelho);
            }
        }

        /// <summary>
        /// Envia os dados para o subscritor do metodo delegado
        /// </summary>
        /// <param name="dados"></param>
        public void SolicitarDadosEstatisticos(ref DadosConcelhoIndicador dados)
        {
            dados = this.Dados.DadosConcelhos.Clone();
        }

        /// <summary>
        /// Escrever um mensagem de log a reportar algum assunto
        /// </summary>
        /// <param name="category"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void AddLog(LogEntryCategory category, string message, Exception exception = null)
        {
            this.Log.AddLogEntry(category, message, exception);
        }

        /// <summary>
        /// Coloca o estado por defeito dos criterios
        /// </summary>
        public void ResetCriterios()
        {
            this.Criterios = new Criterios();
        }

        /// <summary>
        /// Notificar que os dados estão prontos, se existirem condições
        /// </summary>
        /// <param name="dados"></param>
        private void NotificarDadosEstatisticosRecebidos(Dados dados)
        {
            if (this.DadosEstatisticosRecebidos != null)
                this.DadosEstatisticosRecebidos(dados);
        }

        /// <summary>
        /// Notificar que os dados do concelho estão prontos, se existirem condições
        /// </summary>
        /// <param name="dados"></param>
        private void NotificarDadosEstatisticosDoConcelhoRecebidos(DadosConcelhoIndicador dados)
        {
            if (this.DadosEstatisticosConcelhiaRecebidos != null)
                this.DadosEstatisticosConcelhiaRecebidos(dados);
        }

        /// <summary>
        /// Notificar que os dados estão prontos, se existirem condições
        /// </summary>
        /// <param name="concelhos"></param>
        private void NotificarListaConcelhosRecebida(List<string> concelhos)
        {
            if (this.ListaConcelhosRecebidos != null)
                this.ListaConcelhosRecebidos(concelhos);
        }

        /// <summary>
        /// Retornar as duas ultimas chaves disponiveis na lista
        /// </summary>
        /// <param name="chaves"></param>
        /// <param name="chave"></param>
        /// <param name="chaveAnterior"></param>
        private void ExtrairAsDuasUltimasChaves(List<string> chaves, ref string chave, ref string chaveAnterior)
        {
            foreach (string item in chaves)
            {
                if (string.IsNullOrEmpty(chave))
                {
                    chave = item;
                }
                else
                {
                    chaveAnterior = chave;
                    chave = item;
                }
            }
        }

        /// <summary>
        /// Extrair os valores das chaves retornadas
        /// </summary>
        /// <param name="dados"></param>
        /// <param name="element"></param>
        /// <param name="chave"></param>
        /// <param name="valor"></param>
        private string ExtrairChaveDaEstrutura(Dictionary<string, Dictionary<string, string>> dados, string element, string chave)
        {
            string valor = string.Empty;

            //Obter o range de dados que serão filtrados
            Dictionary<string, string> tempDados = this.ExtrairElementosDaExtrutura(dados, element);

            //Obter os valor da chave procurada
            if (tempDados.TryGetValue(chave, out valor) == false)
            {
                throw new ErroConversaoJSONException(string.Format("O resposta em JSON não fornece a chave {0}.", element));
            }

            return valor;
        }

        /// <summary>
        /// Retornar a lista de elementos que serão extraidos da extrutura
        /// </summary>
        /// <param name="dados"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        private Dictionary<string, string> ExtrairElementosDaExtrutura(Dictionary<string, Dictionary<string, string>> dados, string element)
        {

            Dictionary<string, string> tempDados = null;

            if (dados.TryGetValue(element, out tempDados) == false)
            {
                throw new ErroConversaoJSONException(string.Format("O resposta em JSON não fornece a chave {0}.", element));
            }

            return tempDados;
        }

        /// <summary>
        /// Calcular o indicador por regiao
        /// </summary>
        /// <param name="dados"></param>
        /// <param name="regiao"></param>
        /// <param name="chave"></param>
        /// <param name="chaveAnterior"></param>
        /// <returns></returns>
        private IndicadorRegiao ObterIndicadorRegiao(Dictionary<string, Dictionary<string, string>> dados, string regiao, string chave,
                string chaveAnterior)
        {
            IndicadorRegiao indicador = new IndicadorRegiao();
            
            indicador.Confirmados = this.ObterIndicador(dados, "confirmados_" + regiao, chave, chaveAnterior);
            indicador.Obitos = this.ObterIndicador(dados, "obitos_" + regiao, chave, chaveAnterior);

            return indicador;
        }

        /// <summary>
        /// Calcular os valores do indicador selecionado
        /// </summary>
        /// <param name="dados"></param>
        /// <param name="nomeIndicador"></param>
        /// <param name="chave"></param>
        /// <param name="chaveAnterior"></param>
        /// <returns></returns>
        private DadosIndicador ObterIndicador(Dictionary<string, Dictionary<string, string>> dados, string nomeIndicador, string chave, 
                string chaveAnterior)
        {
            string indicador = this.ExtrairChaveDaEstrutura(dados, nomeIndicador, chave);
            string indicadorAnterior = this.ExtrairChaveDaEstrutura(dados, nomeIndicador, chaveAnterior);

            decimal temp = 0;
            decimal tempAnterior = 0;

            if (string.IsNullOrEmpty(indicador) == false)
            {
                temp = Convert.ToDecimal(indicador.Replace(".", ","));
            }

            if (string.IsNullOrEmpty(indicadorAnterior) == false)
            {
                tempAnterior = Convert.ToDecimal(indicadorAnterior.Replace(".", ","));
            }

            return new DadosIndicador(temp, temp - tempAnterior);
        }
    }
}
