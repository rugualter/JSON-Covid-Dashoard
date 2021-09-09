using System;
using System.Windows.Forms;

namespace JSONCovidDash.Views
{
    public partial class LogViewer : Form
    {
        /// <summary>
        /// Default Construtor
        /// </summary>
        public LogViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Escrever o log enviado na janela, apenas se a mensagem não estiver vazia
        /// </summary>
        /// <param name="log"></param>
        public void EscreverLog(string log)
        {
            this.txtLog.Clear();

            if (string.IsNullOrEmpty(log) == false)
            {
                //Adiciona uma quebra de linha
                //Logica de Apresentação
                if (string.IsNullOrEmpty(this.txtLog.Text) == false)
                {
                    this.txtLog.AppendText(Environment.NewLine);
                }

                this.txtLog.AppendText(log);
            }
        }
    }
}
