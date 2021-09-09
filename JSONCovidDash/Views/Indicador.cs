using System.Windows.Forms;

using JSONCovidDash.Models;

namespace JSONCovidDash.Views
{
    public partial class Indicador : UserControl
    {

        /// <summary>
        /// Título do indicador
        /// </summary>
        public string Titulo
        {
            get => this.lblTitle.Text;
            set => this.lblTitle.Text = value;
        }

        public bool SuportaNumerosDecimais { get; set; }

        /// <summary>
        /// Default construtor
        /// </summary>
        public Indicador()
        {
            InitializeComponent();
            this.SuportaNumerosDecimais = false;
        }

        /// <summary>
        /// Recebe as alterações dos dados do indicador
        /// </summary>
        /// <param name="dadosIndicador"></param>
        public void AtualizarIndicador(DadosIndicador dadosIndicador)
        {
            if (dadosIndicador.Acumulado.HasValue == false || dadosIndicador.Acumulado == 0)
                this.lblAcumulado.Text = "--";
            else
            {
                if (this.SuportaNumerosDecimais)
                    this.lblAcumulado.Text = dadosIndicador.Acumulado.Value.ToString("# ##0.00");
                else
                    this.lblAcumulado.Text = dadosIndicador.Acumulado.Value.ToString("# ###");

            }

            string sinal = (dadosIndicador.Diferenca > 0 ? "+" : "");

            if (dadosIndicador.Diferenca.HasValue == false || dadosIndicador.Diferenca == 0)
                this.lblDiferenca.Text = "--";
            else
            {
                if (this.SuportaNumerosDecimais)
                    this.lblDiferenca.Text = string.Format("{0} {1}", sinal, dadosIndicador.Diferenca.Value.ToString("# ##0.00"));
                else 
                    this.lblDiferenca.Text = string.Format("{0} {1}", sinal, dadosIndicador.Diferenca.Value.ToString("# ###"));
            }
                
        }

    }
}
