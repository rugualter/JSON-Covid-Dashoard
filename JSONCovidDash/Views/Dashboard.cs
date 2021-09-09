using JSONCovidDash.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JSONCovidDash.Views
{
    public partial class Dashboard : Form
    {
        
        /// <summary>
        /// Mantém a instancia da view
        /// </summary>
        public View View { get; set; }

        /// <summary>
        /// Default Construtor
        /// </summary>
        public Dashboard()
        {
            InitializeComponent();

            //Configurar os indicadores disponiveis para o interface
            this.ConfigurarIndicadores();
        }

        /// <summary>
        /// Apresentar os criterios no interface
        /// Notifica que foram atualizados
        /// </summary>
        /// <param name="criterios"></param>
        public void AtribuirCriterios(Criterios criterios)
        {
            this.dtDate.Value = criterios.Data;
            this.cmbRegion.SelectedItem = criterios.Regiao;

            if (string.IsNullOrEmpty(criterios.Regiao))
            {
                this.cmbRegion.Enabled = false;
                this.cbOnlyPortugal.Checked = true;
            }
            else
            {
                this.cmbRegion.Enabled = true;
                this.cbOnlyPortugal.Checked = false;
            }
            
            this.NotificarAlteracaoCriterioPesquisa();
        }

        /// <summary>
        /// Atualiza os indicadores no interface
        /// </summary>
        /// <param name="dados"></param>
        public void AtualizarDadosConcelhos(DadosConcelhoIndicador dados)
        {
            this.concelhoData.Visible = (dados != null ? true : false);
            this.concelhoData.AtualizarIndicador(dados);
        }

        /// <summary>
        /// Atualiza os indicadores no interface
        /// </summary>
        /// <param name="dados"></param>
        public void AtualizarDados(Dados dados)
        {
            this.indicadorAtivo.AtualizarIndicador(dados.Ativos);
            this.indicadorConfirmados.AtualizarIndicador(dados.Confirmados);
            this.indicadorRecuperados.AtualizarIndicador(dados.Recuperados);
            this.indicadorObitos.AtualizarIndicador(dados.Obitos);
            this.indicadorInternados.AtualizarIndicador(dados.Internados);
            this.indicadorInternadosEnfermaria.AtualizarIndicador(dados.InternadosEnfermaria);
            this.indicadorInternadosUCI.AtualizarIndicador(dados.InternadosUCI);
            this.indicadorIncidencia.AtualizarIndicador(dados.IncidenciaNacional);
            this.indicadorRT.AtualizarIndicador(dados.RTNacional);
            this.indicadorVigilancia.AtualizarIndicador(dados.Vigilancia);

            this.indicadorNorte.AtualizarIndicador(dados.Norte);
            this.indicadorCentro.AtualizarIndicador(dados.Centro);
            this.indicadorValeTejo.AtualizarIndicador(dados.ValeTejo);
            this.indicadorAlentejo.AtualizarIndicador(dados.Alentejo);
            this.indicadorAlgarve.AtualizarIndicador(dados.Algarve);
            this.indicadorAcores.AtualizarIndicador(dados.Acores);
            this.indicadorMadeira.AtualizarIndicador(dados.Madeira);

            this.lblUltimoUpdate.Text = dados.UltimaAtualizacao.ToShortDateString();
        }

        /// <summary>
        /// Atualizar os indicadores do interface dos concelhos
        /// </summary>
        /// <param name="concelhos"></param>
        public void AtualizarConcelhos(List<string> concelhos)
        {
            foreach (string concelho in concelhos)
            {
                this.cmbRegion.Items.Add(concelho);
            }
        }

        /// <summary>
        /// Encerra a aplicação
        /// </summary>
        public void Encerrar()
        {
            Application.Exit();
        }

        /// <summary>
        /// Informa que o utilizador clicou no botão de pesquisa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.NotificarAlteracaoCriterioPesquisa();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.View.NotificarOFechoDaAplicacao(sender, e);
        }

        /// <summary>
        /// Informar que se clicou no botão de fechar o dashboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.View.NotificarOFechoDaAplicacao(sender, e);
        }

        private void cbOnlyPortugal_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbRegion.Enabled = !this.cbOnlyPortugal.Checked;

            if (this.cbOnlyPortugal.Checked == false && this.cmbRegion.Items.Count == 0)
                this.View.NotificarAlteracaoCriterioPrincipal();
        }

        /// <summary>
        /// Notificar que a alteração dos critérios
        /// </summary>
        private void NotificarAlteracaoCriterioPesquisa()
        {
            string region = string.Empty;

            if (this.cbOnlyPortugal.Checked == false && this.cmbRegion.SelectedItem != null)
                region = this.cmbRegion.SelectedItem.ToString();

            this.View.NotificarAlteracaoCriterioPesquisa(region, this.dtDate.Value);
        }

        /// <summary>
        /// Configurar os indicadores
        /// </summary>
        private void ConfigurarIndicadores()
        {
            this.indicadorAtivo.Titulo = "Ativos";
            this.indicadorConfirmados.Titulo = "Confirmados";
            this.indicadorRecuperados.Titulo = "Recuperados";
            this.indicadorObitos.Titulo = "Óbitos";
            this.indicadorRT.Titulo = "RT";
            this.indicadorIncidencia.Titulo = "Incidência";
            this.indicadorInternados.Titulo = "Internados";
            this.indicadorInternadosEnfermaria.Titulo = "Int. Enfermaria";
            this.indicadorInternadosUCI.Titulo = "Int. UCI";
            this.indicadorVigilancia.Titulo = "Vigilancia";
            this.indicadorRT.SuportaNumerosDecimais = true;
            this.indicadorIncidencia.SuportaNumerosDecimais = true;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.cbOnlyPortugal = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.indicadorNorte = new JSONCovidDash.Views.MiniIndicator();
            this.indicadorCentro = new JSONCovidDash.Views.MiniIndicator();
            this.indicadorValeTejo = new JSONCovidDash.Views.MiniIndicator();
            this.indicadorAlentejo = new JSONCovidDash.Views.MiniIndicator();
            this.indicadorAlgarve = new JSONCovidDash.Views.MiniIndicator();
            this.indicadorMadeira = new JSONCovidDash.Views.MiniIndicator();
            this.indicadorAcores = new JSONCovidDash.Views.MiniIndicator();
            this.indicadorAtivo = new JSONCovidDash.Views.Indicador();
            this.indicadorConfirmados = new JSONCovidDash.Views.Indicador();
            this.indicadorRecuperados = new JSONCovidDash.Views.Indicador();
            this.indicadorObitos = new JSONCovidDash.Views.Indicador();
            this.indicadorInternados = new JSONCovidDash.Views.Indicador();
            this.indicadorInternadosUCI = new JSONCovidDash.Views.Indicador();
            this.indicadorInternadosEnfermaria = new JSONCovidDash.Views.Indicador();
            this.indicadorVigilancia = new JSONCovidDash.Views.Indicador();
            this.indicadorRT = new JSONCovidDash.Views.Indicador();
            this.indicadorIncidencia = new JSONCovidDash.Views.Indicador();
            this.lblUltimoUpdate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.concelhoData = new JSONCovidDash.Views.ConcelhoData();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(114, 12);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(58, 15);
            this.lblRegion.TabIndex = 1;
            this.lblRegion.Text = "Concelho";
            this.lblRegion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(418, 14);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(31, 15);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Data";
            // 
            // cmbRegion
            // 
            this.cmbRegion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Location = new System.Drawing.Point(178, 9);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(234, 23);
            this.cmbRegion.TabIndex = 3;
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(455, 10);
            this.dtDate.MaxDate = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            this.dtDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(91, 23);
            this.dtDate.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(552, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::JSONCovidDash.Properties.Resources.logCovid;
            this.pictureBox1.Image = global::JSONCovidDash.Properties.Resources.logCovid;
            this.pictureBox1.Location = new System.Drawing.Point(3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Location = new System.Drawing.Point(633, 9);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 10;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // cbOnlyPortugal
            // 
            this.cbOnlyPortugal.AutoSize = true;
            this.cbOnlyPortugal.Location = new System.Drawing.Point(43, 10);
            this.cbOnlyPortugal.Name = "cbOnlyPortugal";
            this.cbOnlyPortugal.Size = new System.Drawing.Size(71, 19);
            this.cbOnlyPortugal.TabIndex = 11;
            this.cbOnlyPortugal.Text = "Portugal";
            this.cbOnlyPortugal.UseVisualStyleBackColor = true;
            this.cbOnlyPortugal.CheckedChanged += new System.EventHandler(this.cbOnlyPortugal_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::JSONCovidDash.Properties.Resources.Fundo;
            this.pictureBox2.Location = new System.Drawing.Point(283, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(425, 516);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // indicadorNorte
            // 
            this.indicadorNorte.BackColor = System.Drawing.Color.White;
            this.indicadorNorte.ForeColor = System.Drawing.Color.White;
            this.indicadorNorte.Location = new System.Drawing.Point(502, 86);
            this.indicadorNorte.Name = "indicadorNorte";
            this.indicadorNorte.Size = new System.Drawing.Size(100, 30);
            this.indicadorNorte.TabIndex = 14;
            // 
            // indicadorCentro
            // 
            this.indicadorCentro.BackColor = System.Drawing.Color.White;
            this.indicadorCentro.ForeColor = System.Drawing.Color.White;
            this.indicadorCentro.Location = new System.Drawing.Point(489, 192);
            this.indicadorCentro.Name = "indicadorCentro";
            this.indicadorCentro.Size = new System.Drawing.Size(100, 30);
            this.indicadorCentro.TabIndex = 15;
            // 
            // indicadorValeTejo
            // 
            this.indicadorValeTejo.BackColor = System.Drawing.Color.White;
            this.indicadorValeTejo.ForeColor = System.Drawing.Color.White;
            this.indicadorValeTejo.Location = new System.Drawing.Point(380, 318);
            this.indicadorValeTejo.Name = "indicadorValeTejo";
            this.indicadorValeTejo.Size = new System.Drawing.Size(100, 30);
            this.indicadorValeTejo.TabIndex = 16;
            // 
            // indicadorAlentejo
            // 
            this.indicadorAlentejo.BackColor = System.Drawing.Color.White;
            this.indicadorAlentejo.ForeColor = System.Drawing.Color.White;
            this.indicadorAlentejo.Location = new System.Drawing.Point(489, 404);
            this.indicadorAlentejo.Name = "indicadorAlentejo";
            this.indicadorAlentejo.Size = new System.Drawing.Size(100, 30);
            this.indicadorAlentejo.TabIndex = 17;
            // 
            // indicadorAlgarve
            // 
            this.indicadorAlgarve.BackColor = System.Drawing.Color.White;
            this.indicadorAlgarve.ForeColor = System.Drawing.Color.White;
            this.indicadorAlgarve.Location = new System.Drawing.Point(475, 492);
            this.indicadorAlgarve.Name = "indicadorAlgarve";
            this.indicadorAlgarve.Size = new System.Drawing.Size(100, 30);
            this.indicadorAlgarve.TabIndex = 18;
            // 
            // indicadorMadeira
            // 
            this.indicadorMadeira.BackColor = System.Drawing.Color.White;
            this.indicadorMadeira.ForeColor = System.Drawing.Color.White;
            this.indicadorMadeira.Location = new System.Drawing.Point(292, 246);
            this.indicadorMadeira.Name = "indicadorMadeira";
            this.indicadorMadeira.Size = new System.Drawing.Size(100, 30);
            this.indicadorMadeira.TabIndex = 19;
            // 
            // indicadorAcores
            // 
            this.indicadorAcores.BackColor = System.Drawing.Color.White;
            this.indicadorAcores.ForeColor = System.Drawing.Color.White;
            this.indicadorAcores.Location = new System.Drawing.Point(292, 141);
            this.indicadorAcores.Name = "indicadorAcores";
            this.indicadorAcores.Size = new System.Drawing.Size(100, 30);
            this.indicadorAcores.TabIndex = 20;
            // 
            // indicadorAtivo
            // 
            this.indicadorAtivo.BackColor = System.Drawing.Color.Transparent;
            this.indicadorAtivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.indicadorAtivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indicadorAtivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.indicadorAtivo.Location = new System.Drawing.Point(12, 42);
            this.indicadorAtivo.Name = "indicadorAtivo";
            this.indicadorAtivo.Size = new System.Drawing.Size(100, 49);
            this.indicadorAtivo.SuportaNumerosDecimais = false;
            this.indicadorAtivo.TabIndex = 21;
            this.indicadorAtivo.Titulo = "<Title>";
            // 
            // indicadorConfirmados
            // 
            this.indicadorConfirmados.BackColor = System.Drawing.Color.Transparent;
            this.indicadorConfirmados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.indicadorConfirmados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indicadorConfirmados.ForeColor = System.Drawing.Color.Blue;
            this.indicadorConfirmados.Location = new System.Drawing.Point(12, 97);
            this.indicadorConfirmados.Name = "indicadorConfirmados";
            this.indicadorConfirmados.Size = new System.Drawing.Size(100, 49);
            this.indicadorConfirmados.SuportaNumerosDecimais = false;
            this.indicadorConfirmados.TabIndex = 22;
            this.indicadorConfirmados.Titulo = "<Title>";
            // 
            // indicadorRecuperados
            // 
            this.indicadorRecuperados.BackColor = System.Drawing.Color.Transparent;
            this.indicadorRecuperados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.indicadorRecuperados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indicadorRecuperados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.indicadorRecuperados.Location = new System.Drawing.Point(12, 152);
            this.indicadorRecuperados.Name = "indicadorRecuperados";
            this.indicadorRecuperados.Size = new System.Drawing.Size(100, 49);
            this.indicadorRecuperados.SuportaNumerosDecimais = false;
            this.indicadorRecuperados.TabIndex = 23;
            this.indicadorRecuperados.Titulo = "<Title>";
            // 
            // indicadorObitos
            // 
            this.indicadorObitos.BackColor = System.Drawing.Color.Transparent;
            this.indicadorObitos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.indicadorObitos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indicadorObitos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.indicadorObitos.Location = new System.Drawing.Point(12, 207);
            this.indicadorObitos.Name = "indicadorObitos";
            this.indicadorObitos.Size = new System.Drawing.Size(100, 49);
            this.indicadorObitos.SuportaNumerosDecimais = false;
            this.indicadorObitos.TabIndex = 24;
            this.indicadorObitos.Titulo = "<Title>";
            // 
            // indicadorInternados
            // 
            this.indicadorInternados.BackColor = System.Drawing.Color.Transparent;
            this.indicadorInternados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.indicadorInternados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indicadorInternados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.indicadorInternados.Location = new System.Drawing.Point(118, 42);
            this.indicadorInternados.Name = "indicadorInternados";
            this.indicadorInternados.Size = new System.Drawing.Size(100, 49);
            this.indicadorInternados.SuportaNumerosDecimais = false;
            this.indicadorInternados.TabIndex = 25;
            this.indicadorInternados.Titulo = "<Title>";
            // 
            // indicadorInternadosUCI
            // 
            this.indicadorInternadosUCI.BackColor = System.Drawing.Color.Transparent;
            this.indicadorInternadosUCI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.indicadorInternadosUCI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indicadorInternadosUCI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.indicadorInternadosUCI.Location = new System.Drawing.Point(118, 97);
            this.indicadorInternadosUCI.Name = "indicadorInternadosUCI";
            this.indicadorInternadosUCI.Size = new System.Drawing.Size(100, 49);
            this.indicadorInternadosUCI.SuportaNumerosDecimais = false;
            this.indicadorInternadosUCI.TabIndex = 26;
            this.indicadorInternadosUCI.Titulo = "<Title>";
            // 
            // indicadorInternadosEnfermaria
            // 
            this.indicadorInternadosEnfermaria.BackColor = System.Drawing.Color.Transparent;
            this.indicadorInternadosEnfermaria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.indicadorInternadosEnfermaria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indicadorInternadosEnfermaria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.indicadorInternadosEnfermaria.Location = new System.Drawing.Point(118, 152);
            this.indicadorInternadosEnfermaria.Name = "indicadorInternadosEnfermaria";
            this.indicadorInternadosEnfermaria.Size = new System.Drawing.Size(100, 49);
            this.indicadorInternadosEnfermaria.SuportaNumerosDecimais = false;
            this.indicadorInternadosEnfermaria.TabIndex = 27;
            this.indicadorInternadosEnfermaria.Titulo = "<Title>";
            // 
            // indicadorVigilancia
            // 
            this.indicadorVigilancia.BackColor = System.Drawing.Color.Transparent;
            this.indicadorVigilancia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.indicadorVigilancia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indicadorVigilancia.ForeColor = System.Drawing.Color.Silver;
            this.indicadorVigilancia.Location = new System.Drawing.Point(118, 207);
            this.indicadorVigilancia.Name = "indicadorVigilancia";
            this.indicadorVigilancia.Size = new System.Drawing.Size(100, 49);
            this.indicadorVigilancia.SuportaNumerosDecimais = false;
            this.indicadorVigilancia.TabIndex = 28;
            this.indicadorVigilancia.Titulo = "<Title>";
            // 
            // indicadorRT
            // 
            this.indicadorRT.BackColor = System.Drawing.Color.Transparent;
            this.indicadorRT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.indicadorRT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indicadorRT.ForeColor = System.Drawing.Color.Gray;
            this.indicadorRT.Location = new System.Drawing.Point(12, 262);
            this.indicadorRT.Name = "indicadorRT";
            this.indicadorRT.Size = new System.Drawing.Size(100, 49);
            this.indicadorRT.SuportaNumerosDecimais = false;
            this.indicadorRT.TabIndex = 29;
            this.indicadorRT.Titulo = "<Title>";
            // 
            // indicadorIncidencia
            // 
            this.indicadorIncidencia.BackColor = System.Drawing.Color.Transparent;
            this.indicadorIncidencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.indicadorIncidencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indicadorIncidencia.ForeColor = System.Drawing.Color.Gray;
            this.indicadorIncidencia.Location = new System.Drawing.Point(118, 262);
            this.indicadorIncidencia.Name = "indicadorIncidencia";
            this.indicadorIncidencia.Size = new System.Drawing.Size(100, 49);
            this.indicadorIncidencia.SuportaNumerosDecimais = false;
            this.indicadorIncidencia.TabIndex = 30;
            this.indicadorIncidencia.Titulo = "<Title>";
            // 
            // lblUltimoUpdate
            // 
            this.lblUltimoUpdate.AutoSize = true;
            this.lblUltimoUpdate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUltimoUpdate.Location = new System.Drawing.Point(640, 537);
            this.lblUltimoUpdate.Name = "lblUltimoUpdate";
            this.lblUltimoUpdate.Size = new System.Drawing.Size(65, 14);
            this.lblUltimoUpdate.TabIndex = 31;
            this.lblUltimoUpdate.Text = "99/99/9999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(558, 537);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 32;
            this.label1.Text = "Data Relatório:";
            // 
            // concelhoData
            // 
            this.concelhoData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("concelhoData.BackgroundImage")));
            this.concelhoData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.concelhoData.Location = new System.Drawing.Point(12, 349);
            this.concelhoData.Name = "concelhoData";
            this.concelhoData.Size = new System.Drawing.Size(274, 200);
            this.concelhoData.TabIndex = 33;
            this.concelhoData.Visible = false;
            // 
            // Dashboard
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(712, 561);
            this.Controls.Add(this.concelhoData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUltimoUpdate);
            this.Controls.Add(this.indicadorIncidencia);
            this.Controls.Add(this.indicadorRT);
            this.Controls.Add(this.indicadorVigilancia);
            this.Controls.Add(this.indicadorInternadosEnfermaria);
            this.Controls.Add(this.indicadorInternadosUCI);
            this.Controls.Add(this.indicadorInternados);
            this.Controls.Add(this.indicadorObitos);
            this.Controls.Add(this.indicadorRecuperados);
            this.Controls.Add(this.indicadorConfirmados);
            this.Controls.Add(this.indicadorAtivo);
            this.Controls.Add(this.indicadorAcores);
            this.Controls.Add(this.indicadorMadeira);
            this.Controls.Add(this.indicadorAlgarve);
            this.Controls.Add(this.indicadorAlentejo);
            this.Controls.Add(this.indicadorValeTejo);
            this.Controls.Add(this.indicadorCentro);
            this.Controls.Add(this.indicadorNorte);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cbOnlyPortugal);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.cmbRegion);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblRegion);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dashboard";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Covid-19";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
