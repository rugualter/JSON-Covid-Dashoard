using System;

namespace JSONCovidDash.Models
{
    public class DadosConcelhoIndicador
    {
        /// <summary>
        /// Nome do concelho
        /// </summary>
        public string NomeConcelho { get; set; }

        /// <summary>
        /// data da ultima atualização do relatório
        /// </summary>
        public Nullable<DateTime> UltimaAtualizacao { get; set; }
        
        /// <summary>
        /// Numero de casos em unidades nos ultimos 14 dias
        /// </summary>
        public Nullable<int> NCasos { get; set; }
        
        /// <summary>
        /// Incidencia em unidades
        /// </summary>
        public Nullable<int> Incidencia { get; set; }

        /// <summary>
        /// Indice do da Categoria de Incidencia
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Classificação do Risco do Concelho
        /// </summary>
        public string Risco { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public DadosConcelhoIndicador() : this(null, null, null, null, null, null)
        {

        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="nomeConcelho"></param>
        /// <param name="ultimaAtualizacao"></param>
        /// <param name="nCasos"></param>
        /// <param name="incidencia"></param>
        /// <param name="categoria"></param>
        /// <param name="risco"></param>
        public DadosConcelhoIndicador(string nomeConcelho, Nullable<DateTime> ultimaAtualizacao, Nullable<int> nCasos, Nullable<int> incidencia, 
            string categoria, string risco)
        {
            this.NomeConcelho = nomeConcelho;
            this.UltimaAtualizacao = ultimaAtualizacao;
            this.NCasos = nCasos;
            this.Incidencia = incidencia;
            this.Categoria = categoria;
            this.Risco = risco;
        }

        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public DadosConcelhoIndicador Clone()
        {
            DadosConcelhoIndicador dadosConcelhoIndicador = new DadosConcelhoIndicador();

            dadosConcelhoIndicador.NomeConcelho = this.NomeConcelho;
            dadosConcelhoIndicador.UltimaAtualizacao = this.UltimaAtualizacao;
            dadosConcelhoIndicador.NCasos = this.NCasos;
            dadosConcelhoIndicador.Incidencia = this.Incidencia;
            dadosConcelhoIndicador.Categoria = this.Categoria;
            dadosConcelhoIndicador.Risco = this.Risco;
            
            return dadosConcelhoIndicador;
        }

    }
}
