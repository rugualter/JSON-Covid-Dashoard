using JSONCovidDash.Models;
using System.Windows.Forms;

namespace JSONCovidDash.Views
{
    public partial class MiniIndicator : UserControl
    {
        public MiniIndicator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Recebe as alterações dos dados do indicador
        /// </summary>
        /// <param name="dadosIndicador"></param>
        public void AtualizarIndicador(IndicadorRegiao indicadorRegiao)
        {
            this.SetValue(ref this.lblConfirmados, ref this.lblConfirmadosNovos, indicadorRegiao.Confirmados);
            this.SetValue(ref this.lblObitos, ref this.lblObitosNovos, indicadorRegiao.Obitos);
        }

        private void SetValue(ref Label labelAcumulado, ref Label labelDiferencao, DadosIndicador dadosIndicador)
        {
            if (dadosIndicador.Acumulado.HasValue == false)
                labelAcumulado.Text = "--";
            else
                labelAcumulado.Text = (dadosIndicador.Acumulado.Value == 0 ? "--" : dadosIndicador.Acumulado.Value.ToString("# ###"));

            string sinal = (dadosIndicador.Diferenca.HasValue && dadosIndicador.Diferenca.Value > 0 ? "+" : "");

            if (dadosIndicador.Diferenca.HasValue == false)
                labelDiferencao.Text = "--";
            else
                labelDiferencao.Text = string.Concat(sinal, (dadosIndicador.Diferenca.Value == 0 ? "--" : dadosIndicador.Diferenca.Value.ToString("# ###")));
        }
    }
}
