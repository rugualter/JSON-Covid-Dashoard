
namespace JSONCovidDash.Views
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>


        private System.ComponentModel.IContainer components = null;


        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbRegion;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.CheckBox cbOnlyPortugal;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MiniIndicator indicadorNorte;
        private MiniIndicator indicadorCentro;
        private MiniIndicator indicadorValeTejo;
        private MiniIndicator indicadorAlentejo;
        private MiniIndicator indicadorAlgarve;
        private MiniIndicator indicadorMadeira;
        private MiniIndicator indicadorAcores;
        private Indicador indicadorAtivo;
        private Indicador indicadorConfirmados;
        private Indicador indicadorRecuperados;
        private Indicador indicadorObitos;
        private Indicador indicadorInternados;
        private Indicador indicadorInternadosUCI;
        private Indicador indicadorInternadosEnfermaria;
        private Indicador indicadorVigilancia;
        private Indicador indicadorRT;
        private Indicador indicadorIncidencia;
        private System.Windows.Forms.Label lblUltimoUpdate;
        private System.Windows.Forms.Label label1;
        private ConcelhoData concelhoData;
    }
}

