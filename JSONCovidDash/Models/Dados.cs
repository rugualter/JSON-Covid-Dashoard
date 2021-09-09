using System;

namespace JSONCovidDash.Models
{
    public class Dados
    { 
        public DateTime UltimaAtualizacao { get; set; }

        public IndicadorRegiao Norte { get; set; }
        public IndicadorRegiao Centro { get; set; }
        public IndicadorRegiao ValeTejo { get; set; }
        public IndicadorRegiao Alentejo { get; set; }
        public IndicadorRegiao Algarve { get; set; }
        public IndicadorRegiao Acores { get; set; }
        public IndicadorRegiao Madeira { get; set; }

        public DadosIndicador Confirmados { get; set; }
        public DadosIndicador Recuperados { get; set; }
        public DadosIndicador Ativos { get; set; }
        public DadosIndicador Obitos { get; set; }
        public DadosIndicador Internados { get; set; }
        public DadosIndicador InternadosUCI { get; set; }
        public DadosIndicador InternadosEnfermaria { get; set; }
        public DadosIndicador Vigilancia { get; set; }
        public DadosIndicador IncidenciaNacional { get; set; }
        public DadosIndicador RTNacional { get; set; }

        public DadosConcelhoIndicador DadosConcelhos { get; set; }

        /// <summary>
        /// Default construtor
        /// </summary>
        public Dados()
        {
            this.UltimaAtualizacao = DateTime.MinValue;

            this.Norte = new IndicadorRegiao();
            this.Centro = new IndicadorRegiao();
            this.ValeTejo = new IndicadorRegiao();
            this.Alentejo = new IndicadorRegiao();
            this.Algarve = new IndicadorRegiao();
            this.Acores = new IndicadorRegiao();
            this.Madeira = new IndicadorRegiao();

            this.Confirmados = new DadosIndicador();
            this.Recuperados = new DadosIndicador();
            this.Ativos = new DadosIndicador();
            this.Obitos = new DadosIndicador();

            this.Internados = new DadosIndicador();
            this.InternadosUCI = new DadosIndicador();
            this.InternadosEnfermaria = new DadosIndicador();

            this.Vigilancia = new DadosIndicador();

            this.IncidenciaNacional = new DadosIndicador();
            this.RTNacional = new DadosIndicador();
            this.DadosConcelhos = new DadosConcelhoIndicador();
        }

        /// <summary>
        /// Clone dos dados
        /// </summary>
        /// <returns></returns>
        public Dados Clone()
        {
            Dados dados = new Dados();
            dados.Norte = this.Norte.Clone();
            dados.Centro = this.Centro.Clone();
            dados.ValeTejo = this.ValeTejo.Clone();
            dados.Alentejo = this.Alentejo.Clone();
            dados.Algarve = this.Algarve.Clone();
            dados.Acores = this.Acores.Clone();
            dados.Madeira = this.Madeira.Clone();

            dados.Confirmados = this.Confirmados.Clone();
            dados.Recuperados = this.Recuperados.Clone();
            dados.Ativos = this.Ativos.Clone();
            dados.Obitos = this.Obitos.Clone();
            dados.Internados = this.Internados.Clone();
            dados.InternadosUCI = this.InternadosUCI.Clone();
            dados.InternadosEnfermaria = this.InternadosEnfermaria.Clone();
            dados.Vigilancia = this.Vigilancia.Clone();
            dados.IncidenciaNacional = this.IncidenciaNacional.Clone();
            dados.RTNacional = this.RTNacional.Clone();
            dados.UltimaAtualizacao = this.UltimaAtualizacao;
            dados.DadosConcelhos = this.DadosConcelhos.Clone();

            return dados;
        }
    }
}
