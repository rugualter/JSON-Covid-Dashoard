using System;

namespace JSONCovidDash.Models
{
    public class DadosIndicador
    {
        /// <summary>
        /// Valor Total
        /// </summary>
        public Nullable<decimal> Acumulado { get; set; }

        /// <summary>
        /// Diferença para o ultimo valor acumulado
        /// </summary>
        public Nullable<decimal> Diferenca { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public DadosIndicador() : this(null, null)
        {

        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="acumulado"></param>
        /// <param name="diferenca"></param>
        public DadosIndicador(Nullable<decimal> acumulado, Nullable<decimal> diferenca)
        {
            this.Acumulado = acumulado;
            this.Diferenca = diferenca;
        }

        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public DadosIndicador Clone()
        {
            DadosIndicador dadosIndicador = new DadosIndicador();
            dadosIndicador.Acumulado = this.Acumulado;
            dadosIndicador.Diferenca = this.Diferenca;
            return dadosIndicador;
        }
    }
}
