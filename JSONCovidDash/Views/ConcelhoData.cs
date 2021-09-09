using JSONCovidDash.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSONCovidDash.Views
{
    public partial class ConcelhoData : UserControl
    {
        public ConcelhoData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Recebe as alterações dos dados do indicador
        /// </summary>
        /// <param name="dadosIndicador"></param>
        public void AtualizarIndicador(DadosConcelhoIndicador dadosConcelhoIndicador)
        {
            this.AtualizacaoLabel(ref this.lblNome, dadosConcelhoIndicador.NomeConcelho);
            this.AtualizacaoLabel(ref this.lblCasos, ref this.lblCasosCaption, dadosConcelhoIndicador.NCasos);
            this.AtualizacaoLabel(ref this.lblIncidencia, ref this.lblIncidenciaCaption, dadosConcelhoIndicador.Incidencia);
            this.AtualizacaoLabel(ref this.lblCategoria, ref this.lblCategoriaCaption, dadosConcelhoIndicador.Categoria);
            this.AtualizacaoLabel(ref this.lblRisco, ref this.lblRiscoCaption, dadosConcelhoIndicador.Risco);
            this.AtualizacaoLabel(ref this.lblData, ref this.lblDataCaption, dadosConcelhoIndicador.UltimaAtualizacao);
        }

        /// <summary>
        /// Atualizar a label de um campo do tipo string
        /// </summary>
        /// <param name="label"></param>
        /// <param name="labelCaption"></param>
        /// <param name="text"></param>
        private void AtualizacaoLabel(ref Label label, ref Label labelCaption, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                label.Visible = false;
                if (labelCaption != null)
                    labelCaption.Visible = false;
            }
            else
            {
                label.Visible = true;
                label.Text = text;

                if (labelCaption != null)
                    labelCaption.Visible = true;
            }
        }

        /// <summary>
        /// Atualizar a label de um campo do tipo string
        /// </summary>
        /// <param name="label"></param>
        /// <param name="text"></param>
        private void AtualizacaoLabel(ref Label label, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                label.Visible = false;
            }
            else
            {
                label.Visible = true;
                label.Text = text;
            }
        }

        /// <summary>
        /// Atualizar a label de um campo do tipo string
        /// </summary>
        /// <param name="label"></param>
        /// <param name="labelCaption"></param>
        /// <param name="number"></param>
        private void AtualizacaoLabel(ref Label label, ref Label labelCaption, Nullable<int> number)
        {
            if (number.HasValue == false)
            {
                label.Visible = false;
                if (labelCaption != null)
                    labelCaption.Visible = false;
            }
            else
            {
                label.Visible = true;
                label.Text = number.Value.ToString("# ###");

                if (labelCaption != null)
                    labelCaption.Visible = true;
            }
        }

        /// <summary>
        /// Atualizar a label de um campo do tipo string
        /// </summary>
        /// <param name="label"></param>
        /// <param name="labelCaption"></param>
        /// <param name="data"></param>
        private void AtualizacaoLabel(ref Label label, ref Label labelCaption, Nullable<DateTime> data)
        {
            if (data.HasValue == false)
            {
                label.Visible = false;
                if (labelCaption != null)
                    labelCaption.Visible = false;
            }
            else
            {
                label.Visible = true;
                label.Text = data.Value.ToShortDateString();

                if (labelCaption != null)
                    labelCaption.Visible = true;
            }
        }
    }
}
