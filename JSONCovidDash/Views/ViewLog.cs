using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSONCovidDash.Views
{
    public class ViewLog
    {
        private LogViewer LogViewer {get; set;}
        
        /// <summary>
        /// 
        /// </summary>
        private Form FormPai { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formPai"></param>
        public ViewLog(Form formPai)
        {
            this.FormPai = formPai;
        }

        public void ConstruirLogViewer()
        {
            if (this.LogViewer == null)
                this.LogViewer = new LogViewer();
        }

        /// <summary>
        /// Escrever a entrada de log
        /// </summary>
        /// <param name="log"></param>
        public void EscreverLog(string log)
        {
            if (this.LogViewer != null)
            {
                this.LogViewer.EscreverLog(log);
                this.LogViewer.ShowDialog(this.FormPai);
            }

        }

    }
}
