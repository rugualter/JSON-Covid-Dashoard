namespace JSONCovidDash.Models
{
    public class IndicadorRegiao
    {

        public DadosIndicador Confirmados { get; set; }
        public DadosIndicador Obitos { get; set; }

        public IndicadorRegiao() : this(null, null)
        {

        }

        public IndicadorRegiao(DadosIndicador confirmados, DadosIndicador obitos)
        {
            this.Confirmados = confirmados;
            this.Obitos = obitos;
        }

        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public IndicadorRegiao Clone()
        {
            IndicadorRegiao indicadorRegiao = new IndicadorRegiao();
            indicadorRegiao.Obitos = this.Obitos.Clone();
            indicadorRegiao.Confirmados = this.Confirmados.Clone();
            return indicadorRegiao;
        }

    }
}
