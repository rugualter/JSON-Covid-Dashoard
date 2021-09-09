using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONCovidDash.Models
{
    public interface ICommonView
    {
        /// <summary>
        /// Informar os subscritores que o utilizador clicou em fechar a aplicação
        /// </summary>
        event EventHandler ClosedApplication;

        /// <summary>
        /// Ativar a interface, método default
        /// </summary>
        void AtivarInterFace();

        /// <summary>
        /// Notificar o fecho da aplicação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NotificarOFechoDaAplicacao(object sender, EventArgs e);

        /// <summary>
        /// Encerrar a aplicação
        /// </summary>
        void Encerrar();
    }
}
